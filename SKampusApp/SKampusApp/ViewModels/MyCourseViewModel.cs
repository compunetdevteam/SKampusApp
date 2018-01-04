using SKampusApp.Models;
using SKampusApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SKampusApp.ViewModels
{
    public class MyCourseViewModel : INotifyPropertyChanged
    {
        private MyCourseModel _selectedCourse = new MyCourseModel();

        public ObservableCollection<MyCourseModel> _courseRegs { get; set; }

        public ObservableCollection<MyCourseModel> CourseRegs
        {
            get { return _courseRegs; }
            set
            {
                _courseRegs = value;
                OnPropertyChanged();
            }

        }
        public MyCourseModel SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;
                OnPropertyChanged();
            }
        }

        public string StudentId { get; set; }

        ///public List<CourseReg> SelectedCourseRegs { get; set; }





        public MyCourseViewModel(string studentId)
        {
            GenerateList(studentId);

        }


        private async void GenerateList(string studentId)
        {
            var service = new CourseRegService();
            var model = await service.GetMyCourseAsync(studentId);
            StudentId = studentId;

            CourseRegs = new ObservableCollection<MyCourseModel>();
            foreach (var course in model)
            {
                CourseRegs.Add(course);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
