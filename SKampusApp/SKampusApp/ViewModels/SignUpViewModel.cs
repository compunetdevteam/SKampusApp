using SKampusApp.Models;
using SwiftKampusMobile.Services;
using System.Threading.Tasks;

namespace SKampusApp.ViewModels
{
    public class SignUpViewModel
    {
        public async Task<SignUpModel> SearchStudent(string Id)
        {
            var signUpService = new StudentServices();
            var result = await signUpService.SearchStudentAsync(Id);
            return result;
            //await _navigation.PushAsync(new RegisterStudent());
        }

        public async Task<string> RegisterStudent(RegisterModel model)
        {
            var signUpService = new StudentServices();
            var result = await signUpService.RegisterStudentAsync(model);
            return result;
            //await _navigation.PushAsync(new RegisterStudent());
        }

    }
}
