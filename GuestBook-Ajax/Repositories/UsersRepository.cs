using GuestBook_Ajax.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace GuestBook_Ajax.Repositories
{
    public class UsersRepository: IRepositoryUsers
    {
        private readonly GBContext _context;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        public UsersRepository(GBContext context)
        {
            _context = context;
        }
        public async Task<List<Users>> GetUsersList()
        {
            _semaphore.Wait();
            try
            {
                return await _context.Users.ToListAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public IQueryable<Users> CheckUser(LoginModel logon)
        {
            _semaphore.Wait();
            try
            {
                return _context.Users.Where(a => a.Login == logon.Login);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public IQueryable<Users> CheckRegisterUser(RegisterModel reg)
        {
            return _context.Users.Where(a => a.Login == reg.Login);
        }
        public async Task Create(Users u)
        {
            await _context.Users.AddAsync(u);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
