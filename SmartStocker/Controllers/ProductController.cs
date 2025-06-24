using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartStocker.Models.DTOs;
using SmartStocker.Models.Entities;
using SmartStocker.Services;

namespace SmartStocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(ProductService product, IMapper mapper) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var result = await product.GetTById(id);
                if (result == null) return NotFound("model was null");
                return Ok(result);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.InnerException);
            }
            catch (ArgumentException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("inactive/{id}")]
        public async Task<IActionResult> GetProductInactive()
        {
            try
            {
                var result = await product.GetTInative();
                if (result == null) return NotFound("model was null");
                return Ok(result);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.InnerException);
            }
            catch (ArgumentException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet] 
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var result = await product.GetT();
                if (result == null) return NotFound("model was null");
                return Ok(result);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.InnerException);
            }
            catch (ArgumentException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var result = await product.DeleteT(id);
                if (result == null) return NotFound("model was null");
                return Ok(result);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.InnerException);
            }
            catch (ArgumentException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] DTOCreateProduct model)
        { 
            try
            {
                var mapped = mapper.Map<Product>(model);
                mapped.IsActive = true;

                var result = await product.CreateT(mapped);
                if (result == null) return NotFound("model was null");
                return Ok(result);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.InnerException);
            }
            catch (ArgumentException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateProduct([FromBody] Product model)
        {
            try
            {
                var result = await product.UpdateT(model);
                if (result == null) return NotFound("models was null");
                return Ok(result);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.InnerException);
            }
            catch(ArgumentException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
