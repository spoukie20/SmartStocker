using Microsoft.AspNetCore.Mvc;
using SmartStocker.Services;

namespace SmartStocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(ProductService product) : ControllerBase
    {
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery]int productId = 0)
        {
            try
            {
                
                return Ok(await product.GetT(productId));
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

    }
}
