// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection;
using conference_registration.core.Entities;
using conference_registration.Infrastructure.Services;
using conference_registration.ui.web.Configuration;
using conference_registration.ui.web.Factories;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace conference_registration.ui.web
{
    using AutoMapper;

    using core.Entities.ConferenceAggregate;
    using core.Entities.RegistrationAggregate;
    using conference_registration.core.Interfaces;
    using data;
    using Interfaces;
    using MapperProfiles;
    using Services;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The _environment.
        /// </summary>
        private readonly IHostingEnvironment _environment;

        /// <summary>
        /// The _configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// The _logger factory.
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="environment">
        /// The environment.
        /// </param>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="loggerFactory">
        /// The logger factory.
        /// </param>
        public Startup(IHostingEnvironment environment, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            this._environment = environment;
            this._configuration = configuration;
            this._loggerFactory = loggerFactory;
        }

        // This method gets called by the runtime. Use this method to add services to the container.

        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            var logger = this._loggerFactory.CreateLogger<Startup>();

            if (this._environment.IsDevelopment())
            {
                // Development service configuration
                services.AddDbContext<ConferenceContext>(options =>
                    options.UseSqlServer(this._configuration.GetConnectionString("DefaultConnection")));

                services.AddScoped<IRepository<Attendee>, Repository<Attendee>>();
                services.AddScoped<IRepository<Conference>, ConferenceRepository>();
                services.AddScoped<IRepository<Session>, Repository<Session>>();
                services.AddScoped<IRepository<EmailAccount>, Repository<EmailAccount>>();
                services.AddScoped<IRepository<Registration>, RegistrationRepository>();
                services.AddScoped<IEmailSender, EmailSender>();
                services.AddScoped<IEmailModelFactories, EmailModelFactories>();
                //services.Configure<EmailConfiguration>(_configuration.GetSection("EmailConfiguration"));
                services.TryAddSingleton<IEmailConfiguration>(sp => sp.GetRequiredService<IOptions<EmailConfiguration>>().Value);

                //services.AddMediatr
                // Wiring the Mediator in the Container
                services.AddMediatR(Assembly.GetExecutingAssembly());
                services.AddScoped<IAttendeeService, AttendeeService>();
                services.AddScoped<IConferenceService, ConferenceService>();
                services.AddScoped<IRegistrationService, RegistrationService>();
              
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                // Register the Swagger generator, defining 1 or more Swagger documents
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                });


                // Auto Mapper Configurations
                var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new MappingProfile());
                    });

                IMapper mapper = mappingConfig.CreateMapper();
                services.AddSingleton(mapper);

                logger.LogInformation("Development environment");
            }
            else
            {
                // Development service configuration
                services.AddDbContext<ConferenceContext>(options =>
                    options.UseSqlServer(this._configuration.GetConnectionString("DefaultConnection")));
                services.AddScoped<IRepository<Attendee>, Repository<Attendee>>();
                services.AddScoped<IRepository<Conference>, ConferenceRepository>();
                services.AddScoped<IRepository<Session>, Repository<Session>>();
                services.AddScoped<IRepository<EmailAccount>, Repository<EmailAccount>>();
                services.AddScoped<IRepository<Registration>, RegistrationRepository>();

                services.Configure<EmailConfiguration>(_configuration.GetSection("EmailConfiguration"));
                services.TryAddSingleton<IEmailConfiguration>(sp => sp.GetRequiredService<IOptions<EmailConfiguration>>().Value);

                //services.AddMediatr
                services.AddMediatR(Assembly.GetExecutingAssembly());
                services.AddScoped<IAttendeeService, AttendeeService>();
                services.AddScoped<IConferenceService, ConferenceService>();
                services.AddScoped<IRegistrationService, RegistrationService>();
                services.AddScoped<IEmailSender, EmailSender>();
                services.AddScoped<IEmailModelFactories, EmailModelFactories>();

                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                // Auto Mapper Configurations
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });

                IMapper mapper = mappingConfig.CreateMapper();
                services.AddSingleton(mapper);

                logger.LogInformation("Production environment");
            }

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action=Index}/{id?}");
                });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
