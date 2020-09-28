using Ecommerce.Business.Dto;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface ILoginService
    {
        Task<TokenDtoResponse> GetToken(SignInDto signUpDto);
    }
}
