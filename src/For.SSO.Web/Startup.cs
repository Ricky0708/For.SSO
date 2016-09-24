using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using For.SSO.Services.Repository;
using For.SSO.Services;
using Microsoft.AspNetCore.Http;
using For.SSO.AuthenticationManager;

namespace For.SSO.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddScoped<HttpContextService>();
            services.AddScoped<SignInManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient(typeof(RepositoryHelper));
            //services.AddAuthorization(option=>option.AddPolicy("AA",policy=>policy.))

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = "AA",
                ExpireTimeSpan = new TimeSpan(0, 0, 10),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = new PathString("/Account/Login"),
                AccessDeniedPath = new PathString("/Account/Login"),
            });

            //custom middleware to replace httpContext.user
            app.UseReplacePrincipal();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

 
            //app.UseCookieAuthentication()
            //Services.Repository.RepositoryHelper.connStr = Configuration.GetValue<string>("SSOEntities");
            DB.Models.DBConfiguration.SetDBConnection(
                Configuration.GetValue<string>("MetaData"),
                Configuration.GetValue<string>("Server"),
                Configuration.GetValue<string>("Database"),
                Configuration.GetValue<string>("Provider"),
                Configuration.GetValue<string>("UserID"),
                Configuration.GetValue<string>("Password"));
        }
    }
}
