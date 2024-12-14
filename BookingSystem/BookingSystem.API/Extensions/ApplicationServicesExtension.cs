﻿using BookingSystem.API.Helpers;
using FinalProjectApi.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Extensions
{
    public static class  ApplicationServicesExtension
    {
        public  static IServiceCollection AddApplicationServices( this IServiceCollection services)

        {
     
           services.AddAutoMapper(typeof(MappingProfiles));
           services.Configure<ApiBehaviorOptions>(
                options =>
                {
                    options.InvalidModelStateResponseFactory = (ActionContext) =>

                    {
                        var errors = ActionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
                        .SelectMany(P => P.Value.Errors)
                        .Select(E => E.ErrorMessage)
                        .ToList();

                        var response = new ApiValidationErrorResponse()
                        {

                            Errors = errors
                        };

                        return new BadRequestObjectResult(response);

                    };


                });

           

            return services;
        }

        public static  WebApplication UseSwaggerMiddleWare( this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        } 
    }
}
