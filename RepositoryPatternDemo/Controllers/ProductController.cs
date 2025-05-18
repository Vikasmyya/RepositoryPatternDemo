using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Abstract.UnitOfWork;
using RepositoryPatternDemo.Data.Models;

namespace RepositoryPatternDemo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _unitOfWork.Product.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Create(Product product)
        {
            await _unitOfWork.Product.AddAsync(product);
            await _unitOfWork.SaveChnages();
            return Ok(product);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Update(Product prouct)
        {
            var products = await _unitOfWork.Product.GetByIdAsync(prouct.Id);

            if (products != null)
            {
                _unitOfWork.Product.UpdateAsync(prouct);
                await _unitOfWork.SaveChnages();
                return Ok();
            }
            else
            {
                return BadRequest();
            }    
            
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> Delete(Product prouct)
        {
            var products = await _unitOfWork.Product.GetByIdAsync(prouct.Id);

            if (products != null)
            {
                _unitOfWork.Product.DeleteAsync(prouct);
                await _unitOfWork.SaveChnages();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("expensive")]
        public async Task<IActionResult> GetExpensive(decimal price)
        {
            var expensive = await _unitOfWork.Product.GetExpensiveProducts(price);
            return Ok(expensive);
        }


    }
}
