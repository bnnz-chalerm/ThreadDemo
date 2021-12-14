using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreadApiDemo;

namespace MyWebApi.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationContext _context;

        public UsersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task AddUser(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetCountByCountryCode(string countryCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetCountByCountryCodeAsAnsi(string countryCode)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            return await _context.User.Where(x=>x.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserDto>> GetUsersById(IEnumerable<int> userIds)
        {
            return await _context.User.Where(t => userIds.Contains(t.Id)).ToListAsync();
        }

        public Task InsertInBulk(IList<string> userNames)
        {
            throw new NotImplementedException();
        }

        public Task InsertMany(IEnumerable<string> userNames)
        {
            throw new NotImplementedException();
        }

        public Task SafeInsertMany(IEnumerable<string> userNames)
        {
            throw new NotImplementedException();
        }
    }
}
