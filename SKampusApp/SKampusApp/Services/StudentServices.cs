using SKampusApp.Models;
using SKampusApp.RestClient;
using System.Threading.Tasks;

namespace SwiftKampusMobile.Services
{
    public class StudentServices
    {
        public async Task<SignUpModel> SearchStudentAsync(string search)
        {
            RestClient<Login> restClient = new RestClient<Login>("AccountApi/SignUp");
            var result = await restClient.SearchStudent(search);
            return result;
        }

        public async Task<string> RegisterStudentAsync(RegisterModel model)
        {
            RestClient<Login> restClient = new RestClient<Login>("AccountApi/RegisterStudent/");
            var result = await restClient.RegisterStudent(model);
            return result;
        }

        public async Task<StudentDashboard> StudentDashboardAsync(string studentId)
        {
            RestClient<StudentDashboard> restClient = new RestClient<StudentDashboard>("StudentApi/Dashboard/");
            var result = await restClient.StudentDashBoard(studentId);
            return result;
        }
    }
}
