using SKampusApp.Models;
using SKampusApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SKampusApp.ViewModels
{
    public class TopicViewModel : INotifyPropertyChanged
    {
        private TopicModel _selectedTopic = new TopicModel();

        public ObservableCollection<TopicModel> _topics { get; set; }

        public ObservableCollection<TopicModel> Topics
        {
            get { return _topics; }
            set
            {
                _topics = value;
                OnPropertyChanged();
            }

        }
        public TopicModel SelectedModule
        {
            get { return _selectedTopic; }
            set
            {
                _selectedTopic = value;
                OnPropertyChanged();
            }
        }
        public string StudentId { get; set; }


        public TopicViewModel(int moduleId)
        {
            GenerateList(moduleId);
        }


        private async void GenerateList(int moduleId)
        {
            var service = new CourseRegService();
            var model = await service.GetTopicsAsync(moduleId);
            //StudentId = studentId;

            Topics = new ObservableCollection<TopicModel>();
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
