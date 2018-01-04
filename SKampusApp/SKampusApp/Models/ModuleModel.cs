namespace SKampusApp.Models
{
    public class ModuleModel
    {
        public int ModuleId { get; set; }
        public int CourseId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public int ExpectedTime { get; set; }
        public CourseRegModel CourseRegModel { get; set; }

    }
}
