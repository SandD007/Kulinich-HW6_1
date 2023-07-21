using Microsoft.AspNetCore.Mvc;

namespace HW6_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListOfProductsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Cucumber", "Milk", "Apple", "Ice", "Vodka", "Orange", "Pen", "Potato", "Car", "Shotgun"
    };

        private readonly ILogger<ListOfProductsController> _logger;

        public ListOfProductsController(ILogger<ListOfProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetListOfProduct")]
        public IEnumerable<ListOfProduct> Get()
        {
            return Enumerable.Range(1, 10).Select(index => new ListOfProduct
            {
                Date = DateTime.Now.AddDays(index),
                NameOfShop = "SandShop",
                List = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}