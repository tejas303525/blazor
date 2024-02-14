using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Blazored.SessionStorage;
namespace proj1.Shared
{
    public class UserService
    {

        public List<UserHardcodedAccount> _users = new List<UserHardcodedAccount>();
        private int nextId = 1;
        public async void AddUser(UserHardcodedAccount user)
        {
            user.Id = nextId++;
            _users.Add(user);


        }
        public List<UserHardcodedAccount> GetUsers()
        {
            return _users;
        }

        public void UpdateUser(UserHardcodedAccount user)
        {
            var index = _users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                _users[index] = user;
            }
        }
        public void Ondelete(UserHardcodedAccount user)
        {
            _users.Remove(user);
        }
        public UserHardcodedAccount GetUserById(int id)
        {
            return _users.Find(u => u.Id == id);
        }

        public UserHardcodedAccount GetUserByUsername(string username)
        {
            return _users.Find(u => u.Username == username);
        }




    }
}