using Blog.API.Data;
using Blog.API.Models.Domain;
using Blog.API.Models.DTO;
using Blog.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

       

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await _categoryRepository.CreateAsync(category);
;
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

    }
}
