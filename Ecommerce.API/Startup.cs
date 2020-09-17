using AutoMapper;
using Ecommerce.API.Extensions;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Dto.Mappings;
using Ecommerce.Business.Dto.Validators;
using Ecommerce.Business.Services;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Ecommerce.Domain.DAL;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Repositories;
using Ecommerce.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Security;

namespace API
{
    public class Startup
    {
        private readonly Appsettings _appsettings;
        public Startup(IConfiguration configuration)
        {
            _appsettings = new Appsettings();
            Configuration = configuration;
            Configuration.Bind(_appsettings);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Appsettings>(Configuration);

            services.AddControllers();

            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IServiceDto<ProductDto>, ProductServiceDto>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IDtoValidator<ProductDtoValidator, ProductDto>, DtoValidator<ProductDtoValidator, ProductDto>>();
            services.AddTransient<IDtoValidator<ProductFilterDtoValidator, ProductFilterDto>, DtoValidator<ProductFilterDtoValidator, ProductFilterDto>>();
            services.AddTransient<IFilterBuilder, FilterBuilder>();

            services.AddScoped<IRepository<Product>, ProductRepository>();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(_appsettings.ConnectionStrings.DefaultConnectionString);
            }, ServiceLifetime.Singleton);


            services.AddCors(options =>
            {
                options.AddPolicy(name: "default",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                  });
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProductProfile());
                mc.AddProfile(new UserProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            services.AddAuth(_appsettings.JwtSettings);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("default");

            app.UseAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
