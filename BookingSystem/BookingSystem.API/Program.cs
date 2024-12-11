
using AutoMapper;
using BookingSystem.API.Helpers;
using BookingSystem.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
 
namespace BookingSystem.API
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllers();
			builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<SystemContext>(

               options => {
                   options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
               });
           
            var app = builder.Build();
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var _dbcontext = services.GetRequiredService<SystemContext>();
			

			try
			{
				await _dbcontext.Database.MigrateAsync();
			}
			catch (Exception ex) { 
			
			
			}


            if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.RunAsync();
		}
	}
}
