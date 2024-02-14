using proj1.Shared;

namespace proj1.Server.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> useraccount;



        public UserAccountService()
        {
            useraccount = new List<UserAccount>
            {
                new() {
                    UserName = "admin", Password = "admin", Role = "Administrator"
                },
                new ()
                {
                    UserName = "user", Password = "user", Role = "User"
                },
            };
        }

        public void AddUser(UserHardcodedAccount user)
        {
            var new_user = new UserAccount
            {
                UserName = user.Username,
                Password = user.Password,
                Role = user.Role
            };
            useraccount.Add(new_user);
        }

        public UserAccount? GetUserAccountByUserName(string userName)
        {
            return useraccount.FirstOrDefault(x => x.UserName == userName);
        }

    }
}