using SKampusApp.Models;
using SKampusApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SKampusApp.ViewModels
{
    public class CourseRegViewModel : INotifyPropertyChanged
    {
        private CourseReg _selectedCourseReg = new CourseReg();
        //public ObservableCollection<CourseReg> CourseRegs { get; set; }

        public ObservableCollection<CourseReg> _courseRegs { get; set; }

        public ObservableCollection<CourseReg> CourseRegs
        {
            get { return _courseRegs; }
            set
            {
                _courseRegs = value;
                OnPropertyChanged();
            }

        }
        public int AvailableCredit { get; set; }
        public string StudentId { get; set; }

        ///public List<CourseReg> SelectedCourseRegs { get; set; }
        public ObservableCollection<CourseReg> _selectedCourseRegs { get; set; }

        public ObservableCollection<CourseReg> SelectedCourseRegs
        {
            get { return _selectedCourseRegs; }
            set
            {
                _selectedCourseRegs = value;
                OnPropertyChanged();
            }

        }
        public CourseReg SelectedCourseReg
        {
            get { return _selectedCourseReg; }
            set
            {
                _selectedCourseReg = value;
                var isExit = SelectedCourseRegs.Any(x => x.CourseId.Equals(value.CourseId));
                if (!isExit)
                {
                    SelectedCourseRegs.Add(value);
                }
                //CourseRegs.Remove(value);
                OnPropertyChanged();
            }
        }
        public CourseReg DeSelectedCourseReg
        {
            get { return _selectedCourseReg; }
            set
            {
                _selectedCourseReg = value;
                SelectedCourseRegs.Remove(value);
                //CourseRegs.Remove(value);
                OnPropertyChanged();
            }
        }

        private void AddCourseReg()
        {
            SelectedCourseRegs.Add(_selectedCourseReg);
        }

        public CourseRegViewModel(string studentId)
        {
            GenerateList(studentId);
            GenerateSelectedList();
        }


        private async void GenerateList(string studentId)
        {
            var service = new CourseRegService();
            var model = await service.GetCourseRegAsync(studentId);
            AvailableCredit = model.AvailableCredit;
            StudentId = studentId;

            CourseRegs = new ObservableCollection<CourseReg>();
            foreach (var course in model.Courses)
            {
                CourseRegs.Add(course);
            }

        }
        private void GenerateSelectedList()
        {
            SelectedCourseRegs = new ObservableCollection<CourseReg>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
