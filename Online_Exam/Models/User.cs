using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Online_Exam.Models
{
    public partial class User
    {
        public User()
        {
            Reports = new HashSet<Report>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Dob { get; set; }
        public string State { get; set; }
        public string Qualification { get; set; }
        public int YearOfCompletion { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
