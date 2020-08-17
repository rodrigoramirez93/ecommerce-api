using AutoMapper;
using Ecommerce.Business.Dto;
using Ecommerce.Business.Dto.Mappings;
using Ecommerce.Business.Services;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core;
using Ecommerce.Domain.DAL;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Repositories;
using Ecommerce.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddControllers();
            services.AddTransient<IServiceDto<ProductDto>, ProductServiceDto>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(_appsettings.ConnectionStrings.DefaultConnectionString);
            }, ServiceLifetime.Singleton);


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProductProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
