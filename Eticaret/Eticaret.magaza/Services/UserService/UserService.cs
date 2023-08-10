using Eticaret.Model;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Magaza.Services
{
    public class UserService : IUserService
    {
        private readonly MainDatabaseContext _context;

        public UserService(MainDatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Login model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Login>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Login?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Login model)
        {
            throw new NotImplementedException();
        }

        public async Task<int> LoginAsync(Login model)
        {
            // SELECT * FROM User WHERE Email = '' AND Password = ''
            Login? user = await _context.User.SingleOrDefaultAsync(
                m => m.Email == model.Email &&
                m.Password == model.Password);

            
            if (user != null)
                return user.Id;

            return 0;
        }
    }
}
