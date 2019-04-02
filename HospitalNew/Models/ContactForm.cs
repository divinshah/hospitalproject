using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.Models
{
    public class ContactForm
    {
        [Key, ScaffoldColumn(false)]
        public int ContactId { get; set; }

        [Required, StringLength(255), Display(Name = "Message Id")]
        public string MessageId { get; set; }

        [Required, StringLength(255), Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required, StringLength(255), Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required, StringLength(255), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, StringLength(255), Display(Name = "Topic")]
        public string Topic { get; set; }

        [Required, StringLength(255), Display(Name = "Message")]
        public string Message { get; set; }

        [Required, StringLength(255), Display(Name = "Message Status")]
        public string MessageStatus { get; set; }

        [Required, StringLength(255), Display(Name = "Admin Reply")]
        public string AdminReply { get; set; }

        [ForeignKey("Locations")]
        public int locationId { get; set; }

        public virtual Locations location { get; set; }


    }
}
