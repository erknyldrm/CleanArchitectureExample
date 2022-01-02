using CleanArchitecture.Application.Wrappers;
using MediatR;

namespace CleanArchitecture.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description{ get; set; }
        public decimal Rate { get; set; }
    }
}
