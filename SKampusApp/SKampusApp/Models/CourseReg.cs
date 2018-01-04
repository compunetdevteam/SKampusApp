using System.Collections.Generic;

namespace SKampusApp.Models
{
    public class CourseReg
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credit { get; set; }
        public string FullName => CourseName + "( Unit: " + Credit + " )";
    }

    public class CourseRegModel
    {

        public string StudentId { get; set; }
        public int LevelId { get; set; }
        public int ProgrammeId { get; set; }
        public int? DepartmentId { get; set; }
        public int SemesterId { get; set; }
        public int SessionId { get; set; }
        public int[] CourseId { get; set; }
        public int[] CarryOverCoursesId { get; set; }
        public int AvailableCredit { get; set; }
        public string Message { get; set; }

        public List<CourseReg> Courses { get; set; }
        public List<CourseReg> CarryOverCourses { get; set; }
    }
}
