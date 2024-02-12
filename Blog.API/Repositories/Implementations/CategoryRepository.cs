using Blog.API.Data;
using Blog.API.Models.Domain;
using Blog.API.Repositories.Interface;

namespace Blog.API.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();

            return category;
        }
    }
}
