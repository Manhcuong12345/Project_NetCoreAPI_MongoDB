using Microsoft.AspNetCore.Mvc;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Services;
using Project_NetCore_MongoDB.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_NetCore_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categorieService;
        public CategoriesController(ICategoriesService categorieService)
        {
            _categorieService = categorieService;
        }

        // GET: api/<CountriesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categorieService.GetAllAsync());
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var categories = await _categorieService.GetByIdAsync(id);

            var categorieDto = new CategoriesDto
            {
                Name = categories.Name

            };

            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categorieDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _categorieService.CreateAsync(categories);
            return CreatedAtAction(nameof(Get), new { id = categories.Id }, categories);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Categories categories)
        {
            var data = await _categorieService.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound($"Categories is not found!");
            }

            await _categorieService.UpdateAsync(id, categories);

            return CreatedAtAction(nameof(Get), new { id = categories.Id }, categories);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var categories = await _categorieService.GetByIdAsync(id);

            if (categories == null)
            {
                return NotFound($"Categories is not found!");
            }

            await _categorieService.DeleteAsync(id).ConfigureAwait(false);

            return Ok($"Categories with Id = {id} is deleted");
        }
    }
}

