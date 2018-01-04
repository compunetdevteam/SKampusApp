using System.Collections.Generic;

namespace SKampusApp.Models
{
    public class CourseRegApi
    {
        public string StudentId { get; set; }
        public int AvailableCredit { get; set; }
        public List<CourseReg> Courses { get; set; }
    }
}
