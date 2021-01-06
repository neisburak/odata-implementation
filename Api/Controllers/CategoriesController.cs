using Api.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models.OData.Actions;
using Api.Models.OData.Functions;
using System.Linq;
using System;

namespace Api.Controllers
{
    public class CategoriesController : ODataController
    {
        private readonly AppDbContext _dbContext;
        public CategoriesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_dbContext.Categories);
        }

        [EnableQuery]
        [ODataRoute("categories({categoryId})/vehicles")]
        public IActionResult GetProductsByCategoryId([FromODataUri] int categoryId)
        {
            return Ok(_dbContext.Vehicles.Where(w => w.CategoryId == categoryId));
        }

        #region CRUD
        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_dbContext.Categories.Where(w => w.Id == key));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return Created(category);
        }

        [HttpPut]
        public IActionResult Put([FromODataUri] int key, [FromBody] Category category)
        {
            category.Id = key;
            _dbContext.Entry(category).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return Updated(category);
        }

        [HttpDelete]
        public IActionResult Delete([FromODataUri] int key)
        {
            var categoryToDelete = _dbContext.Categories.Find(key);
            if (categoryToDelete == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(categoryToDelete);
            _dbContext.SaveChanges();

            return NoContent();
        }
        #endregion

        #region Actions
        [HttpPost]
        public IActionResult TotalVehiclesByCategory([FromODataUri] int key)
        {
            var total = _dbContext.Vehicles.Where(w => w.CategoryId == key).Count();

            return Ok(total);
        }

        [HttpPost]
        public IActionResult TotalCategoryCount()
        {
            var count = _dbContext.Categories.Count();

            return Ok(count);
        }

        [HttpPost]
        public IActionResult VehicleCountByManufacturer([FromODataUri] int key, ODataActionParameters parameters)
        {
            var manufacturerId = (int)parameters["ManufacturerId"];

            var vehicles = _dbContext.Vehicles.Where(w => w.CategoryId == key && w.ManufacturerId == manufacturerId).Count();

            return Ok(vehicles);
        }

        [HttpPost]
        public IActionResult VehicleCountByYearManufacturer([FromODataUri] int key, ODataActionParameters parameters)
        {
            var manufacturerId = (int)parameters["ManufacturerId"];
            var year = (int)parameters["Year"];

            var vehicles = _dbContext.Vehicles.Where(w => w.CategoryId == key && w.ManufacturerId == manufacturerId && w.Year
             == year).Count();

            return Ok(vehicles);
        }

        [HttpPost]
        public IActionResult VehicleHpByManufacturer([FromODataUri] int key, ODataActionParameters parameters)
        {
            var actionForCategory = parameters["ActionForCategory"] as ActionForCategory;

            var vehicles = _dbContext.Vehicles.Where(w => w.CategoryId == key && w.ManufacturerId == actionForCategory.ManufacturerId && w.Engine >= actionForCategory.Engine).Count();

            return Ok(vehicles);
        }
        #endregion

        #region Functions
        #region Bound Functions
        [HttpGet]
        public IActionResult VehicleCounts()
        {
            var vehiclesCount = _dbContext.Vehicles.GroupBy(g => g.Category.Name).Select(s => new VehicleCountForCategory { Category = s.Key, VehicleCount = s.Count() });

            return Ok(vehiclesCount);
        }

        [HttpGet]
        public IActionResult CalculateVehicleAge([FromODataUri] int key, [FromODataUri] int ManufacturerId, [FromODataUri] int Year)
        {
            var vehiclesCount = _dbContext.Vehicles.Where(w => w.CategoryId == key && w.ManufacturerId == ManufacturerId && w.Year >= Year).Select(s => new YearForVehicle
            {
                Id = s.Id,
                Model = s.Model,
                Age = DateTime.Today.Year - s.Year
            });

            return Ok(vehiclesCount);
        }
        #endregion

        #region Unbound Functions
        [HttpGet]
        [ODataRoute("GetTaxRateByCountry(Country={country})")]
        public IActionResult GetTaxRateByCountry([FromODataUri] string country)
        {
            var taxRate = 0.18; //Örnek için veri
            return Ok(taxRate);
        }
        #endregion
        #endregion
    }
}
