using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriesController:BaseApiController
    {
        private readonly ICategoryReporistory _categoryRepository;
        public CategoriesController(ICategoryReporistory categoryReporistory)
        {
            _categoryRepository = categoryReporistory;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryType>>> GetAllCategories()
        {
            return Ok(await _categoryRepository.GetCategories());
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(CategoryType categoryType)
        {
            _categoryRepository.Add(categoryType);
            if (await _categoryRepository.SaveAllAsync()) return Ok();
            return BadRequest("Could not add new category");
        }

    }
}
