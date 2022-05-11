using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    [Table("NewSession")]
    public class NewSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "رقم الجلسة")]
        public string Session_Num { get; set; }

        [Display(Name = "تاريخ الجلسة")]
        public DateTime Session_Date { get; set; }

        public virtual ICollection <SessionSubjects>sub { get; set; }
    }
}