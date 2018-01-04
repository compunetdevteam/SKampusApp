using System.Threading.Tasks;
using SKampusApp.Models;
using SKampusApp.RestClient;

namespace SwiftKampusMobile.Services
{
    public class LoginServices
    {
        public async Task<StudentApi> LoginAsync(LoginModel login)
        {
            RestClient<Login> restClient = new RestClient<Login>("AccountApi/Login/");
            var result = await restClient.GetLogin(login);
            return result;
        }
    }
}
