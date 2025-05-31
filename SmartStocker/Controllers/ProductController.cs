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
        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var result = await product.GetTById(id);
                if (result == null) throw new Exception("Results where null");
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("inactive/id")]
        public async Task<IActionResult> GetProductInactive()
        {
            try
            {
                var result = await product.GetTInative();
                if (result == null) throw new Exception("Results where null");
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet] 
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var result = await product.GetT();
                if (result == null) throw new Exception("Results where null");
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("id")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var result = await product.DeleteT(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(DTOCreateProduct model)
        { 
            try
            {
                var mapped = mapper.Map<Product>(model);
                mapped.Inactive = true;

                var result = await product.CreateT(mapped);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("id")]
        public async Task<IActionResult> UpdateProduct(Product model)
        {
            try
            {
                var result = await product.UpdateT(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
