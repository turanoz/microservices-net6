using AutoMapper;
using Catalog.Api.Dtos;
using Catalog.Api.Models;
using Catalog.Api.Settings;
using MassTransit;
using MongoDB.Driver;
using Shared.Dtos;
using Shared.Messages;

namespace Catalog.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings, IPublishEndpoint publishEndpoint)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;

            _publishEndpoint = publishEndpoint;
        }


        public async Task<Shared.Dtos.Response<List<ProductDto>>> GetAllAsync()
        {
            var products = await _productCollection.Find(product => true).ToListAsync();

            if (products.Any())
            {
                foreach (var product in products)
                {
                    product.Category = await _categoryCollection.Find<Category>(x => x.Id == product.CategoryId)
                        .FirstAsync();
                }
            }
            else
            {
                products = new List<Product>();
            }

            return Shared.Dtos.Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
        }


        public async Task<Shared.Dtos.Response<List<ProductDto>>> GetAllByCategoryIdAsync(string id)
        {
            var products = await _productCollection.Find(product => product.CategoryId == id).ToListAsync();
            
            return Shared.Dtos.Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
        }

        public async Task<Shared.Dtos.Response<ProductDto>> GetByIdAsync(string id)
        {
            var product = await _productCollection.Find<Product>(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return Shared.Dtos.Response<ProductDto>.Fail("Product not found", 404);
            }

            product.Category = await _categoryCollection.Find<Category>(x => x.Id == product.CategoryId).FirstAsync();

            return Shared.Dtos.Response<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
        }

        public async Task<Shared.Dtos.Response<ProductDto>> CreateAsync(ProductCreateDto productCreateDto)
        {
            var newProduct = _mapper.Map<Product>(productCreateDto);

            newProduct.Created = DateTime.Now;
            await _productCollection.InsertOneAsync(newProduct);

            return Shared.Dtos.Response<ProductDto>.Success(_mapper.Map<ProductDto>(newProduct), 200);
        }

        public async Task<Shared.Dtos.Response<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var updateProduct = _mapper.Map<Product>(productUpdateDto);

            var result =
                await _productCollection.FindOneAndReplaceAsync(x => x.Id == productUpdateDto.Id, updateProduct);

            if (result == null)
            {
                return Shared.Dtos.Response<NoContent>.Fail("Product not found", 404);
            }

            await _publishEndpoint.Publish<ProductNameChangedEvent>(new ProductNameChangedEvent
                { ProductId = updateProduct.Id, UpdatedName = productUpdateDto.Name });

            return Shared.Dtos.Response<NoContent>.Success(204);
        }

        public async Task<Shared.Dtos.Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _productCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount > 0)
            {
                return Shared.Dtos.Response<NoContent>.Success(204);
            }
            else
            {
                return Shared.Dtos.Response<NoContent>.Fail("Product not found", 404);
            }
        }
    }
}