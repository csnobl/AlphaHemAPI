using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.Repositories;

namespace AlphaHemAPI.Services
{
    //Author : ALL
    public class RealtorService
    {
        private readonly IRealtorRepository realtorRepository;

        public RealtorService(IRealtorRepository realtorRepository)
        {
            this.realtorRepository = realtorRepository;
        }

        // Author : Niklas
        public async Task<bool> RegisterRealtorAsync(RealtorRegisterDto registerDto)
        {
            var existing = await realtorRepository.GetByEmailAsync(registerDto.Email);
            if (existing != null)
                return false;

            var realtor = new Realtor
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PhoneNumber = registerDto.PhoneNumber,
                AgencyId = registerDto.AgencyId,
                ProfilePicture = "",
                Password = registerDto.Password,
            };

            await realtorRepository.AddAsync(realtor);
            return true;
        }
    }
}
