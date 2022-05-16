using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class MemoViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public IEnumerable<SessionSubjects> sub { get; set; }

        public IEnumerable<MemoTypes> MemoTypes { get; set; }
    }
}