using Api.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{
    [ODataRoutePrefix("producers")]
    public class ManufacturersController : ODataController
    {
        private readonly AppDbContext _dbContext;
        public ManufacturersController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ODataRoute]
        [EnableQuery(PageSize = 2)]
        public IActionResult Get()
        {
            return Ok(_dbContext.Manufacturers);
        }

        [EnableQuery]
        [ODataRoute("({producerId})")]
        public IActionResult GetSingleManufacturer([FromODataUri] int producerId)
        {
            return Ok(_dbContext.Manufacturers.Where(w => w.Id == producerId));
        }

        [EnableQuery]
        [ODataRoute("({producerId})/vehicles({categoryId})")]
        public IActionResult GetVehiclesBy([FromODataUri]int producerId, [FromODataUri]int categoryId)
        {
            return Ok(_dbContext.Vehicles.Where(w => w.ManufacturerId == producerId && w.CategoryId == categoryId));
        }
    }
}
