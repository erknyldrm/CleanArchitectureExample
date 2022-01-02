using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArhitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CleanArhitecture.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> _products;
        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext) => _products = dbContext.Set<Product>();

        public Task<bool> IsUniqueBarcodeAsync(string barcode)
        {
            return _products.AllAsync(p => p.Barcode != barcode);
        }
    }
}
