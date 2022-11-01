//using Microsoft.AspNetCore.Mvc;
//using Project_NetCore_MongoDB.Models;
//using Project_NetCore_MongoDB.Services;
//using Project_NetCore_MongoDB.Dto;
//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Project_NetCore_MongoDB.Controllers
//{
//    [Route("api/products")]
//    [ApiController]
//    public class ProductsController : ControllerBase
//    {
//        private readonly IProductsService _productService;
//        private readonly ICategoriesService _categorieService;
//        private readonly IMapper _mapper;
//        public ProductsController(IProductsService productService, ICategoriesService categorieService, IMapper mapper)
//        {
//            _productService = productService;
//            _categorieService = categorieService;
//            _mapper = mapper;
//        }

//        [Authorize(Policy = "UserPolicy")]
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var products = await _productService.GetAllAsync().ConfigureAwait(false);

//            return Ok(products);
//        }

//        [HttpGet("{id:length(24)}")]
//        public async Task<IActionResult> Get(string id)
//        {
//            var data = await _productService.GetByIdAsync(id).ConfigureAwait(false);
//            data.Categories = await _categorieService.GetByIdAsync(data.CategoriesId);

//            //var dataProduct = _mapper.Map<ProductsDto>(data);

//            if (data == null)
//            {
//                return NotFound($"Product is not found!");
//            }
//            return Ok(data);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(Products products)
//        {
//            await _productService.CreateAsync(products);
//            return CreatedAtAction(nameof(Get), new { id = products.Id }, products);
//        }

//        [HttpPut("{id:length(24)}")]
//        public async Task<IActionResult> Update(string id, Products products)
//        {
//            var data = await _productService.GetByIdAsync(id).ConfigureAwait(false);
           
//            if (data == null)
//            {
//                return NotFound($"Product is not found!");
//            }

//            await _productService.UpdateAsync(id, products).ConfigureAwait(false);
//            //return NoContent();
//            return CreatedAtAction(nameof(Get), new { id = products.Id }, products);
//        }

//        [HttpDelete("{id:length(24)}")]
//        public async Task<IActionResult> Delete(string id)
//        {
//            var products = await _productService.GetByIdAsync(id).ConfigureAwait(false);
//            if (products == null)
//            {
//                return NotFound($"Product is not found!");
//            }
//            await _productService.DeleteAsync(id).ConfigureAwait(false);
//            return Ok($"Product with Id = {id} is deleted");
//        }
//    }
//}
