using System;
using System.Collections.Generic;
using System.Text;

namespace SKampusApp.Models
{
    public class TopicModel
    {
        public int TopicId { get; set; }
        public int ModuleId { get; set; }
        public string TopicName { get; set; }
        public int ExpectedTime { get; set; }
    }
}
