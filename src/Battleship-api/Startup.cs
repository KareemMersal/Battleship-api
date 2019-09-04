using System;
using AutoMapper;
using BattleShip.Api;
using BattleShip.Api.AppStart;
using BattleShip.Api.Database;
using BattleShip.Api.Features.Games;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace Battleship_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
            Configuration = configuration;
            Log.Information($"ConfigureServices Completed");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCustomProblemDetailsMapping();
            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Constants.ApiVersion.V1, new Info() { Title = "Battle-Api", Version = Constants.ApiVersion.V1 });
            });
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IBoardRepository, BoardRepository>();

            services.AddDbContext<BattleShipDbContext>(options => options.UseInMemoryDatabase(databaseName: "Battleship"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseHealthChecks("/status");
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Battleship AP");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (exceptionHandlerFeature != null)
                        {
                            Log.Error(exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                        }

                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");

                    });
                });
            }
            app.UseHttpsRedirection();
            app.UseProblemDetails();
            app.UseMvc();
            loggerFactory.AddSerilog();

        }
    }
}
