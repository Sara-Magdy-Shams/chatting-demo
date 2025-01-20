using Chatting_Demo.DataAccess;
using Chatting_Demo.Signal_R;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chatting_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserRepository usersRepository, ChattingClient chattingClient, ILogger<UsersController> logger) : ControllerBase
    {

        [HttpPost]
        public async Task<List<string>> Post([FromBody] string userName)
        {
            try
            {
                var users = usersRepository.RegisterUser(userName);
                await chattingClient.NotifyNewUser(userName);
                return users;
            }
            catch (Exception ex)    
            {
                logger.LogError(ex.Message);
                return new List<string>();
            }
        }
    }
}
