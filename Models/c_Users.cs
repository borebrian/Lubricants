using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lubricants.Models
{
    public class c_Users
    {
        [Required]
        [DisplayName("Phone")]
        public string strPhone { get; set; }
        
        [Required]
        [DisplayName("Full name")]
        public string Full_name { get; set; }


        [Required]
        [DisplayName("Date Of Birth")]
        public string strDOB { get; set; }
        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string strEmail { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string strPassword { get; set; }
        [Key]
        [MaxLength(50)]
        public string strUserId { get; set; }
        public string strRole { get; set; }
    }
}
