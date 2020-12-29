using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilkMilk.Models
{
    public class Blog
    {
        public int id { get; set; }
        public string category { get; set; }

        public string tag { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime release_date { get; set; }
        public DateTime update_date { get; set; }
        [Required(ErrorMessage ="Title is empty")]
        public string title { get; set; }
        [Required]
        public string content { get; set; }
        
    }
}