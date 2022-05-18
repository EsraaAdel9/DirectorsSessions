using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class SessionInstructions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "رقم الجلسة")]
        public int NewSessionID { get; set; }
        public virtual NewSession NewSession { get; set; }

        [Display(Name = "الامر الاداري للجلسة")]
        public string Sessionnstructions { get; set; }
    }
}