﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
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
            // release date and update date is current time
            Blog.release_date = DateTime.Now;
            Blog.update_date = DateTime.Now;
            _context.Blog.Add(Blog);
            await _context.SaveChangesAsync();
            _logger.QuoteAdd(Blog.title);
            return RedirectToPage("./Index");
        }
    }
}
