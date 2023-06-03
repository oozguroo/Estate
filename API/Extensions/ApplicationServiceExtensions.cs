using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
        {
    opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });

        services.AddCors();
           services.AddScoped<ITokenService, TokenService>();
           services.AddScoped<IAdRepository, AdRepository>();
           services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
           services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
           services.AddScoped<IPhotoService, PhotoService>();
           services.AddScoped<IUserRepository, UserRepository>();



           return services;
        }
    }

}