using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Wrappers;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<Product>>
    {
        private readonly IProductRepositoryAsync _productRepository;

        public GetProductByIdQueryHandler(IProductRepositoryAsync productRepository) => _productRepository = productRepository;        

        
        public async Task<Response<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null) throw new ApiException($"Product Not Found.");
            return new Response<Product>(product);
        }
    }
}
