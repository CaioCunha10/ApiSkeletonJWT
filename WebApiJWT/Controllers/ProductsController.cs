using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJWT.Entities;
using WebApiJWT.Repository;

namespace WebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly InterfaceProduct _InterfaceProduct;

        public ProductsController(InterfaceProduct interfaceProduct)
        {
            _InterfaceProduct = interfaceProduct;
        }

        [HttpGet("/api/List")]
        public async Task<IActionResult> List()
        {
            return Ok(await _InterfaceProduct.List());
        }

        [HttpPost("/api/Add")]
        public async Task<IActionResult> Add(ProductModel product)
        {
            try
            {
                await _InterfaceProduct.Add(product);
                return Ok("Ok");
            }
            catch (Exception ERRO)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar produto");
            }
        }

        [HttpPut("/api/Update")]
        public async Task<IActionResult> Update(ProductModel product)
        {
            try
            {
                await _InterfaceProduct.Update(product);
                return Ok("Ok");
            }
            catch (Exception ERRO)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar produto");
            }
        }

        [HttpGet("/api/GetEntityById")]
        public async Task<IActionResult> GetEntityById(int id)
        {
            var product = await _InterfaceProduct.GetEntityById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("/api/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _InterfaceProduct.GetEntityById(id);
                if (product == null)
                {
                    return NotFound();
                }
                await _InterfaceProduct.Delete(product);
                return Ok("Ok");
            }
            catch (Exception ERRO)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao excluir produto");
            }
        }
    }
}
