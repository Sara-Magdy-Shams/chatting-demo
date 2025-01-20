namespace Chatting_Demo.DataAccess
{
    public interface IUserRepository
    {
        List<string> RegisterUser(string userName);
    }
}
