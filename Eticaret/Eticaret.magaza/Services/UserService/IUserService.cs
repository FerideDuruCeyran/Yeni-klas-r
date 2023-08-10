using Eticaret.Model;

namespace Eticaret.Magaza.Services
{
    public interface IUserService : IBaseService<Login>
    {
        Task<int> LoginAsync(Login model);
    }
}
