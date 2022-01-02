using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Products.Commands.DeleteProductById
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Response<int>>
    {
        private readonly IProductRepositoryAsync _productRepository;

        public DeleteProductByIdCommandHandler(IProductRepositoryAsync productRepository) => _productRepository = productRepository;
        

        public async Task<Response<int>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product != null)
            {
                await _productRepository.DeleteAsync(product);
                return new Response<int>(product.Id);
            }
            else
                throw new ApiException("Product Not Found");
          
        }
    }
}
