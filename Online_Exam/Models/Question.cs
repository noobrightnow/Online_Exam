using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Exam.Models
{
    public partial class Question
    {
        public int QuesId { get; set; }
        public string Ques { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int? Answer { get; set; }
        public int Level { get; set; }
        public int? Topicid { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
