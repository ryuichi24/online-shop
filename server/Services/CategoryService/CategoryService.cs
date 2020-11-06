using System.Collections.Generic;
using AutoMapper;
using server.DataAccess.Repositories.CategoryRepo;
using server.Dtos.CategoryDto;
using server.Models;

namespace Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public CategoryReadDto AddNewCategory(CategoryCreateDto categoryCreateDto)
        {
            var newCategory = this._mapper.Map<Category>(categoryCreateDto);

            this._repository.Add(newCategory);
            this._repository.SaveChanges();

            var categoryReadDto = this._mapper.Map<CategoryReadDto>(newCategory);

            return categoryReadDto;
        }

        public bool DeleteCategory(int id)
        {
            Category category = this._repository.GetById(id);
            if (category == null) return false;

            this._repository.Remove(category);
            this._repository.SaveChanges();

            return true;
        }

        public IEnumerable<CategoryReadDto> GetAllCategories()
        {
            var categories = this._repository.GetAll();
            if (categories == null) return null;

            var categoryReadDtos = this._mapper.Map<IEnumerable<CategoryReadDto>>(categories);
            return categoryReadDtos;
        }

        public CategoryReadDto GetCategoryById(int id)
        {
            Category category = this._repository.GetById(id);
            if (category == null) return null;

            var categoryReadDto = this._mapper.Map<CategoryReadDto>(category);
            return categoryReadDto;

        }

        public bool UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
        {
            Category existingCategory = this._repository.GetById(id);
            if (existingCategory == null) return false;

            this._mapper.Map(categoryUpdateDto, existingCategory);

            this._repository.Update(existingCategory);
            this._repository.SaveChanges();

            return true;
        }
    }
}