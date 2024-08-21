using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Contract.Services.IService;
using Task = System.Threading.Tasks.Task;

namespace XuongMay_BE.Services.Service
{
    public class ProductService : IProductService
    {
        public readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(Product product)
        {
            // Check if the Category already exists in the database
            IGenericRepository<Category> categoryRepository = _unitOfWork.GetGenericRepository<Category>();
            var existingCategory = await categoryRepository.GetByIdAsync(product.CategoryId);

            if (existingCategory != null)
            {
                // If the Category exists, use the existing one
                product.Category = existingCategory;
            }
            else
            {
                // If the Category doesn't exist, create a new one
                var newCategory = new Category
                {
                    Id = product.CategoryId, // Assuming CategoryId is provided in product
                    Name = product.Category.Name             // Set other properties if necessary
                };

                // Add the new Category to the repository
                await categoryRepository.AddAsync(newCategory);
                product.Category = newCategory;
            }

            // Assign a new Guid to the product
            product.Id = Guid.NewGuid().ToString("N");

            // Add the Product to the repository
            IGenericRepository<Product> productRepository = _unitOfWork.GetGenericRepository<Product>();
            await productRepository.AddAsync(product);

            // Save all changes (both Product and potentially new Category)
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(object id)
        {
            IGenericRepository<Product> genericRepository = _unitOfWork.GetGenericRepository<Product>();
            await genericRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public Task<IList<Product>> GetAll()
        {
            return _unitOfWork.GetGenericRepository<Product>().GetAllAsync();
        }

        public Task<Product?> GetById(object id)
        {
            return _unitOfWork.GetGenericRepository<Product>().GetByIdAsync(id);
        }

        public async Task Update(Product product)
        {
            IGenericRepository<Product> genericRepository = _unitOfWork.GetGenericRepository<Product>();
            await genericRepository.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
        }

    }
}