using CleanArchitecture.Application.DTOs.Email;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
