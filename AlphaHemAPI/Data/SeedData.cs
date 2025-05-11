using AlphaHemAPI.Constants;
using AlphaHemAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Emit;

namespace AlphaHemAPI.Data
{
    // Author: Mattias, Christoffer, Dominika, Conny
    public static class SeedData
    {
        public static async Task Initialize(AlphaHemAPIDbContext ctx)
        {
            if (!ctx.Roles.Any())
            {
                //Co-Author : All
                var roles = new List<IdentityRole>
                {
                    new IdentityRole 
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = ApiRoles.RealtorAdmin,
                        NormalizedName = ApiRoles.RealtorAdmin 
                    },
                    new IdentityRole 
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = ApiRoles.RealtorUser, 
                        NormalizedName = ApiRoles.RealtorUser
                    }
                };
                ctx.Roles.AddRange(roles);
                await ctx.SaveChangesAsync();
            }


            if (!ctx.Agencies.Any())
            {
                var agencies = new List<Agency>
                {
                    new Agency
                    {
                        Name = "Sunset Realty",
                        Presentation = "Din pålitliga partner för fastigheter vid kusten. Vi specialiserar oss på strandnära bostäder och fritidshus med fantastisk havsutsikt. Med årtionden av erfarenhet guidar vi dig genom varje steg i bostadsköpet.",
                        Logo = "https://i.imgur.com/hhveNuO.png"
                    },

                    new Agency
                    {
                        Name = "Urban Nest",
                        Presentation = "Moderna lösningar för ett modernt boende. Vi fokuserar på stadslägenheter och nyproduktion i attraktiva urbana områden. Perfekt för unga par, familjer och investerare som söker ett stilrent liv i centrum.",
                        Logo = "https://i.imgur.com/gfV6sW6.png"
                    },

                    new Agency
                    {
                        Name = "Mountain View Estates",
                        Presentation = "Hitta ditt drömhem med utsikt över bergen. Vi erbjuder unika fastigheter i natursköna miljöer, från alpstugor till moderna villor med panoramautsikt. För dig som söker lugn, natur och exklusivitet.",
                        Logo = "https://i.imgur.com/BBV7eXr.png"
                    },

                    new Agency
                    {
                        Name = "Elite Property Group",
                        Presentation = "Lyxigt boende med exceptionell service. Vi förmedlar exklusiva bostäder till krävande kunder och erbjuder en personlig tjänst från första visning till avslutad affär. Din integritet och komfort är vår prioritet.",
                        Logo = ""
                    },

                    new Agency
                    {
                        Name = "GreenLeaf Homes",
                        Presentation = "Hållbara hem för en bättre framtid. Vi fokuserar på miljövänliga bostäder och gröna byggprojekt. Vårt mål är att kombinera modern design med hållbar utveckling – för både människor och planeten.",
                        Logo = "https://i.imgur.com/UhyQail.png"
                    },
                    new Agency
                    {
                        Name = "BlueKey Estates",
                        Presentation = "Bluekey Estates – Din nyckel till framtidens boende. Vi erbjuder smarta bostadslösningar med fokus på kvalitet, trygghet och hållbarhet. Med personlig service och lokal expertis hjälper vi dig att hitta ett hem där både du och miljön trivs.",
                        Logo = "https://i.imgur.com/h3OLkem.png"
                    },
                    new Agency
                    {
                        Name = "Anchor & Oak Properties",
                        Presentation = "Anchor & Oak – Där trygghet möter stil. Vi förmedlar hem med hjärta, där klassisk kvalitet förenas med modern livsstil. Med djupa rötter i lokalsamhället och ett öga för detaljer guidar vi dig tryggt genom varje bostadsresa.",
                        Logo = "https://i.imgur.com/pA0tULD.png"
                    }
                };
                ctx.Agencies.AddRange(agencies);
                ctx.SaveChanges();
            }


            //Co-Author : All
            if (!ctx.Realtors.Any())
            {
                var hasher = new PasswordHasher<Realtor>();
                var agencies = await ctx.Agencies.ToListAsync();
                var realtors = new List<Realtor>
                {
                    new Realtor
                    {
                        FirstName = "Anna",
                        LastName = "Svensson",
                        UserName = "anna.svensson@sunsetrealty.se",
                        NormalizedUserName = "ANNA.SVENSSON@SUNSETREALTY.SE",
                        Email = "anna.svensson@sunsetrealty.se",
                        NormalizedEmail = "ANNA.SVENSSON@SUNSETREALTY.SE",
                        PhoneNumber = "+46 70 123 45 67",
                        ProfilePicture = "https://i.imgur.com/hXvWF5S.png",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Sunset Realty")
                    },
                    new Realtor
                    {
                        FirstName = "Erik",
                        LastName = "Lindberg",
                        UserName = "erik.lindberg@urbannest.se",
                        NormalizedUserName = "ERIK.LINDBERG@URBANNEST.SE",
                        Email = "erik.lindberg@urbannest.se",
                        NormalizedEmail = "ERIK.LINDBERG@URBANNEST.SE",
                        PhoneNumber = "+46 70 234 56 78",
                        ProfilePicture = "https://i.imgur.com/zFOGna5.jpeg",
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        EmailConfirmed = true,
                        Agency = agencies.FirstOrDefault(a => a.Name == "Urban Nest")
                    },
                    new Realtor
                    {
                        FirstName = "Sara",
                        LastName = "Nyström",
                        UserName = "sara.nystrom@mountainview.se",
                        NormalizedUserName = "SARA.NYSTROM@MOUNTAINVIEW.SE",
                        Email = "sara.nystrom@mountainview.se",
                        NormalizedEmail = "SARA.NYSTROM@MOUNTAINVIEW.SE",
                        PhoneNumber = "+46 70 345 67 89",
                        ProfilePicture = "https://i.imgur.com/lmmEbEs.png",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Mountain View Estates")
                    },
                    new Realtor
                    {
                        FirstName = "Jonas",
                        LastName = "Ekström",
                        UserName = "jonas.ekstrom@eliteproperty.se",
                        NormalizedUserName = "JONAS.EKSTROM@ELITEPROPERTY.SE",
                        Email = "jonas.ekstrom@eliteproperty.se",
                        NormalizedEmail = "JONAS.EKSTROM@ELITEPROPERTY.SE",
                        PhoneNumber = "+46 70 456 78 90",
                        ProfilePicture = "https://i.imgur.com/cQ3xVSL.png",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Elite Property Group")
                    },
                    new Realtor
                    {
                        FirstName = "Elin",
                        LastName = "Karlsson",
                        UserName = "elin.karlsson@greenleaf.se",
                        NormalizedUserName = "ELIN.KARLSSON@GREENLEAF.SE",
                        Email = "elin.karlsson@greenleaf.se",
                        NormalizedEmail = "ELIN.KARLSSON@GREENLEAF.SE",
                        PhoneNumber = "+46 70 567 89 01",
                        ProfilePicture = "https://i.imgur.com/md1JLUh.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "GreenLeaf Homes")
                    },
                    new Realtor
                    {
                        FirstName = "Emil",
                        LastName = "Modig",
                        UserName = "emil.modig@sunsetrealty.se",
                        NormalizedUserName = "EMIL.MODIG@SUNSETREALTY.SE",
                        Email = "emil.modig@sunsetrealty.se",
                        NormalizedEmail = "EMIL.MODIG@SUNSETREALTY.SE",
                        PhoneNumber = "+46 70 9786837",
                        ProfilePicture = "https://i.imgur.com/1lL2qXz.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Sunset Realty")
                    },

                    new Realtor
                    {
                        FirstName = "Johan",
                        LastName = "Lindberg",
                        UserName = "johan.lindberg@sunsetrealty.se",
                        NormalizedUserName = "JOHAN.LINDBERG@SUNSETREALTY.SE",
                        Email = "johan.lindberg@sunsetrealty.se",
                        NormalizedEmail = "JOHAN.LINDBERG@SUNSETREALTY.SE",
                        PhoneNumber = "+46 70 4061838",
                        ProfilePicture = "https://i.imgur.com/2udU0aP.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Sunset Realty")
                    },

