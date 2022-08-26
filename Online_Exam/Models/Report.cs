using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Online_Exam.Models
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int? Userid { get; set; }
        public int? Topicid { get; set; }
        public int Score { get; set; }
        public int Level { get; set; }
        public string Remarks { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual User User { get; set; }
    }
}
