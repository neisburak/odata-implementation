using Api.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ManufacturersController : ODataController
    {
        private readonly AppDbContext _dbContext;
        public ManufacturersController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [EnableQuery(PageSize = 2)]
        public IActionResult Get()
        {
            return Ok(_dbContext.Manufacturers);
        }
    }
}
