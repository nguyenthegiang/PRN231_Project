using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Authentication;
using WebAPI.IRepository;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI
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
            services.AddDistributedMemoryCache(); 
            services.AddSession(cfg => {
                cfg.Cookie.Name = "JWToken";
                cfg.IdleTimeout = new TimeSpan(0, 60, 0);
            });

            services.AddControllers();
            //For AJAX in Clients
            services.AddCors();
            //Database
            services.AddDbContext<MyDbContext>(otp => 
                otp.UseSqlServer(Configuration.GetConnectionString("DBContext")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
            var key = Configuration.GetSection("AppSettings").GetSection("Secret").Value;
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetSection("AppSettings").GetSection("WebSiteDomain").Value,
                    ValidateAudience = true,
                    ValidAudience = Configuration.GetSection("AppSettings").GetSection("WebSiteDomain").Value,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSingleton<IAuthenticationManager>(new AuthenticationManager(key));

            //Inject Repository to Controllers
            services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));
            services.AddSingleton(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddSingleton(typeof(IMovieRepository), typeof(MovieRepository));
            services.AddSingleton(typeof(IActorRepository), typeof(ActorRepository));
            services.AddSingleton(typeof(IRoleRepository), typeof(RoleRepository));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseCors(builder => builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

            app.UseSession();

            app.UseHttpsRedirection();

            app.UseRouting();

            //For [Watch Video]
            app.UseDefaultFiles();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
