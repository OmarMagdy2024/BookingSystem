
using System.Text;
using AutoMapper;
using BookingSystem.API.Helpers;
using BookingSystem.API.MiddleWare;
using BookingSystem.Core.Models.Identity;
using BookingSystem.Repository;
using BookingSystem.Repository.Data.Identity;
using FinalProjectApi.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Writers;

namespace BookingSystem.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationServices();
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<SystemContext>(

               options => {
                   options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
               });
            builder.Services.AddDbContext<AppIdentityDbContetxt>(

             options => {
                 options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
             });

            builder.Services.AddAuthentication().AddJwtBearer("Bearer", options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT: ValidIssure"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:AuthKey"] ?? string.Empty))
                };
            });


            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {

            }).AddEntityFrameworkStores<AppIdentityDbContetxt>();
                var app = builder.Build();
                using var scope = app.Services.CreateScope();
                var services = scope.ServiceProvider;
                var _dbcontext = services.GetRequiredService<SystemContext>();
                var _identityDbContext = services.GetRequiredService<AppIdentityDbContetxt>();
                var _userManager = services.GetRequiredService<UserManager<AppUser>>();
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();


                try
                {
                    await _dbcontext.Database.MigrateAsync();
                    await _identityDbContext.Database.MigrateAsync();
                    await AppIdentityDbContextSeed.SeedUserAsync(_userManager);
                }
                catch (Exception ex) {

                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An Error occurred during Migration");
                }


                app.UseMiddleware<ExpcetionMiddleware>();
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwaggerMiddleWare();
                }


                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                await app.RunAsync();
            }
            
    }
    } 
