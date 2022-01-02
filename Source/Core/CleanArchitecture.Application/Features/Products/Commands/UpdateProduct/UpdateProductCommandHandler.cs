using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<int>>
    {
        private readonly IProductRepositoryAsync _productRepository;

        public UpdateProductCommandHandler(IProductRepositoryAsync productRepository) => _productRepository = productRepository;
        

        public async Task<Response<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApiException("Product Not Found");
            }
            else
            {
                product.Name = request.Name;
                product.Rate = request.Rate;
                product.Description = request.Description;

                await _productRepository.UpdateAsync(product);
                return new Response<int>(product.Id);
            }
        }
    }
}
