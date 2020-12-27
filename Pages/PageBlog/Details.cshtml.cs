using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkMilk.Data;
using MilkMilk.Models;

namespace MilkMilk.Pages.PageBlog
{
    public class DetailsModel : PageModel
    {
        private readonly MilkMilk.Data.MilkMilkContext _context;

        public DetailsModel(MilkMilk.Data.MilkMilkContext context)
        {
            _context = context;
        }

        public Blog Blog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog = await _context.Blog.FirstOrDefaultAsync(m => m.id == id);

            if (Blog == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
