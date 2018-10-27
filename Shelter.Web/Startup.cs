using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shelter.Database;
using Shelter.Domain;
using Shelter.Domain.Questionnaires;
using Shelter.Entity;
using Shelter.Web.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace Shelter.Web
{
    public class Startup
    {
        /// <summary/>
        public Startup(IConfiguration provider, IHostingEnvironment env)
        {
            //provider = provider.AddJsonFile("appsettings.json")
            //    .AddJsonFile("appsettings.json", true);
            Configuration = provider;
            Environment = env;
        }

        /// <summary/>
        public IConfiguration Configuration { get; }

        /// <summary/>
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opt => { opt.Filters.Add(typeof(ExceptionFilter)); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DatabaseContext>(opt => 
                opt.UseNpgsql(Configuration["ConnectionStrings:ConnectionDatabase"], 
                    npgOpt => npgOpt.MigrationsAssembly("Shelter.Web")));

            services.AddIdentity<User, Role>()
                .AddRoleStore<RoleStore>()
                .AddUserStore<UserStore>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(a => { a.AddProfiles(typeof(AutoMapperService)); });

            services.AddScoped<DatabaseInitialize>();
            services.AddScoped<IQuestionnaireService, QuestionnaireService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"});
                options.DescribeAllEnumsAsStrings();

                options.MapType<IFormFile>(() => new Schema {Type = "file"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = "help";
                });
            }
            else
            {
                loggerFactory.AddConsole();
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}