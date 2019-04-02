using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.Models
{
    public class Alert
    {
        [Key, ScaffoldColumn(false)]
        public int AlertId { get; set; }

        [Required, StringLength(255), Display(Name = "Topic")]
        public string alertTopic { get; set; }
        [Required, StringLength(255), Display(Name = "Content")]
        public string alertContent { get; set; }
        [Required, StringLength(255), Display(Name = "Date")]
        public string alertDate { get; set; }
    }
}
