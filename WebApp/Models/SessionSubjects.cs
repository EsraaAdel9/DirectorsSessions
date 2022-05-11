using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class SessionSubjects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "رقم الموضوع")]
        public int Sub_ID { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "اسم الموضوع")]
        public string Sub_Name { get; set; }

        [Required]
        [MaxLength(2000)]
        [Display(Name = "الموضوع")]
        public string Sub_Description { get; set; }

        [Display(Name = "رقم الجلسة")]
        public int NewSessionID { get; set; }
        public virtual NewSession NewSession { get; set; }
    }
}