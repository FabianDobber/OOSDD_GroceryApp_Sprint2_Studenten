using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClientService _clientService;
        public AuthService(IClientService clientService)
        {
            _clientService = clientService;
        }
        public Client? Login(string email, string password)
        {

            var Client = _clientService.Get(email);
            if (Client != null)
            {
                bool passwordMatch = PasswordHelper.VerifyPassword(password, Client.password);
                if (passwordMatch)
                {
                    return Client;
                }
            }
            return null;

        }
    }
}
