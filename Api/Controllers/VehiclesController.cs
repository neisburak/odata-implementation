using Api.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{
    public class VehiclesController : ODataController
    {
        private readonly AppDbContext _dbContext;
        public VehiclesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_dbContext.Vehicles);
        }

        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_dbContext.Vehicles.Where(w => w.Id == key));
        }
    }
}
