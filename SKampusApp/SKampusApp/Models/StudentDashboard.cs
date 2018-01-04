namespace SKampusApp.Models
{
    public class StudentDashboard
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string LevelName { get; set; }
        public string ProgrammeName { get; set; }
        public string DepartmentName { get; set; }
        public string SemesterName { get; set; }
        public string SessionName { get; set; }
        public string FacultyName { get; set; }
        public int NoOfRegCourses { get; set; }
        public decimal SchoolFees { get; set; }
        public string Message { get; set; }
    }
}
