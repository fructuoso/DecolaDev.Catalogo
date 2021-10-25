using AutoMapper;
using DecolaDev.Catalogo.Domain.Core.Interfaces.Repository;
using DecolaDev.Catalogo.Domain.Core.Interfaces.Service;
using DecolaDev.Catalogo.Domain.Services;
using DecolaDev.Catalogo.Infra.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace DecolaDev.Catalogo.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DecolaDev.Catalogo", Version = "v1" });
            });
            #endregion

            #region DbContext
            services.AddDbContext<RepositoryContext>(options => options.UseInMemoryDatabase(databaseName: $"DecolaDev.Catalogo_DB_{Guid.NewGuid()}"));
            #endregion

            #region Dependency Injectionn
            services.AddTransient(typeof(IServiceCrud<,>), typeof(GenericServiceCrud<,>));
            services.AddTransient(typeof(IRepositoryCrud<,>), typeof(GenericRepositoryCrud<,>));
            #endregion

            #region AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                ).AddFluentValidation(f => f.RegisterValidatorsFromAssembly(typeof(Startup).Assembly));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });
            #endregion

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
