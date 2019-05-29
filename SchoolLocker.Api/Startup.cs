using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Persistence;
using Swashbuckle.AspNetCore.Swagger;

namespace SchoolLocker.Api
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>(_ => new UnitOfWork());

            services.AddSwaggerGen(configuration =>
                            configuration.SwaggerDoc(
                            "v1", new Info()
                            {
                                 Title = "SchoolLocker API",
                                 Version = "v1",
                                 Contact = new Contact()
                                 {
                                    Name = "Hlavacek Martin",
                                    Email = "",
                                    Url = ""
                                 }
                            }));
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            //app.UseSwaggerUI(configuration =>
            //{
            //    configuration.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolLocker API V1");
            //    configuration.RoutePrefix = string.Empty;
            //});
        }
    }
}
