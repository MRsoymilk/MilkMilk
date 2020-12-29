using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MilkMilk.Data;
using MilkMilk.Internal;
using MilkMilk.Models;

namespace MilkMilk.Pages.PageBlog
{
    public class CreateModel : PageModel
    {
        private readonly MilkMilk.Data.MilkMilkContext _context;
        private readonly ILogger _logger;
        public CreateModel(MilkMilk.Data.MilkMilkContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Blog Blog { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Blog.Add(Blog);
            await _context.SaveChangesAsync();
            _logger.QuoteAdd(Blog.title);
            return RedirectToPage("./Index");
        }
    }
}
