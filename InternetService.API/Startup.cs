using DynobilV3.API.Filters;
using DynobilV3.Business.Abstract;
using DynobilV3.Business.Concrete;
using DynobilV3.Business.Mapping.Profiles;
using DynobilV3.Core.Configuration;
using DynobilV3.Core.DataAccess;
using DynobilV3.DataAccess.Abstract;
using DynobilV3.DataAccess.Concrete.Contexts;
using DynobilV3.DataAccess.Concrete.EntityFrameworkCore;
using DynobilV3.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DynobilV3.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBayiService, BayiManager>();
            services.AddScoped<IBayiDal, EfCoreBayiDal>();

            services.AddDbContext<BaseContext>(options =>
            {
                options.UseNpgsql("Host = localhost; Database = DynobilV3; Username = postgres; Password = Asd1234.", sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("DynobilV3.DataAccess");
                });
            });

            services.AddMemoryCache();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>   //api oldugu icin cookie yok jwt var 
            services.AddControllers(options =>
                    options.Filters.Add<ExceptionFiltersController>()
                    )
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DynobilV3.API", Version = "v1" });
            });
            //Yeni veriyonda boyle automapper

            services.AddAutoMapper(
                typeof(BayiProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DynobilV3.API v1"));
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
