
using AlphaHemAPI.Data;
using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.Repositories;
using AlphaHemAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AlphaHemAPI
{
    //Author : ALL
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhostClient", policy =>
                {
                    policy.WithOrigins("https://localhost:7054") // Blazor-klientens IP+port
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AlphaHemAPIDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Repositories
            builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
            builder.Services.AddScoped<IListingRepository, ListingRepository>(); // Co-author : Smilla
            builder.Services.AddScoped<IRealtorRepository, RealtorRepository>();
            
            builder.Services.AddScoped<IRepository<Realtor>>(sp => sp.GetRequiredService<IRealtorRepository>()); // Author : Niklas
            builder.Services.AddScoped<IRepository<Municipality>, MunicipalityRepository>();
            
            //Service layers
            builder.Services.AddScoped<RealtorService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<ListingService>();
            builder.Services.AddScoped<AgencyService>();
            builder.Services.AddScoped<MunicipalityService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope()) // Author: Mattias, Christoffer, Dominika, Conny
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AlphaHemAPIDbContext>();
                await SeedData.Initialize(context);
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowLocalhostClient");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
