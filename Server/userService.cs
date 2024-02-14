using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using proj1.Server.Authentication;
using proj1.Shared;
namespace proj1.Server
{
    public class userService
    {
        public List<UserHardcodedAccount> _users = new List<UserHardcodedAccount>();
        private readonly AppDbContext _context;

        public userService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserHardcodedAccount>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserHardcodedAccount> AddUser(UserHardcodedAccount user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserHardcodedAccount> UpdateUser(UserHardcodedAccount user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
            }
            return existingUser;
        }

        public async Task<UserHardcodedAccount> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

            }
            return user;


        }

        public static implicit operator userService(UserAccountService v)
        {
            throw new NotImplementedException();
        }
    }

}