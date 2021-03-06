﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkMilk.Models;
using MilkMilk.Internal;
using Microsoft.Extensions.Logging;
using Markdig;
using Markdig.SyntaxHighlighting;

namespace MilkMilk.Pages.PageBlog
{
    public class DeleteModel : PageModel
    {
        private readonly MilkMilk.Data.MilkMilkContext _context;
        private readonly ILogger _logger;

        public DeleteModel(MilkMilk.Data.MilkMilkContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Blog Blog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                _logger.QuoteDeleteFail("id == null", (int)id);
                return NotFound();
            }

            Blog = await _context.Blog.FirstOrDefaultAsync(m => m.id == id);

            if (Blog == null)
            {
                _logger.QuoteDeleteFail("Blog == null", (int)id);
                return NotFound();
            }
            // TODO: simplify
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseSyntaxHighlighting()
                .Build();
            Blog.content = Markdown.ToHtml(Blog.content, pipeline);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog = await _context.Blog.FindAsync(id);

            if (Blog != null)
            {
                _context.Blog.Remove(Blog);
                await _context.SaveChangesAsync();
                _logger.QuoteDelete(Blog.ToString(), (int)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
