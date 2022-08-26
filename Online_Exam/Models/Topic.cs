using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Online_Exam.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Questions = new HashSet<Question>();
            Reports = new HashSet<Report>();
        }
        public int? TopicId { get; set; }
        public string TopicName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
