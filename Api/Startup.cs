using Api.Models;
using Api.Models.OData.Actions;
using Api.Models.OData.Functions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using System.Linq;

namespace Api
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            services.AddOData();

            services.AddControllers();
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
                endpoints.Select().Expand().OrderBy().MaxTop(100).Count().Filter();

                endpoints.MapODataRoute("ODataRoute", "odata", GetEdmModel());

                endpoints.MapControllers();
            });
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Category>("Categories");
            builder.EntitySet<Manufacturer>("Producers");
            builder.EntitySet<Vehicle>("Vehicles");

            #region Actions
            builder.EntityType<Category>().Action("TotalVehiclesByCategory").Returns<int>();
            builder.EntityType<Category>().Collection.Action("TotalCategoryCount").Returns<int>();
            builder.EntityType<Category>().Action("VehicleCountByManufacturer").Returns<int>().Parameter<int>("ManufacturerId");
            
            var actionTotal = builder.EntityType<Category>().Action("VehicleCountByYearManufacturer").Returns<int>();
            actionTotal.Parameter<int>("ManufacturerId");
            actionTotal.Parameter<int>("Year");

            builder.EntityType<Category>().Action("VehicleHpByManufacturer").Returns<int>().Parameter<ActionForCategory>("ActionForCategory");
            #endregion

            #region Function
            // Bound Functions
            builder.EntityType<Category>().Collection.Function("VehicleCounts").Returns<IQueryable<VehicleCountForCategory>>();

            var functionYear = builder.EntityType<Category>().Function("CalculateVehicleAge").Returns<IQueryable<YearForVehicle>>();
            functionYear.Parameter<int>("ManufacturerId");
            functionYear.Parameter<int>("Year");

            // Unbound Functions
            builder.Function("GetTaxRateByCountry").Returns<double>().Parameter<string>("Country");
            #endregion

            return builder.GetEdmModel();
        }
    }
}
