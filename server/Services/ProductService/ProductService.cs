using System.Collections.Generic;
using AutoMapper;
using server.DataAccess.Repositories.ProductRepo;
using server.Dtos.ProductDto;
using server.Models;

namespace Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public ProductReadDto AddNewProduct(ProductCreateDto productCreateDto)
        {
            var newProductModel = this._mapper.Map<Product>(productCreateDto);

            this._repository.Add(newProductModel);
            this._repository.SaveChanges();

            var productReadDto = this._mapper.Map<ProductReadDto>(newProductModel);

            return productReadDto;
        }

        public bool DeleteProduct(int id)
        {
            Product product = this._repository.GetById(id);
            if (product == null) return false;

            this._repository.Remove(product);
            this._repository.SaveChanges();

            return true;
        }

        public IEnumerable<ProductReadDto> GetAllProduct()
        {
            var products = this._repository.GetAll();
            if (products == null) return null;

            var productReadDtos = this._mapper.Map<IEnumerable<ProductReadDto>>(products);

            return productReadDtos;
        }

        public ProductReadDto GetProductById(int id)
        {
            Product product = this._repository.GetById(id);
            if (product == null) return null;

            var productReadDto = this._mapper.Map<ProductReadDto>(product);

            return productReadDto;
        }

        public bool UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            Product existingProduct = this._repository.GetById(id);
            if (existingProduct == null) return false;

            this._mapper.Map(productUpdateDto, existingProduct);

            this._repository.Update(existingProduct);
            this._repository.SaveChanges();

            return true;
        }
    }
}