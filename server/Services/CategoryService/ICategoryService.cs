using System.Collections.Generic;
using server.Dtos.CategoryDto;

namespace Services.CategoryService
{
    public interface ICategoryService
    {
        IEnumerable<CategoryReadDto> GetAllCategories();

        CategoryReadDto GetCategoryById(int id);

        bool DeleteCategory(int id);

        CategoryReadDto AddNewCategory(CategoryCreateDto categoryCreateDto);

        bool UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto);
    }
}