using Eticaret.Magaza.Services;
using Eticaret.Model;

namespace Eticaret.magaza.Services
{
    public interface IUserService: IBaseService<Login>
    {
        Task<int> LoginAsync(Login model);
    }
}
