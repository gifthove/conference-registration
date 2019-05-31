// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.ui.web
{
    using AutoMapper;

    using conference_registration.core.Entities.ConferenceAggregate;
    using conference_registration.core.Entities.RegistrationAggregate;
    using conference_registration.core.Interfaces;
    using conference_registration.data;
    using conference_registration.ui.web.Interfaces;
    using conference_registration.ui.web.MapperProfiles;
    using conference_registration.ui.web.Services;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

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
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                services.AddScoped<IRepository<Attendee>, Repository<Attendee>>();
                services.AddScoped<IRepository<Conference>, ConferenceRepository>();
                services.AddScoped<IRepository<Session>, Repository<Session>>();
                services.AddScoped<IRepository<Registration>, RegistrationRepository>();

                services.AddScoped<IAttendeeService, AttendeeService>();
                services.AddScoped<IConferenceService, ConferenceService>();
                services.AddScoped<IRegistrationService, RegistrationService>();

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
                // Non-development service configuration
                services.AddDbContext<ConferenceContext>(options =>
                    options.UseSqlServer(this._configuration.GetConnectionString("DefaultConnection")));
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                services.AddScoped<IRepository<Attendee>, Repository<Attendee>>();
                services.AddScoped<IRepository<Conference>, ConferenceRepository>();
                services.AddScoped<IRepository<Session>, Repository<Session>>();
                services.AddScoped<IRepository<Registration>, RegistrationRepository>();

                services.AddScoped<IAttendeeService, AttendeeService>();
                services.AddScoped<IConferenceService, ConferenceService>();
                services.AddScoped<IRegistrationService, RegistrationService>();

                // Auto Mapper Configurations
                var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new MappingProfile());
                    });

                IMapper mapper = mappingConfig.CreateMapper();
                services.AddSingleton(mapper);
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
