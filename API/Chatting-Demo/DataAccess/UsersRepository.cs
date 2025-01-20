namespace Chatting_Demo.DataAccess
{
    public class UsersRepository : IUserRepository
    {
        private List<string> Users = new();

        public List<string> RegisterUser(string userName)
        {
            if (Users.Any(user => user.ToLower() == userName.ToLower()))
            {
                throw new Exception("duplicated name");
            }            
            Users.Add(userName);
            return Users;
        }
    }
}
