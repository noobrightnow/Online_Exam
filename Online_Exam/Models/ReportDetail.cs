namespace Online_Exam.Models
{
	public class ReportDetail
	{
        public int ReportId { get; set; }
        public int? Userid { get; set; }
        public int? Topicid { get; set; }
        public int Score { get; set; }
        public int Level { get; set; }
        public string Remarks { get; set; }
        public string username { get; set; }
        public string topicname { get; set; }
    }
}
