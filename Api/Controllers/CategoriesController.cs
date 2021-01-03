using Api.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

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
    }
}
