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
        [Display(Name = "Category")]
        public string category { get; set; }
        [Display(Name = "Tag")]

        public string tag { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.DateTime)]
        public DateTime release_date { get; set; }
        [Display(Name = "Update Date")]
        public DateTime update_date { get; set; }
        [Required(ErrorMessage ="Title is empty")]
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Content")]
        [Required]
        public string content { get; set; }
        
    }
}