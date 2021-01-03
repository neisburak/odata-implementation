using Api.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

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
    }
}
