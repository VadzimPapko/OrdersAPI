using Golubovich.OrdersAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Golubovich.OrdersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {

        private static List<Product> Products = new List<Product>
        {
            new Product { Id=1, Name = "1984", Price = 10, Quantity=2 },
            new Product { Id=2, Name = "Animal Farm", Price = 6, Quantity=3},
            new Product { Id=3, Name = "The pedestrian", Price =7, Quantity=1},
            new Product { Id=4, Name = "All summer in a day", Price=5, Quantity=4},
        };

        [HttpGet("/getAllProducts")]
        public ActionResult<List<Product>> GetAllProducts()
        {
            return Products;
        }

        [HttpGet("/getProductById")]
        public ActionResult<Product> GetProductById(int id)
        {
            try
            {
                var productById = Products.Where(x => x.Id==id).First();
                
                return Ok(productById);
            }
            catch  (Exception)
            {
                return BadRequest(new { desctiption = $"Product with id = {id} doesn't exist"});
            }
        }

        [HttpPost]
        [Route("/addNewProduct")]
        public ActionResult AddNewProduct(ProductDto productDto)
        {
            var checkProduct = Products.Where(x => x.Name == productDto.Name).FirstOrDefault();

            if (checkProduct == null)
            {
                var newProduct = new Product
                {
                    Id = Products.Max(x => x.Id) +1,
                    Name = productDto.Name,
                    Price = productDto.Price,
                    Quantity = productDto.Quantity
                };

                Products.Add(newProduct);

                return Ok(Products);
            }
            else
            {
                return BadRequest(new { description = $"Product with name {productDto.Name} already exists"});
            }
        }

        [HttpPatch]
        [Route("/update")]
        public ActionResult UpdateProduct(int id, ProductDto productDto)
        {
            var product = Products.Where(x => x.Id == id).FirstOrDefault();

            if (product != null)
            {
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.Quantity = productDto.Quantity;
                return Ok(Products);
            }
            else
            {
                return BadRequest(new {description = $"Product with id = {id} doesn't exist" });
            }
        }
    }
}
