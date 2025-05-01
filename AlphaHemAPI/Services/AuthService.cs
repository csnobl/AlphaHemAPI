using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AlphaHemAPI.Constants;
using AlphaHemAPI.Data;
using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AlphaHemAPI.Services
{
    //Author : ALL
    public class AuthService
    {
        private readonly UserManager<Realtor> userManager;
        private readonly IConfiguration configuration;

        public AuthService(UserManager<Realtor> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<AuthResult> Register(RealtorRegisterDto realtor)
        {
            try
            {
                var existingUser = await userManager.FindByEmailAsync(realtor.Email);
                if (existingUser != null)
                {
                    return new AuthResult
                    {
                        Succeeded = false,
                        Errors = new List<string> { "E-postadressen är redan registrerad " },
                    };
                }

                var newRealtor = new Realtor
                {
                    UserName = realtor.Email,
                    NormalizedUserName = realtor.Email.ToUpper(),
                    Email = realtor.Email,
                    NormalizedEmail = realtor.Email.ToUpper(),
                    FirstName = realtor.FirstName,
                    LastName = realtor.LastName,
                    PhoneNumber = realtor.PhoneNumber,
                    AgencyId = realtor.AgencyId,
                };

                var result = await userManager.CreateAsync(newRealtor, realtor.Password);

                if (result.Succeeded == false)
                {
                    return new AuthResult
                    {
                        Succeeded = false,
                        Errors = result.Errors.Select(e => e.Description).ToList(),
                    };
                }

                await userManager.AddToRoleAsync(newRealtor, ApiRoles.RealtorUser);
                return new AuthResult
                {
                    Succeeded = true,
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                return new AuthResult
                {
                    Succeeded = false,
                    Errors = new List<string> { ex.Message },
                };
            }
        }

        public async Task<AuthResult> Login(RealtorLoginDto realtor)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(realtor.Email);
                var passwordValid = await userManager.CheckPasswordAsync(user, realtor.Password);
                if (user == null || passwordValid == false)
                {
                    return new AuthResult
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Felaktig e-post eller lösenord." },
                    };
                }
                if (user.EmailConfirmed == false)
                {
                    return new AuthResult
                    {
                        Succeeded = false,
                        Errors = new List<string> { "E-postadressen är inte bekräftad." },
                    };
                }

                //Jwt
                string tokenString = await GenerateToken(user);

                return new AuthResult
                {
                    Succeeded = true,
                    Errors = null,
                    Token = tokenString,
                    UserId = user.Id,
                };
            }
            catch
            {
                return new AuthResult
                {
                    Succeeded = false,
                    Errors = new List<string> { "An error occurred during login." },
                };
            }
        }

        private async Task<string> GenerateToken(Realtor user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var userClaims = await userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id),
            }
            .Union(roleClaims)
            .Union(userClaims);;

            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
