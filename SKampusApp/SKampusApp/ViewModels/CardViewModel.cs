using SKampusApp.Models;
using SwiftKampusMobile.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SKampusApp.ViewModels
{
    public class CardViewModel : INotifyPropertyChanged
    {

        public List<CardDataModel> _courseReg { get; set; }

        public List<CardDataModel> CardDataModels
        {
            get { return _courseReg; }
            set
            {
                _courseReg = value;
                OnPropertyChanged();
            }

        }

        public CardViewModel(string studentId)
        {
            GenerateList(studentId);
        }

        private async Task GenerateList(string studenId)
        {

            var service = new StudentServices();
            var response = await service.StudentDashboardAsync(studenId);
            CardDataModels = new List<CardDataModel>
            {
                new CardDataModel
                {
                    HeadTitle = "Full Name",
                    HeadLines = response.FullName,
                    ProfileImage = "iconsession"
                },
                new CardDataModel
                {
                    HeadTitle = "School Fee",
                    HeadLines = response.SchoolFees.ToString(CultureInfo.InvariantCulture),
                    ProfileImage = "iconsession"
                },
                new CardDataModel
                {
                    HeadTitle = "Session",
                    HeadLines = response.SessionName,
                    ProfileImage = "iconsession"
                },
                new CardDataModel
                {
                    HeadTitle = "Semester",
                    HeadLines = response.SemesterName,
                    ProfileImage = ""
                },
                new CardDataModel
                {
                    HeadTitle = "Current Level",
                    HeadLines =response.LevelName,
                    ProfileImage = ""
                },
                new CardDataModel
                {
                    HeadTitle = "Faculty",
                    HeadLines = response.FacultyName,
                    ProfileImage = ""
                },
                new CardDataModel
                {
                    HeadTitle = "DEPARTMENT",
                    HeadLines = response.DepartmentName,
                    ProfileImage = ""
                },
                new CardDataModel
                {
                    HeadTitle = "PROGRAMME NAME",
                    HeadLines = response.ProgrammeName,
                    ProfileImage = ""
                },
            };

        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
