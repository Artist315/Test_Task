using MasterData.CounterTrends;
using MasterData.Trends;
using MasterData.ParameterTrends;
using MasterData.Units;
using MasterData.Equipments;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using AutoMapper;
using Extensions;
using ProleiT.OeeBaseClassifiers.Storage;
using FluentValidation;

namespace MasterData.App
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDb<MasterDataContext>(Configuration);

            services.AddControllers();

            services.AddScoped<ICounterTrendManager, CounterTrendManager>();
            services.AddScoped<ITrendManager, TrendManager>();
            services.AddScoped<IParameterTrendManager, ParameterTrendManager>();
            services.AddScoped<IUnitManager, UnitManager>();
            services.AddScoped<IEquipmentManager, EquipmentManager>();

            #region Validators

            services.AddTransient<IValidator<CreateEquipmentRequest>, CreateEquipmentRequestValidator>();
            services.AddTransient<IValidator<UpdateEquipmentRequest>, UpdateEquipmentRequestValidator>();

            services.AddTransient<IValidator<CreateUnitRequest>, CreateUnitRequestValidator>();
            services.AddTransient<IValidator<UpdateUnitRequest>, UpdateUnitRequestValidator>();

            services.AddTransient<IValidator<UpdateCounterTrendRequest>, UpdateCounterTrendRequestValidator>();
            services.AddTransient<IValidator<CreateCounterTrendRequest>, CreateCounterTrendRequestValidator>();

            services.AddTransient<IValidator<UpdateTrendRequest>, UpdateTrendRequestValidator>();
            services.AddTransient<IValidator<CreateTrendRequest>, CreateTrendRequestValidator>();

            services.AddTransient<IValidator<UpdateParameterTrendRequest>, UpdateParameterTrendRequestValidator>();
            services.AddTransient<IValidator<CreateParameterTrendRequest>, CreateParameterTrendRequestValidator>();

            #endregion Validators
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