                    new Realtor
                    {
                        FirstName = "Sara",
                        LastName = "Andersson",
                        UserName = "sara.andersson@sunsetrealty.se",
                        NormalizedUserName = "SARA.ANDERSSON@SUNSETREALTY.SE",
                        Email = "sara.andersson@sunsetrealty.se",
                        NormalizedEmail = "SARA.ANDERSSON@SUNSETREALTY.SE",
                        PhoneNumber = "+46 70 8533139",
                        ProfilePicture = "https://i.imgur.com/ejhGhZR.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Sunset Realty")
                    },

                    new Realtor
                    {
                        FirstName = "Mikael",
                        LastName = "Svensson",
                        UserName = "mikael.svensson@urbannest.se",
                        NormalizedUserName = "MIKAEL.SVENSSON@URBANNEST.SE",
                        Email = "mikael.svensson@urbannest.se",
                        NormalizedEmail = "MIKAEL.SVENSSON@URBANNEST.SE",
                        PhoneNumber = "+46 70 2106961",
                        ProfilePicture = "https://i.imgur.com/PlU1MJo.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Urban Nest")
                    },

                    new Realtor
                    {
                        FirstName = "Emma",
                        LastName = "Nilsson",
                        UserName = "emma.nilsson@urbannest.se",
                        NormalizedUserName = "EMMA.NILSSON@URBANNEST.SE",
                        Email = "emma.nilsson@urbannest.se",
                        NormalizedEmail = "EMMA.NILSSON@URBANNEST.SE",
                        PhoneNumber = "+46 70 1668044",
                        ProfilePicture = "https://i.imgur.com/46ghKhh.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Urban Nest")
                    },

                    new Realtor
                    {
                        FirstName = "David",
                        LastName = "Ekström",
                        UserName = "david.ekström@urbannest.se",
                        NormalizedUserName = "DAVID.EKSTRÖM@URBANNEST.SE",
                        Email = "david.ekström@urbannest.se",
                        NormalizedEmail = "DAVID.EKSTRÖM@URBANNEST.SE",
                        PhoneNumber = "+46 70 7255306",
                        ProfilePicture = "https://i.imgur.com/7YrcwHP.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Urban Nest")
                    },

                    new Realtor
                    {
                        FirstName = "Lisa",
                        LastName = "Holm",
                        UserName = "lisa.holm@mountainview.se",
                        NormalizedUserName = "LISA.HOLM@MOUNTAINVIEW.SE",
                        Email = "lisa.holm@mountainview.se",
                        NormalizedEmail = "LISA.HOLM@MOUNTAINVIEW.SE",
                        PhoneNumber = "+46 70 1278492",
                        ProfilePicture = "https://i.imgur.com/tI51kYP.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Mountain View Estates")
                    },

                    new Realtor
                    {
                        FirstName = "Andreas",
                        LastName = "Persson",
                        UserName = "andreas.persson@mountainview.se",
                        NormalizedUserName = "ANDREAS.PERSSON@MOUNTAINVIEW.SE",
                        Email = "andreas.persson@mountainview.se",
                        NormalizedEmail = "ANDREAS.PERSSON@MOUNTAINVIEW.SE",
                        PhoneNumber = "+46 70 3284716",
                        ProfilePicture = "https://i.imgur.com/cdx6kGj.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Mountain View Estates")
                    },

                    new Realtor
                    {
                        FirstName = "Nina",
                        LastName = "Axelsson",
                        UserName = "nina.axelsson@mountainview.se",
                        NormalizedUserName = "NINA.AXELSSON@MOUNTAINVIEW.SE",
                        Email = "nina.axelsson@mountainview.se",
                        NormalizedEmail = "NINA.AXELSSON@MOUNTAINVIEW.SE",
                        PhoneNumber = "+46 70 5639871",
                        ProfilePicture = "https://i.imgur.com/xB9iqXO.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Mountain View Estates")
                    },

                    new Realtor
                    {
                        FirstName = "Oskar",
                        LastName = "Berglund",
                        UserName = "oskar.berglund@eliteproperty.se",
                        NormalizedUserName = "OSKAR.BERGLUND@ELITEPROPERTY.SE",
                        Email = "oskar.berglund@eliteproperty.se",
                        NormalizedEmail = "OSKAR.BERGLUND@ELITEPROPERTY.SE",
                        PhoneNumber = "+46 70 8152374",
                        ProfilePicture = "https://i.imgur.com/r7bxbEs.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Elite Property Group")
                    },

                    new Realtor
                    {
                        FirstName = "Matilda",
                        LastName = "Ström",
                        UserName = "matilda.ström@eliteproperty.se",
                        NormalizedUserName = "MATILDA.STRÖM@ELITEPROPERTY.SE",
                        Email = "matilda.ström@eliteproperty.se",
                        NormalizedEmail = "MATILDA.STRÖM@ELITEPROPERTY.SE",
                        PhoneNumber = "+46 70 3472836",
                        ProfilePicture = "https://i.imgur.com/AIKgPy2.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Elite Property Group")
                    },

                    new Realtor
                    {
                        FirstName = "Fredrik",
                        LastName = "Hansson",
                        UserName = "fredrik.hansson@eliteproperty.se",
                        NormalizedUserName = "FREDRIK.HANSSON@ELITEPROPERTY.SE",
                        Email = "fredrik.hansson@eliteproperty.se",
                        NormalizedEmail = "FREDRIK.HANSSON@ELITEPROPERTY.SE",
                        PhoneNumber = "+46 70 2391432",
                        ProfilePicture = "https://i.imgur.com/dVEgj6X.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Elite Property Group")
                    },

                    new Realtor
                    {
                        FirstName = "Sofia",
                        LastName = "Lindqvist",
                        UserName = "sofia.lindqvist@greenleaf.se",
                        NormalizedUserName = "SOFIA.LINDQVIST@GREENLEAF.SE",
                        Email = "sofia.lindqvist@greenleaf.se",
                        NormalizedEmail = "SOFIA.LINDQVIST@GREENLEAF.SE",
                        PhoneNumber = "+46 70 2392851",
                        ProfilePicture = "https://i.imgur.com/LThFVBX.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "GreenLeaf Homes")
                    },

                    new Realtor
                    {
                        FirstName = "Henrik",
                        LastName = "Forsberg",
                        UserName = "henrik.forsberg@greenleaf.se",
                        NormalizedUserName = "HENRIK.FORSBERG@GREENLEAF.SE",
                        Email = "henrik.forsberg@greenleaf.se",
                        NormalizedEmail = "HENRIK.FORSBERG@GREENLEAF.SE",
                        PhoneNumber = "+46 70 9378426",
                        ProfilePicture = "https://i.imgur.com/SK5twdX.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "GreenLeaf Homes")
                    },

                    new Realtor
                    {
                        FirstName = "Julia",
                        LastName = "Eklund",
                        UserName = "julia.eklund@bluekey.se",
                        NormalizedUserName = "JULIA.EKLUND@BLUEKEY.SE",
                        Email = "julia.eklund@bluekey.se",
                        NormalizedEmail = "JULIA.EKLUND@BLUEKEY.SE",
                        PhoneNumber = "+46 70 8123479",
                        ProfilePicture = "https://i.imgur.com/ROMdbgv.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "BlueKey Estates")
                    },

                    new Realtor
                    {
                        FirstName = "Marcus",
                        LastName = "Sandberg",
                        UserName = "marcus.sandberg@anchoroak.se",
                        NormalizedUserName = "MARCUS.SANDBERG@ANCHOROAK.SE",
                        Email = "marcus.sandberg@anchoroak.se",
                        NormalizedEmail = "MARCUS.SANDBERG@ANCHOROAK.SE",
                        PhoneNumber = "+46 70 4356712",
                        ProfilePicture = "https://i.imgur.com/LoUXRdU.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Anchor & Oak Properties")
                    },
                    new Realtor
                    {
                        FirstName = "Tobias",
                        LastName = "Granlund",
                        UserName = "tobias.granlund@bluekey.se",
                        NormalizedUserName = "TOBIAS.GRANLUND@BLUEKEY.SE",
                        Email = "tobias.granlund@bluekey.se",
                        NormalizedEmail = "TOBIAS.GRANLUND@BLUEKEY.SE",
                        PhoneNumber = "+46 70 4728391",
                        ProfilePicture = "https://i.imgur.com/3eAIYza.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "BlueKey Estates")
                    },

                    new Realtor
                    {
                        FirstName = "Amelia",
                        LastName = "Sundin",
                        UserName = "amelia.sundin@bluekey.se",
                        NormalizedUserName = "AMELIA.SUNDIN@BLUEKEY.SE",
                        Email = "amelia.sundin@bluekey.se",
                        NormalizedEmail = "AMELIA.SUNDIN@BLUEKEY.SE",
                        PhoneNumber = "+46 70 9457234",
                        ProfilePicture = "https://i.imgur.com/r1xANVj.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "BlueKey Estates")
                    },
                    new Realtor
                    {
                        FirstName = "Viktor",
                        LastName = "Blom",
                        UserName = "viktor.blom@anchoroak.se",
                        NormalizedUserName = "VIKTOR.BLOM@ANCHOROAK.SE",
                        Email = "viktor.blom@anchoroak.se",
                        NormalizedEmail = "VIKTOR.BLOM@ANCHOROAK.SE",
                        PhoneNumber = "+46 70 3456281",
                        ProfilePicture = "https://i.imgur.com/m2QXP5u.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Anchor & Oak Properties")
                    },

                    new Realtor
                    {
                        FirstName = "Felicia",
                        LastName = "Hedlund",
                        UserName = "felicia.hedlund@anchoroak.se",
                        NormalizedUserName = "FELICIA.HEDLUND@ANCHOROAK.SE",
                        Email = "felicia.hedlund@anchoroak.se",
                        NormalizedEmail = "FELICIA.HEDLUND@ANCHOROAK.SE",
                        PhoneNumber = "+46 70 8943275",
                        ProfilePicture = "https://i.imgur.com/U8dPfRG.jpeg",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "Anchor & Oak Properties")
                    },


                };
                ctx.Realtors.AddRange(realtors);
                ctx.SaveChanges();
            }

            //Co-Author : All
            if (!ctx.UserRoles.Any())
            {
                var userRoles = new List<IdentityUserRole<string>>()
                {
                    new IdentityUserRole<string>
                    {
                        RoleId = ctx.Roles.FirstOrDefault(r => r.Name == ApiRoles.RealtorAdmin).Id,
                        UserId = ctx.Realtors.FirstOrDefault(r => r.Email == "anna.svensson@sunsetrealty.se").Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = ctx.Roles.FirstOrDefault(r => r.Name == ApiRoles.RealtorAdmin).Id,
                        UserId = ctx.Realtors.FirstOrDefault(r => r.Email == "erik.lindberg@urbannest.se").Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = ctx.Roles.FirstOrDefault(r => r.Name == ApiRoles.RealtorAdmin).Id,
                        UserId = ctx.Realtors.FirstOrDefault(r => r.Email == "sara.nystrom@mountainview.se").Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = ctx.Roles.FirstOrDefault(r => r.Name == ApiRoles.RealtorAdmin).Id,
                        UserId = ctx.Realtors.FirstOrDefault(r => r.Email == "jonas.ekstrom@eliteproperty.se").Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = ctx.Roles.FirstOrDefault(r => r.Name == ApiRoles.RealtorAdmin).Id,
                        UserId = ctx.Realtors.FirstOrDefault(r => r.Email == "elin.karlsson@greenleaf.se").Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = ctx.Roles.FirstOrDefault(r => r.Name == ApiRoles.RealtorAdmin).Id,
                        UserId = ctx.Realtors.FirstOrDefault(r => r.Email == "julia.eklund@bluekey.se").Id
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = ctx.Roles.FirstOrDefault(r => r.Name == ApiRoles.RealtorAdmin).Id,
                        UserId = ctx.Realtors.FirstOrDefault(r => r.Email == "viktor.blom@anchoroak.se").Id
                    },
                };
                ctx.UserRoles.AddRange(userRoles);
                ctx.SaveChanges();
            }


            if (!ctx.Municipalities.Any())
            {
                #region Municipalities
                var municipalities = new List<Municipality>
                {
                    new Municipality { Name = "Ale" },
                    new Municipality { Name = "Alingsås" },
                    new Municipality { Name = "Alvesta" },
                    new Municipality { Name = "Aneby" },
                    new Municipality { Name = "Arboga" },
                    new Municipality { Name = "Arjeplog" },
                    new Municipality { Name = "Arvidsjaur" },
                    new Municipality { Name = "Arvika" },
                    new Municipality { Name = "Askersund" },
                    new Municipality { Name = "Avesta" },
                    new Municipality { Name = "Bengtsfors" },
                    new Municipality { Name = "Berg" },
                    new Municipality { Name = "Bjurholm" },
                    new Municipality { Name = "Bjuv" },
                    new Municipality { Name = "Boden" },
                    new Municipality { Name = "Bollebygd" },
                    new Municipality { Name = "Bollnäs" },
                    new Municipality { Name = "Borgholm" },
                    new Municipality { Name = "Borlänge" },
                    new Municipality { Name = "Borås" },
                    new Municipality { Name = "Botkyrka" },
                    new Municipality { Name = "Boxholm" },
                    new Municipality { Name = "Bromölla" },
                    new Municipality { Name = "Bräcke" },
                    new Municipality { Name = "Burlöv" },
                    new Municipality { Name = "Båstad" },
                    new Municipality { Name = "Dals-Ed" },
                    new Municipality { Name = "Danderyd" },
                    new Municipality { Name = "Degerfors" },
                    new Municipality { Name = "Dorotea" },
                    new Municipality { Name = "Eda" },
                    new Municipality { Name = "Ekerö" },
                    new Municipality { Name = "Eksjö" },
                    new Municipality { Name = "Emmaboda" },
                    new Municipality { Name = "Enköping" },
                    new Municipality { Name = "Eskilstuna" },
                    new Municipality { Name = "Eslöv" },
                    new Municipality { Name = "Essunga" },
                    new Municipality { Name = "Fagersta" },
                    new Municipality { Name = "Falkenberg" },
                    new Municipality { Name = "Falköping" },
                    new Municipality { Name = "Falun" },
                    new Municipality { Name = "Filipstad" },
                    new Municipality { Name = "Finspång" },
                    new Municipality { Name = "Flen" },
                    new Municipality { Name = "Forshaga" },
                    new Municipality { Name = "Färgelanda" },
                    new Municipality { Name = "Gagnef" },
                    new Municipality { Name = "Gislaved" },
                    new Municipality { Name = "Gnesta" },
                    new Municipality { Name = "Gnosjö" },
                    new Municipality { Name = "Gotland" },
                    new Municipality { Name = "Grums" },
                    new Municipality { Name = "Grästorp" },
                    new Municipality { Name = "Gullspång" },
                    new Municipality { Name = "Gällivare" },
                    new Municipality { Name = "Gävle" },
                    new Municipality { Name = "Göteborg" },
                    new Municipality { Name = "Götene" },
                    new Municipality { Name = "Habo" },
                    new Municipality { Name = "Hagfors" },
                    new Municipality { Name = "Hallsberg" },
                    new Municipality { Name = "Hallstahammar" },
                    new Municipality { Name = "Halmstad" },
                    new Municipality { Name = "Hammarö" },
                    new Municipality { Name = "Haninge" },
                    new Municipality { Name = "Haparanda" },
                    new Municipality { Name = "Heby" },
                    new Municipality { Name = "Hedemora" },
                    new Municipality { Name = "Helsingborg" },
                    new Municipality { Name = "Herrljunga" },
                    new Municipality { Name = "Hjo" },
                    new Municipality { Name = "Hofors" },
                    new Municipality { Name = "Huddinge" },
                    new Municipality { Name = "Hudiksvall" },
                    new Municipality { Name = "Hultsfred" },
                    new Municipality { Name = "Hylte" },
                    new Municipality { Name = "Hällefors" },
                    new Municipality { Name = "Härjedalen" },
                    new Municipality { Name = "Härnösand" },
                    new Municipality { Name = "Härryda" },
                    new Municipality { Name = "Hässleholm" },
                    new Municipality { Name = "Håbo" },
                    new Municipality { Name = "Höganäs" },
                    new Municipality { Name = "Högsby" },
                    new Municipality { Name = "Hörby" },
                    new Municipality { Name = "Höör" },
                    new Municipality { Name = "Jokkmokk" },
                    new Municipality { Name = "Järfälla" },
                    new Municipality { Name = "Jönköping" },
                    new Municipality { Name = "Kalix" },
                    new Municipality { Name = "Kalmar" },
                    new Municipality { Name = "Karlsborg" },
                    new Municipality { Name = "Karlshamn" },
                    new Municipality { Name = "Karlskoga" },
                    new Municipality { Name = "Karlskrona" },
                    new Municipality { Name = "Karlstad" },
                    new Municipality { Name = "Katrineholm" },
                    new Municipality { Name = "Kil" },
                    new Municipality { Name = "Kinda" },
                    new Municipality { Name = "Kiruna" },
                    new Municipality { Name = "Klippan" },
                    new Municipality { Name = "Knivsta" },
                    new Municipality { Name = "Kramfors" },
                    new Municipality { Name = "Kristianstad" },
                    new Municipality { Name = "Kristinehamn" },
                    new Municipality { Name = "Krokom" },
                    new Municipality { Name = "Kumla" },
                    new Municipality { Name = "Kungsbacka" },
                    new Municipality { Name = "Kungsör" },
                    new Municipality { Name = "Kungälv" },
                    new Municipality { Name = "Kävlinge" },
                    new Municipality { Name = "Köping" },
                    new Municipality { Name = "Laholm" },
                    new Municipality { Name = "Landskrona" },
                    new Municipality { Name = "Laxå" },
                    new Municipality { Name = "Lekeberg" },
                    new Municipality { Name = "Leksand" },
                    new Municipality { Name = "Lerum" },
                    new Municipality { Name = "Lessebo" },
                    new Municipality { Name = "Lidingö" },
                    new Municipality { Name = "Lidköping" },
                    new Municipality { Name = "Lilla Edet" },
                    new Municipality { Name = "Lindesberg" },
                    new Municipality { Name = "Linköping" },
                    new Municipality { Name = "Ljungby" },
                    new Municipality { Name = "Ljusdal" },
                    new Municipality { Name = "Ljusnarsberg" },
                    new Municipality { Name = "Lomma" },
                    new Municipality { Name = "Ludvika" },
                    new Municipality { Name = "Luleå" },
                    new Municipality { Name = "Lund" },
                    new Municipality { Name = "Lycksele" },
                    new Municipality { Name = "Lysekil" },
                    new Municipality { Name = "Malmö" },
                    new Municipality { Name = "Malung-Sälen" },
                    new Municipality { Name = "Malå" },
                    new Municipality { Name = "Mariestad" },
                    new Municipality { Name = "Mark" },
                    new Municipality { Name = "Markaryd" },
                    new Municipality { Name = "Mellerud" },
                    new Municipality { Name = "Mjölby" },
                    new Municipality { Name = "Mora" },
                    new Municipality { Name = "Motala" },
                    new Municipality { Name = "Mullsjö" },
                    new Municipality { Name = "Munkedal" },
                    new Municipality { Name = "Munkfors" },
                    new Municipality { Name = "Mölndal" },
                    new Municipality { Name = "Mönsterås" },
                    new Municipality { Name = "Mörbylånga" },
                    new Municipality { Name = "Nacka" },
                    new Municipality { Name = "Nora" },
                    new Municipality { Name = "Norberg" },
                    new Municipality { Name = "Nordanstig" },
                    new Municipality { Name = "Nordmaling" },
                    new Municipality { Name = "Norrköping" },
                    new Municipality { Name = "Norrtälje" },
                    new Municipality { Name = "Norsjö" },
                    new Municipality { Name = "Nybro" },
                    new Municipality { Name = "Nykvarn" },
                    new Municipality { Name = "Nyköping" },
                    new Municipality { Name = "Nynäshamn" },
                    new Municipality { Name = "Nässjö" },
                    new Municipality { Name = "Ockelbo" },
                    new Municipality { Name = "Olofström" },
                    new Municipality { Name = "Orsa" },
                    new Municipality { Name = "Orust" },
                    new Municipality { Name = "Osby" },
                    new Municipality { Name = "Oskarshamn" },
                    new Municipality { Name = "Ovanåker" },
                    new Municipality { Name = "Oxelösund" },
                    new Municipality { Name = "Pajala" },
                    new Municipality { Name = "Partille" },
                    new Municipality { Name = "Perstorp" },
                    new Municipality { Name = "Piteå" },
                    new Municipality { Name = "Ragunda" },
                    new Municipality { Name = "Robertsfors" },
                    new Municipality { Name = "Ronneby" },
                    new Municipality { Name = "Rättvik" },
                    new Municipality { Name = "Sala" },
                    new Municipality { Name = "Salem" },
                    new Municipality { Name = "Sandviken" },
                    new Municipality { Name = "Sigtuna" },
                    new Municipality { Name = "Simrishamn" },
                    new Municipality { Name = "Sjöbo" },
                    new Municipality { Name = "Skara" },
                    new Municipality { Name = "Skellefteå" },
                    new Municipality { Name = "Skinnskatteberg" },
                    new Municipality { Name = "Skurup" },
                    new Municipality { Name = "Skövde" },
                    new Municipality { Name = "Smedjebacken" },
                    new Municipality { Name = "Sollefteå" },
                    new Municipality { Name = "Sollentuna" },
                    new Municipality { Name = "Solna" },
                    new Municipality { Name = "Sorsele" },
                    new Municipality { Name = "Sotenäs" },
                    new Municipality { Name = "Staffanstorp" },
                    new Municipality { Name = "Stenungsund" },
                    new Municipality { Name = "Stockholm" },
                    new Municipality { Name = "Storfors" },
                    new Municipality { Name = "Storuman" },
                    new Municipality { Name = "Strängnäs" },
                    new Municipality { Name = "Strömstad" },
                    new Municipality { Name = "Strömsund" },
                    new Municipality { Name = "Sundbyberg" },
                    new Municipality { Name = "Sundsvall" },
                    new Municipality { Name = "Sunne" },
                    new Municipality { Name = "Surahammar" },
                    new Municipality { Name = "Svalöv" },
                    new Municipality { Name = "Svedala" },
                    new Municipality { Name = "Svenljunga" },
                    new Municipality { Name = "Säffle" },
                    new Municipality { Name = "Säter" },
                    new Municipality { Name = "Sävsjö" },
                    new Municipality { Name = "Söderhamn" },
                    new Municipality { Name = "Söderköping" },
                    new Municipality { Name = "Södertälje" },
                    new Municipality { Name = "Sölvesborg" },
                    new Municipality { Name = "Tanum" },
                    new Municipality { Name = "Tibro" },
                    new Municipality { Name = "Tidaholm" },
                    new Municipality { Name = "Tierp" },
                    new Municipality { Name = "Timrå" },
                    new Municipality { Name = "Tingsryd" },
                    new Municipality { Name = "Tjörn" },
                    new Municipality { Name = "Tomelilla" },
                    new Municipality { Name = "Torsby" },
                    new Municipality { Name = "Torsås" },
                    new Municipality { Name = "Tranemo" },
                    new Municipality { Name = "Tranås" },
                    new Municipality { Name = "Trelleborg" },
                    new Municipality { Name = "Trollhättan" },
                    new Municipality { Name = "Trosa" },
                    new Municipality { Name = "Tyresö" },
                    new Municipality { Name = "Täby" },
                    new Municipality { Name = "Töreboda" },
                    new Municipality { Name = "Uddevalla" },
                    new Municipality { Name = "Ulricehamn" },
                    new Municipality { Name = "Umeå" },
                    new Municipality { Name = "Upplands Väsby" },
                    new Municipality { Name = "Upplands-Bro" },
                    new Municipality { Name = "Uppsala" },
                    new Municipality { Name = "Uppvidinge" },
                    new Municipality { Name = "Vadstena" },
                    new Municipality { Name = "Vaggeryd" },
                    new Municipality { Name = "Valdemarsvik" },
                    new Municipality { Name = "Vallentuna" },
                    new Municipality { Name = "Vansbro" },
                    new Municipality { Name = "Vara" },
                    new Municipality { Name = "Varberg" },
                    new Municipality { Name = "Vaxholm" },
                    new Municipality { Name = "Vellinge" },
                    new Municipality { Name = "Vetlanda" },
                    new Municipality { Name = "Vilhelmina" },
                    new Municipality { Name = "Vimmerby" },
                    new Municipality { Name = "Vindeln" },
                    new Municipality { Name = "Vingåker" },
                    new Municipality { Name = "Vänersborg" },
                    new Municipality { Name = "Vännäs" },
                    new Municipality { Name = "Värmdö" },
                    new Municipality { Name = "Värnamo" },
                    new Municipality { Name = "Västervik" },
                    new Municipality { Name = "Västerås" },
                    new Municipality { Name = "Växjö" },
                    new Municipality { Name = "Vårgårda" },
                    new Municipality { Name = "Ydre" },
                    new Municipality { Name = "Ystad" },
                    new Municipality { Name = "Älmhult" },
                    new Municipality { Name = "Älvdalen" },
                    new Municipality { Name = "Älvkarleby" },
                    new Municipality { Name = "Älvsbyn" },
                    new Municipality { Name = "Ängelholm" },
                    new Municipality { Name = "Åmål" },
                    new Municipality { Name = "Ånge" },
                    new Municipality { Name = "Åre" },
                    new Municipality { Name = "Årjäng" },
                    new Municipality { Name = "Åsele" },
                    new Municipality { Name = "Åstorp" },
                    new Municipality { Name = "Åtvidaberg" },
                    new Municipality { Name = "Öckerö" },
                    new Municipality { Name = "Ödeshög" },
                    new Municipality { Name = "Örebro" },
                    new Municipality { Name = "Örkelljunga" },
                    new Municipality { Name = "Örnsköldsvik" },
                    new Municipality { Name = "Östersund" },
                    new Municipality { Name = "Österåker" },
                    new Municipality { Name = "Östhammar" },
                    new Municipality { Name = "Östra Göinge" },
                    new Municipality { Name = "Överkalix" },
                    new Municipality { Name = "Övertorneå" },
                };
                #endregion

                ctx.Municipalities.AddRange(municipalities);
                ctx.SaveChanges();
            }

            if (!ctx.Listings.Any())
            {
                var realtors = await ctx.Realtors.ToListAsync();
                var municipalities = await ctx.Municipalities.ToListAsync();
                var listings = new List<Listing>
                {
                    // Realtor 1 - Anna Svensson
                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2008,
                        Price = 3750000m,
                        MonthlyFee = 4200m,
                        YearlyOperatingCost = 15000m,
                        LivingArea = 98m,
                        SecondaryArea = 10m,
                        LotArea = 120m,
                        Address = "Strandvägen 12, Göteborg",
                        Description = "Modern och ljus lägenhet med havsutsikt, perfekt för familjen som älskar kustlivet.",
                        Images = new List<string> { "https://i.imgur.com/WuRV0dn.png", "https://i.imgur.com/odwSmEF.png" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Göteborg"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "anna.svensson@sunsetrealty.se")
                    },
                    new Listing
                    {
                        Rooms = 3,
                        YearBuilt = 2015,
                        Price = 2850000m,
                        MonthlyFee = 3100m,
                        YearlyOperatingCost = 12000m,
                        LivingArea = 76m,
                        SecondaryArea = 5m,
                        LotArea = 90m,
                        Address = "Fyrvägen 8, Hönö",
                        Description = "Ljus och öppen planlösning i denna havsnära bostadsrätt på populära Hönö.",
                        Images = new List<string> { "https://i.imgur.com/EnzJruK.png", "https://i.imgur.com/nKI63e8.png" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Öckerö"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "anna.svensson@sunsetrealty.se")
                    },

                    // Realtor 2 - Erik Lindberg
                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2020,
                        Price = 3250000m,
                        MonthlyFee = 2800m,
                        YearlyOperatingCost = 10000m,
                        LivingArea = 55m,
                        SecondaryArea = 0m,
                        LotArea = 0m,
                        Address = "Klarabergsgatan 21, Stockholm",
                        Description = "Stilren lägenhet i hjärtat av Stockholm, nära allt stadslivet erbjuder.",
                        Images = new List<string> { "https://i.imgur.com/rry5NrX.png", "https://i.imgur.com/OJCKvg2.png", "https://i.imgur.com/FP5OJL2.png" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Stockholm"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "erik.lindberg@urbannest.se")
                    },
                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 2012,
                        Price = 4550000m,
                        MonthlyFee = 4900m,
                        YearlyOperatingCost = 18000m,
                        LivingArea = 115m,
                        SecondaryArea = 15m,
                        LotArea = 140m,
                        Address = "Sundbybergsvägen 3B, Solna",
                        Description = "Rymlig och välplanerad radhuslägenhet med uteplats och nära till tunnelbana.",
                        Images = new List<string> { "https://i.imgur.com/OdbPM2T.png", "https://i.imgur.com/aZ41pSI.png", "https://i.imgur.com/y8v50T9.png" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Solna"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "erik.lindberg@urbannest.se")
                    },

                    // Realtor 3 - Sara Nyström
                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 1995,
                        Price = 5200000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 28000m,
                        LivingArea = 140m,
                        SecondaryArea = 25m,
                        LotArea = 750m,
                        Address = "Fjällvägen 7, Åre",
                        Description = "Charmig villa med fantastisk utsikt över fjällen, perfekt som permanentboende eller fjällstuga.",
                        Images = new List<string> { "https://i.imgur.com/T0GM1Oi.png", "https://i.imgur.com/BDc8cfG.png", "https://i.imgur.com/rdPIPyp.png", "https://i.imgur.com/eCjUtDu.png" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Åre"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "sara.nystrom@mountainview.se")
                    },
                    new Listing
                    {
                        Rooms = 3,
                        YearBuilt = 1988,
                        Price = 2100000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 14000m,
                        LivingArea = 70m,
                        SecondaryArea = 10m,
                        LotArea = 500m,
                        Address = "Skogsstigen 14, Sälen",
                        Description = "Mysigt fritidshus med närhet till skidbackar och natur. Perfekt för avkoppling.",
                        Images = new List<string> { "https://i.imgur.com/cDckWe4.png", "https://i.imgur.com/G6BVTFK.png", "https://i.imgur.com/lKTRoTG.png", "https://i.imgur.com/HWHh2QR.png" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Malung-Sälen"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "sara.nystrom@mountainview.se")
                    },

                    // Realtor 4 - Jonas Ekström
                    new Listing
                    {
                        Rooms = 7,
                        YearBuilt = 2021,
                        Price = 9800000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 40000m,
                        LivingArea = 200m,
                        SecondaryArea = 30m,
                        LotArea = 1100m,
                        Address = "Djursholmsvägen 1, Djursholm",
                        Description = "Exklusiv villa i Djursholm med pool, vinkällare och generösa sällskapsytor.",
                        Images = new List<string> { "https://i.imgur.com/fbiru5v.png", "https://i.imgur.com/o99VOwB.png", "https://i.imgur.com/4mjTjux.png", "https://i.imgur.com/84Cu8z2.png", "https://i.imgur.com/M7S3e4A.png", "https://i.imgur.com/idhH7E3.png" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Danderyd"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "jonas.ekstrom@eliteproperty.se")
                    },
                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2016,
                        Price = 5650000m,
                        MonthlyFee = 4200m,
                        YearlyOperatingCost = 22000m,
                        LivingArea = 100m,
                        SecondaryArea = 10m,
                        LotArea = 300m,
                        Address = "Östermalmsgatan 45, Stockholm",
                        Description = "Lyxig lägenhet med takterrass i ett av Stockholms mest eftertraktade områden.",
                        Images = new List<string> { "https://i.imgur.com/Dy8k7A4.png", "https://i.imgur.com/LFoLcoR.png", "https://i.imgur.com/rGhkKJL.png", "https://i.imgur.com/hCvFOaG.png", "https://i.imgur.com/zmXYstv.png" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Stockholm"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "jonas.ekstrom@eliteproperty.se")
                    },

                    // Realtor 5 - Elin Karlsson
                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2022,
                        Price = 4350000m,
                        MonthlyFee = 3000m,
                        YearlyOperatingCost = 11000m,
                        LivingArea = 95m,
                        SecondaryArea = 0m,
                        LotArea = 0m,
                        Address = "Ekoparken 6, Uppsala",
                        Description = "Nyproducerad och miljövänlig lägenhet med energieffektiva lösningar och nära till natur.",
                        Images = new List<string> { "https://i.imgur.com/GYA2Cxg.png", "https://i.imgur.com/i5xF6Al.png", "https://i.imgur.com/jNYZJSX.png", "https://i.imgur.com/TBQa5Zr.png" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Uppsala"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "elin.karlsson@greenleaf.se")
                    },
                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 2023,
                        Price = 4950000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 13000m,
                        LivingArea = 110m,
                        SecondaryArea = 20m,
                        LotArea = 650m,
                        Address = "Solrosvägen 9, Växjö",
                        Description = "Miljövänligt byggd villa i lugnt område med solpaneler och regnvattenuppsamling.",
                        Images = new List<string> { "https://i.imgur.com/HqdcLSG.png", "https://i.imgur.com/MzpGpLg.png", "https://i.imgur.com/PJ3j1hm.png", "https://i.imgur.com/Xiggcfk.png" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Växjö"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "elin.karlsson@greenleaf.se")
                    },




                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 1995,
                        Price = 8000000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 18808m,
                        LivingArea = 100m,
                        SecondaryArea = 20m,
                        LotArea = 900m,
                        Address = "Storgatan 30, Stockholm",
                        Description = "Ljus och modern bostad med öppen planlösning och närhet till centrum.",
                        Images = new List<string> { "https://i.imgur.com/lKTRoTG.png?img=120", "https://i.imgur.com/rGhkKJL.png?img=100", "https://i.imgur.com/y8v50T9.png?img=89" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Stockholm"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "emil.modig@sunsetrealty.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2015,
                        Price = 8300000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 23545m,
                        LivingArea = 92m,
                        SecondaryArea = 5m,
                        LotArea = 400m,
                        Address = "Linnégatan 56, Göteborg",
                        Description = "Perfekt familjevilla med stor trädgård och lugnt läge.",
                        Images = new List<string> { "https://i.imgur.com/OGhmj9M.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Göteborg"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "emil.modig@sunsetrealty.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2008,
                        Price = 9400000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 12195m,
                        LivingArea = 157m,
                        SecondaryArea = 0m,
                        LotArea = 600m,
                        Address = "Sveavägen 49, Malmö",
                        Description = "Stilren lägenhet med balkong och goda kommunikationer.",
                        Images = new List<string> { "https://i.imgur.com/kNtYCDX.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Malmö"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "emil.modig@sunsetrealty.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2015,
                        Price = 2900000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 25702m,
                        LivingArea = 150m,
                        SecondaryArea = 0m,
                        LotArea = 600m,
                        Address = "Kungsgatan 28, Uppsala",
                        Description = "Charmigt hus i populärt område, nära skolor och service.",
                        Images = new List<string> { "https://i.imgur.com/DnLCuxP.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Uppsala"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "johan.lindberg@sunsetrealty.se")
                    },

                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 1996,
                        Price = 8300000m,
                        MonthlyFee = 2900m,
                        YearlyOperatingCost = 21259m,
                        LivingArea = 180m,
                        SecondaryArea = 10m,
                        LotArea = 400m,
                        Address = "Drottninggatan 68, Västerås",
                        Description = "Välplanerat radhus med solig uteplats och grönområden omkring.",
                        Images = new List<string> { "https://i.imgur.com/11T1ZoX.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Västerås"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "johan.lindberg@sunsetrealty.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2020,
                        Price = 9000000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 19017m,
                        LivingArea = 172m,
                        SecondaryArea = 5m,
                        LotArea = 100m,
                        Address = "Västra Hamngatan 87, Örebro",
                        Description = "Nyproducerad lägenhet med exklusiva materialval.",
                        Images = new List<string> { "https://i.imgur.com/sDBaqZQ.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Örebro"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "johan.lindberg@sunsetrealty.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 1995,
                        Price = 4700000m,
                        MonthlyFee = 2900m,
                        YearlyOperatingCost = 28776m,
                        LivingArea = 126m,
                        SecondaryArea = 20m,
                        LotArea = 400m,
                        Address = "Östra Storgatan 50, Linköping",
                        Description = "Rymlig villa med dubbelgarage och utsikt över naturen.",
                        Images = new List<string> { "https://i.imgur.com/bRjq2s5.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Linköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "sara.andersson@sunsetrealty.se")
                    },

                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 2015,
                        Price = 7300000m,
                        MonthlyFee = 2900m,
                        YearlyOperatingCost = 20983m,
                        LivingArea = 111m,
                        SecondaryArea = 5m,
                        LotArea = 100m,
                        Address = "Tegelbruksgatan 1, Helsingborg",
                        Description = "Mysig bostad med kakelugn och trägolv i original.",
                        Images = new List<string> { "https://i.imgur.com/StHqavc.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Helsingborg"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "sara.andersson@sunsetrealty.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2013,
                        Price = 6800000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 11349m,
                        LivingArea = 136m,
                        SecondaryArea = 20m,
                        LotArea = 600m,
                        Address = "Ringvägen 73, Norrköping",
                        Description = "Centralt boende med allt du behöver runt hörnet.",
                        Images = new List<string> { "https://i.imgur.com/Zx7OoA2.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Norrköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "sara.andersson@sunsetrealty.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2019,
                        Price = 5300000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 14298m,
                        LivingArea = 57m,
                        SecondaryArea = 10m,
                        LotArea = 600m,
                        Address = "Strandvägen 30, Jönköping",
                        Description = "Nära till vatten och natur – perfekt för friluftsliv.",
                        Images = new List<string> { "https://i.imgur.com/sH3cM6B.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Jönköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "mikael.svensson@urbannest.se")
                    },

                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 2000,
                        Price = 9500000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 25579m,
                        LivingArea = 115m,
                        SecondaryArea = 10m,
                        LotArea = 0m,
                        Address = "Norrlandsgatan 23, Lund",
                        Description = "Energieffektiv fastighet med moderna lösningar.",
                        Images = new List<string> { "https://i.imgur.com/dtfoQVI.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Lund"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "mikael.svensson@urbannest.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2013,
                        Price = 4600000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 27642m,
                        LivingArea = 108m,
                        SecondaryArea = 5m,
                        LotArea = 200m,
                        Address = "Skolgatan 54, Umeå",
                        Description = "Välskött hem med stort renoverat kök och vardagsrum.",
                        Images = new List<string> { "https://i.imgur.com/uEVJdUz.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Umeå"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "mikael.svensson@urbannest.se")
                    },

                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 2019,
                        Price = 4500000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 18905m,
                        LivingArea = 152m,
                        SecondaryArea = 10m,
                        LotArea = 0m,
                        Address = "Parkgatan 5, Gävle",
                        Description = "Fantastisk utsikt och genomgående hög standard.",
                        Images = new List<string> { "https://i.imgur.com/z8JhHgJ.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Gävle"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "emma.nilsson@urbannest.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2009,
                        Price = 3900000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 21127m,
                        LivingArea = 132m,
                        SecondaryArea = 0m,
                        LotArea = 0m,
                        Address = "Industrigatan 74, Borås",
                        Description = "Optimalt pendlarläge med närhet till tåg och buss.",
                        Images = new List<string> { "https://i.imgur.com/LSmD4u3.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Borås"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "emma.nilsson@urbannest.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 1995,
                        Price = 2100000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 13774m,
                        LivingArea = 92m,
                        SecondaryArea = 20m,
                        LotArea = 0m,
                        Address = "Södra Vägen 30, Sundsvall",
                        Description = "Bo bekvämt och stilfullt i denna hemtrevliga bostad.",
                        Images = new List<string> { "https://i.imgur.com/er2R14m.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Sundsvall"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "emma.nilsson@urbannest.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2008,
                        Price = 6500000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 22885m,
                        LivingArea = 129m,
                        SecondaryArea = 10m,
                        LotArea = 900m,
                        Address = "Bergsgatan 5, Stockholm",
                        Description = "Unikt läge med både närhet till stad och natur.",
                        Images = new List<string> { "https://i.imgur.com/0ybTQWK.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Stockholm"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "david.ekström@urbannest.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2011,
                        Price = 8000000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 27153m,
                        LivingArea = 160m,
                        SecondaryArea = 5m,
                        LotArea = 900m,
                        Address = "Kyrkogatan 37, Göteborg",
                        Description = "Lugnt och barnvänligt område med fina promenadstråk.",
                        Images = new List<string> { "https://i.imgur.com/GPozBhw.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Göteborg"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "david.ekström@urbannest.se")
                    },

                    new Listing
                    {
                        Rooms = 3,
                        YearBuilt = 2012,
                        Price = 4300000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 19811m,
                        LivingArea = 144m,
                        SecondaryArea = 5m,
                        LotArea = 100m,
                        Address = "Fabriksgatan 32, Malmö",
                        Description = "Underbar sekelskifteslägenhet med högt i tak.",
                        Images = new List<string> { "https://i.imgur.com/1Popttd.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Malmö"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "david.ekström@urbannest.se")
                    },

                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 2012,
                        Price = 7500000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 18604m,
                        LivingArea = 140m,
                        SecondaryArea = 10m,
                        LotArea = 100m,
                        Address = "Torggatan 85, Uppsala",
                        Description = "Elegant boende med mycket ljus och rymd.",
                        Images = new List<string> { "https://i.imgur.com/fq2YEGg.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Uppsala"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "lisa.holm@mountainview.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2000,
                        Price = 7400000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 11354m,
                        LivingArea = 140m,
                        SecondaryArea = 0m,
                        LotArea = 900m,
                        Address = "Skogsvägen 1, Västerås",
                        Description = "Modern villa med smarta hemfunktioner.",
                        Images = new List<string> { "https://i.imgur.com/P8cCB6g.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Västerås"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "lisa.holm@mountainview.se")
                    },

                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 2001,
                        Price = 6700000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 23442m,
                        LivingArea = 130m,
                        SecondaryArea = 20m,
                        LotArea = 600m,
                        Address = "Storgatan 98, Örebro",
                        Description = "Ljus och modern bostad med öppen planlösning och närhet till centrum.",
                        Images = new List<string> { "https://i.imgur.com/1SgQ2d5.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Örebro"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "lisa.holm@mountainview.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 1990,
                        Price = 4300000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 18615m,
                        LivingArea = 69m,
                        SecondaryArea = 0m,
                        LotArea = 600m,
                        Address = "Linnégatan 1, Linköping",
                        Description = "Perfekt familjevilla med stor trädgård och lugnt läge.",
                        Images = new List<string> { "https://i.imgur.com/YsvV8uL.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Linköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "andreas.persson@mountainview.se")
                    },

                    new Listing
                    {
                        Rooms = 3,
                        YearBuilt = 2004,
                        Price = 4700000m,
                        MonthlyFee = 2900m,
                        YearlyOperatingCost = 21104m,
                        LivingArea = 159m,
                        SecondaryArea = 10m,
                        LotArea = 200m,
                        Address = "Sveavägen 4, Helsingborg",
                        Description = "Stilren lägenhet med balkong och goda kommunikationer.",
                        Images = new List<string> { "https://i.imgur.com/9wMPmDz.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Helsingborg"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "andreas.persson@mountainview.se")
                    },

                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 2006,
                        Price = 2200000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 12368m,
                        LivingArea = 115m,
                        SecondaryArea = 0m,
                        LotArea = 900m,
                        Address = "Kungsgatan 73, Norrköping",
                        Description = "Charmigt hus i populärt område, nära skolor och service.",
                        Images = new List<string> { "https://i.imgur.com/yQvOVw8.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Norrköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "andreas.persson@mountainview.se")
                    },

                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 2016,
                        Price = 8300000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 18100m,
                        LivingArea = 136m,
                        SecondaryArea = 0m,
                        LotArea = 100m,
                        Address = "Drottninggatan 70, Jönköping",
                        Description = "Välplanerat radhus med solig uteplats och grönområden omkring.",
                        Images = new List<string> { "https://i.imgur.com/NmvbVZQ.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Jönköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "nina.axelsson@mountainview.se")
                    },

                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 2004,
                        Price = 8700000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 26276m,
                        LivingArea = 118m,
                        SecondaryArea = 20m,
                        LotArea = 900m,
                        Address = "Västra Hamngatan 40, Lund",
                        Description = "Nyproducerad lägenhet med exklusiva materialval.",
                        Images = new List<string> { "https://i.imgur.com/0kdzpPT.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Lund"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "nina.axelsson@mountainview.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2015,
                        Price = 7500000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 11371m,
                        LivingArea = 99m,
                        SecondaryArea = 5m,
                        LotArea = 200m,
                        Address = "Östra Storgatan 43, Umeå",
                        Description = "Rymlig villa med dubbelgarage och utsikt över naturen.",
                        Images = new List<string> { "https://i.imgur.com/Yj5Bh6S.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Umeå"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "nina.axelsson@mountainview.se")
                    },

                    new Listing
                    {
                        Rooms = 3,
                        YearBuilt = 2011,
                        Price = 4800000m,
                        MonthlyFee = 2900m,
                        YearlyOperatingCost = 23486m,
                        LivingArea = 76m,
                        SecondaryArea = 5m,
                        LotArea = 900m,
                        Address = "Tegelbruksgatan 35, Gävle",
                        Description = "Mysig bostad med kakelugn och trägolv i original.",
                        Images = new List<string> { "https://i.imgur.com/MehMaqV.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Gävle"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "oskar.berglund@eliteproperty.se")
                    },

                    new Listing
                    {
                        Rooms = 3,
                        YearBuilt = 1991,
                        Price = 8400000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 29818m,
                        LivingArea = 63m,
                        SecondaryArea = 20m,
                        LotArea = 200m,
                        Address = "Ringvägen 70, Borås",
                        Description = "Centralt boende med allt du behöver runt hörnet.",
                        Images = new List<string> { "https://i.imgur.com/M8JZrkE.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Borås"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "oskar.berglund@eliteproperty.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2022,
                        Price = 3100000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 14761m,
                        LivingArea = 154m,
                        SecondaryArea = 20m,
                        LotArea = 600m,
                        Address = "Strandvägen 85, Sundsvall",
                        Description = "Nära till vatten och natur – perfekt för friluftsliv.",
                        Images = new List<string> { "https://i.imgur.com/eD6QKUg.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Sundsvall"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "oskar.berglund@eliteproperty.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 1991,
                        Price = 9400000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 21344m,
                        LivingArea = 115m,
                        SecondaryArea = 20m,
                        LotArea = 100m,
                        Address = "Norrlandsgatan 48, Stockholm",
                        Description = "Energieffektiv fastighet med moderna lösningar.",
                        Images = new List<string> { "https://i.imgur.com/EGGsMrX.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Stockholm"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "matilda.ström@eliteproperty.se")
                    },

                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 1998,
                        Price = 8100000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 15335m,
                        LivingArea = 152m,
                        SecondaryArea = 5m,
                        LotArea = 100m,
                        Address = "Skolgatan 18, Göteborg",
                        Description = "Välskött hem med stort renoverat kök och vardagsrum.",
                        Images = new List<string> { "https://i.imgur.com/kfdtNTZ.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Göteborg"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "matilda.ström@eliteproperty.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 1999,
                        Price = 4300000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 15727m,
                        LivingArea = 125m,
                        SecondaryArea = 20m,
                        LotArea = 100m,
                        Address = "Parkgatan 29, Malmö",
                        Description = "Fantastisk utsikt och genomgående hög standard.",
                        Images = new List<string> { "https://i.imgur.com/tP4LtLo.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Malmö"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "matilda.ström@eliteproperty.se")
                    },

                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 1998,
                        Price = 6000000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 13244m,
                        LivingArea = 87m,
                        SecondaryArea = 5m,
                        LotArea = 0m,
                        Address = "Industrigatan 68, Uppsala",
                        Description = "Optimalt pendlarläge med närhet till tåg och buss.",
                        Images = new List<string> { "https://i.imgur.com/ae9mDVE.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Uppsala"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "fredrik.hansson@eliteproperty.se")
                    },

                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 2022,
                        Price = 4300000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 28869m,
                        LivingArea = 139m,
                        SecondaryArea = 5m,
                        LotArea = 600m,
                        Address = "Södra Vägen 26, Västerås",
                        Description = "Bo bekvämt och stilfullt i denna hemtrevliga bostad.",
                        Images = new List<string> { "https://i.imgur.com/DGziwYP.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Västerås"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "fredrik.hansson@eliteproperty.se")
                    },

                    new Listing
                    {
                        Rooms = 3,
                        YearBuilt = 2023,
                        Price = 2200000m,
                        MonthlyFee = 2900m,
                        YearlyOperatingCost = 10649m,
                        LivingArea = 133m,
                        SecondaryArea = 5m,
                        LotArea = 200m,
                        Address = "Bergsgatan 96, Örebro",
                        Description = "Unikt läge med både närhet till stad och natur.",
                        Images = new List<string> { "https://i.imgur.com/A7icKyb.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Örebro"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "fredrik.hansson@eliteproperty.se")
                    },

                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 2023,
                        Price = 5000000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 12331m,
                        LivingArea = 174m,
                        SecondaryArea = 20m,
                        LotArea = 100m,
                        Address = "Kyrkogatan 42, Linköping",
                        Description = "Lugnt och barnvänligt område med fina promenadstråk.",
                        Images = new List<string> { "https://i.imgur.com/1cv08zy.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Linköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "sofia.lindqvist@greenleaf.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2006,
                        Price = 4200000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 28291m,
                        LivingArea = 86m,
                        SecondaryArea = 20m,
                        LotArea = 200m,
                        Address = "Fabriksgatan 2, Helsingborg",
                        Description = "Underbar sekelskifteslägenhet med högt i tak.",
                        Images = new List<string> { "https://i.imgur.com/TByp4Ug.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Helsingborg"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "sofia.lindqvist@greenleaf.se")
                    },

                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 1996,
                        Price = 3000000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 12078m,
                        LivingArea = 71m,
                        SecondaryArea = 20m,
                        LotArea = 0m,
                        Address = "Torggatan 63, Norrköping",
                        Description = "Elegant boende med mycket ljus och rymd.",
                        Images = new List<string> { "https://i.imgur.com/m8kISp5.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Norrköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "sofia.lindqvist@greenleaf.se")
                    },

                    new Listing
                    {
                        Rooms = 3,
                        YearBuilt = 1999,
                        Price = 7800000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 11837m,
                        LivingArea = 82m,
                        SecondaryArea = 5m,
                        LotArea = 0m,
                        Address = "Skogsvägen 15, Jönköping",
                        Description = "Modern villa med smarta hemfunktioner.",
                        Images = new List<string> { "https://i.imgur.com/WasOnd6.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Jönköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "henrik.forsberg@greenleaf.se")
                    },

                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 1994,
                        Price = 8500000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 26183m,
                        LivingArea = 113m,
                        SecondaryArea = 0m,
                        LotArea = 100m,
                        Address = "Storgatan 63, Lund",
                        Description = "Ljus och modern bostad med öppen planlösning och närhet till centrum.",
                        Images = new List<string> { "https://i.imgur.com/z5G5j3x.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Lund"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "henrik.forsberg@greenleaf.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2002,
                        Price = 6500000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 28931m,
                        LivingArea = 125m,
                        SecondaryArea = 20m,
                        LotArea = 900m,
                        Address = "Linnégatan 25, Umeå",
                        Description = "Perfekt familjevilla med stor trädgård och lugnt läge.",
                        Images = new List<string> { "https://i.imgur.com/S1OKlOd.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Umeå"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "henrik.forsberg@greenleaf.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2002,
                        Price = 3700000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 23709m,
                        LivingArea = 170m,
                        SecondaryArea = 10m,
                        LotArea = 400m,
                        Address = "Sveavägen 76, Gävle",
                        Description = "Stilren lägenhet med balkong och goda kommunikationer.",
                        Images = new List<string> { "https://i.imgur.com/FZqmOle.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Gävle"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "julia.eklund@bluekey.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2000,
                        Price = 5500000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 27732m,
                        LivingArea = 146m,
                        SecondaryArea = 0m,
                        LotArea = 100m,
                        Address = "Kungsgatan 15, Borås",
                        Description = "Charmigt hus i populärt område, nära skolor och service.",
                        Images = new List<string> { "https://i.imgur.com/X0MqcxC.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Borås"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "julia.eklund@bluekey.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2022,
                        Price = 3800000m,
                        MonthlyFee = 2900m,
                        YearlyOperatingCost = 16012m,
                        LivingArea = 84m,
                        SecondaryArea = 20m,
                        LotArea = 0m,
                        Address = "Drottninggatan 31, Sundsvall",
                        Description = "Välplanerat radhus med solig uteplats och grönområden omkring.",
                        Images = new List<string> { "https://i.imgur.com/zeMuHwr.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Sundsvall"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "julia.eklund@bluekey.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2014,
                        Price = 4600000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 14025m,
                        LivingArea = 180m,
                        SecondaryArea = 10m,
                        LotArea = 600m,
                        Address = "Västra Hamngatan 96, Stockholm",
                        Description = "Nyproducerad lägenhet med exklusiva materialval.",
                        Images = new List<string> { "https://i.imgur.com/BIW8qgD.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Stockholm"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "tobias.granlund@bluekey.se")
                    },

                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 2020,
                        Price = 7200000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 25918m,
                        LivingArea = 96m,
                        SecondaryArea = 5m,
                        LotArea = 400m,
                        Address = "Östra Storgatan 52, Göteborg",
                        Description = "Rymlig villa med dubbelgarage och utsikt över naturen.",
                        Images = new List<string> { "https://i.imgur.com/VGWOjzh.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Göteborg"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "tobias.granlund@bluekey.se")
                    },

                    new Listing
                    {
                        Rooms = 3,
                        YearBuilt = 1996,
                        Price = 7300000m,
                        MonthlyFee = 2900m,
                        YearlyOperatingCost = 13747m,
                        LivingArea = 137m,
                        SecondaryArea = 10m,
                        LotArea = 600m,
                        Address = "Tegelbruksgatan 94, Malmö",
                        Description = "Mysig bostad med kakelugn och trägolv i original.",
                        Images = new List<string> { "https://i.imgur.com/WOqRoUn.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Malmö"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "tobias.granlund@bluekey.se")
                    },

                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 1995,
                        Price = 9300000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 17015m,
                        LivingArea = 81m,
                        SecondaryArea = 20m,
                        LotArea = 0m,
                        Address = "Ringvägen 2, Uppsala",
                        Description = "Centralt boende med allt du behöver runt hörnet.",
                        Images = new List<string> { "https://i.imgur.com/Pf35FFv.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Uppsala"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "amelia.sundin@bluekey.se")
                    },

                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 2022,
                        Price = 7500000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 29801m,
                        LivingArea = 135m,
                        SecondaryArea = 0m,
                        LotArea = 200m,
                        Address = "Strandvägen 96, Västerås",
                        Description = "Nära till vatten och natur – perfekt för friluftsliv.",
                        Images = new List<string> { "https://i.imgur.com/hHBSP6X.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Västerås"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "amelia.sundin@bluekey.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 1993,
                        Price = 6400000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 10435m,
                        LivingArea = 145m,
                        SecondaryArea = 20m,
                        LotArea = 400m,
                        Address = "Norrlandsgatan 61, Örebro",
                        Description = "Energieffektiv fastighet med moderna lösningar.",
                        Images = new List<string> { "https://i.imgur.com/G9cSJaJ.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Örebro"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "amelia.sundin@bluekey.se")
                    },

                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 1993,
                        Price = 9500000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 20740m,
                        LivingArea = 75m,
                        SecondaryArea = 20m,
                        LotArea = 600m,
                        Address = "Skolgatan 34, Linköping",
                        Description = "Välskött hem med stort renoverat kök och vardagsrum.",
                        Images = new List<string> { "https://i.imgur.com/UO4cwY3.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Linköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "marcus.sandberg@anchoroak.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2017,
                        Price = 6300000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 23836m,
                        LivingArea = 79m,
                        SecondaryArea = 20m,
                        LotArea = 100m,
                        Address = "Parkgatan 31, Helsingborg",
                        Description = "Fantastisk utsikt och genomgående hög standard.",
                        Images = new List<string> { "https://i.imgur.com/OGhmj9M.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Helsingborg"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "marcus.sandberg@anchoroak.se")
                    },

                    new Listing
                    {
                        Rooms = 2,
                        YearBuilt = 2002,
                        Price = 3800000m,
                        MonthlyFee = 0m,
                        YearlyOperatingCost = 10697m,
                        LivingArea = 151m,
                        SecondaryArea = 10m,
                        LotArea = 900m,
                        Address = "Industrigatan 26, Norrköping",
                        Description = "Optimalt pendlarläge med närhet till tåg och buss.",
                        Images = new List<string> { "https://i.imgur.com/kNtYCDX.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Norrköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "marcus.sandberg@anchoroak.se")
                    },

                    new Listing
                    {
                        Rooms = 6,
                        YearBuilt = 2021,
                        Price = 7100000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 24026m,
                        LivingArea = 145m,
                        SecondaryArea = 0m,
                        LotArea = 600m,
                        Address = "Södra Vägen 72, Jönköping",
                        Description = "Bo bekvämt och stilfullt i denna hemtrevliga bostad.",
                        Images = new List<string> { "https://i.imgur.com/DnLCuxP.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Jönköping"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "viktor.blom@anchoroak.se")
                    },

                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 1996,
                        Price = 5100000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 19040m,
                        LivingArea = 84m,
                        SecondaryArea = 0m,
                        LotArea = 900m,
                        Address = "Bergsgatan 20, Lund",
                        Description = "Unikt läge med både närhet till stad och natur.",
                        Images = new List<string> { "https://i.imgur.com/11T1ZoX.jpeg" },
                        Category = Category.Villa,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Lund"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "viktor.blom@anchoroak.se")
                    },

                    new Listing
                    {
                        Rooms = 3,
                        YearBuilt = 2015,
                        Price = 3100000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 28835m,
                        LivingArea = 116m,
                        SecondaryArea = 10m,
                        LotArea = 200m,
                        Address = "Kyrkogatan 95, Umeå",
                        Description = "Lugnt och barnvänligt område med fina promenadstråk.",
                        Images = new List<string> { "https://i.imgur.com/sDBaqZQ.jpeg" },
                        Category = Category.Bostadsrättslägenhet,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Umeå"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "viktor.blom@anchoroak.se")
                    },

                    new Listing
                    {
                        Rooms = 4,
                        YearBuilt = 2007,
                        Price = 8900000m,
                        MonthlyFee = 5200m,
                        YearlyOperatingCost = 11891m,
                        LivingArea = 69m,
                        SecondaryArea = 5m,
                        LotArea = 900m,
                        Address = "Fabriksgatan 61, Gävle",
                        Description = "Underbar sekelskifteslägenhet med högt i tak.",
                        Images = new List<string> { "https://i.imgur.com/bRjq2s5.jpeg" },
                        Category = Category.Bostadsrättsradhus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Gävle"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "felicia.hedlund@anchoroak.se")
                    },

                    new Listing
                    {
                        Rooms = 5,
                        YearBuilt = 2001,
                        Price = 6200000m,
                        MonthlyFee = 3200m,
                        YearlyOperatingCost = 15698m,
                        LivingArea = 174m,
                        SecondaryArea = 0m,
                        LotArea = 600m,
                        Address = "Torggatan 56, Borås",
                        Description = "Elegant boende med mycket ljus och rymd.",
                        Images = new List<string> { "https://i.imgur.com/StHqavc.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Borås"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "felicia.hedlund@anchoroak.se")
                    },

                    new Listing
                    {
                        Rooms = 3,
                        YearBuilt = 2003,
                        Price = 9400000m,
                        MonthlyFee = 4500m,
                        YearlyOperatingCost = 21778m,
                        LivingArea = 160m,
                        SecondaryArea = 10m,
                        LotArea = 0m,
                        Address = "Skogsvägen 33, Sundsvall",
                        Description = "Modern villa med smarta hemfunktioner.",
                        Images = new List<string> { "https://i.imgur.com/Zx7OoA2.jpeg" },
                        Category = Category.Fritidshus,
                        Municipality = municipalities.FirstOrDefault(m => m.Name == "Sundsvall"),
                        Realtor = realtors.FirstOrDefault(r => r.Email == "felicia.hedlund@anchoroak.se")
                    },
                };
                ctx.Listings.AddRange(listings);
            }

            ctx.SaveChanges();

        }

    }
}
