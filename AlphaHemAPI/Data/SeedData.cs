using AlphaHemAPI.Constants;
using AlphaHemAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                        ProfilePicture = "",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null,"Test1234!"),
                        Agency = agencies.FirstOrDefault(a => a.Name == "GreenLeaf Homes")
                    }
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
                    }
                };
                ctx.Listings.AddRange(listings);
            }

            ctx.SaveChanges();

        }

    }
}
