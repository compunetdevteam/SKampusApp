using SKampusApp.Models;
using SKampusApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SKampusApp.ViewModels
{
    public class ModuleViewModel : INotifyPropertyChanged
    {
        private ModuleModel _selectedTopic = new ModuleModel();

        public ObservableCollection<ModuleModel> _topics { get; set; }

        public ObservableCollection<ModuleModel> Topics
        {
            get { return _topics; }
            set
            {
                _topics = value;
                OnPropertyChanged();
            }

        }
        public ModuleModel SelectedModule
        {
            get { return _selectedTopic; }
            set
            {
                _selectedTopic = value;
                OnPropertyChanged();
            }
        }
        public string StudentId { get; set; }


        public ModuleViewModel(int courseId)
        {
            GenerateList(courseId);
        }


        private async void GenerateList(int courseId)
        {
            var service = new CourseRegService();
            var model = await service.GetCourseModuleAsync(courseId);
            //StudentId = studentId;

            Topics = new ObservableCollection<ModuleModel>();
            foreach (var course in model)
            {
                Topics.Add(course);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
