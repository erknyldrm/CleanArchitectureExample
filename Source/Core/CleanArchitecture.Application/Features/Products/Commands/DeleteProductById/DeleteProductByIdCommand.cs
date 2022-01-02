using CleanArchitecture.Application.Wrappers;
using MediatR;

namespace CleanArchitecture.Application.Features.Products.Commands.DeleteProductById
{
    public class DeleteProductByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
