﻿using System.Threading.Tasks;
using Markdig;
using Markdig.SyntaxHighlighting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
            // TODO: simplify
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseSyntaxHighlighting()
                .Build();
            Blog.content = Markdown.ToHtml(Blog.content, pipeline);
            return Page();
        }
    }
}
