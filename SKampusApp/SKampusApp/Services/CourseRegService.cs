using SKampusApp.Models;
using SKampusApp.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SKampusApp.Services
{
    public class CourseRegService
    {
        public async Task<CourseRegModel> GetCourseRegAsync(string studentId)
        {
            RestClient<CourseRegModel> restClient = new RestClient<CourseRegModel>("CourseRegistrationApi/GetCourses/");
            var result = await restClient.GetCourseReg(studentId);
            return result;
        }

        public async Task<string> RegisterCourseRegAsync(CourseRegApi model)
        {
            RestClient<Login> restClient = new RestClient<Login>("CourseRegistrationApi/RegisterCourse/");
            var result = await restClient.RegisterCourseReg(model);
            return result;
        }

        public async Task<List<MyCourseModel>> GetMyCourseAsync(string studentId)
        {
            RestClient<MyCourseModel> restClient = new RestClient<MyCourseModel>("EClassroomApi/MyCourses/");
            var result = await restClient.GetMyCourses(studentId);
            return result;
        }

        public async Task<List<ModuleModel>> GetCourseModuleAsync(int courseId)
        {
            RestClient<MyCourseModel> restClient = new RestClient<MyCourseModel>("EClassroomApi/GetModules/");
            var result = await restClient.GetMyCourseModules(courseId);
            return result;
        }

        public async Task<IEnumerable<TopicModel>> GetTopicsAsync(int moduleId)
        {
            RestClient<TopicModel> restClient = new RestClient<TopicModel>("EClassroomApi/GetTopics/");
            var result = await restClient.GetTopics(moduleId);
            return result;
        }
    }
}
