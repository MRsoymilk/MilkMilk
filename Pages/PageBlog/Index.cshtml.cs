using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkMilk.Models;
using MilkMilk.Internal;
using Microsoft.Extensions.Logging;

namespace MilkMilk.Pages.PageBlog
{
    public class IndexModel : PageModel
    {
        private readonly MilkMilk.Data.MilkMilkContext _context;
        private readonly ILogger _logger;

        public IndexModel(MilkMilk.Data.MilkMilkContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Blog> Blog { get; set; }
        public int TotalRecords { get; set; } = 0;
        // Page Number
        [BindProperty(SupportsGet = true)]
        public int P { get; set; } = 1;
        // Page Size
        [BindProperty(SupportsGet = true)]
        public int S { get; set; } = 10;

        public async Task OnGetAsync()
        {
            _logger.IndexLogger();

            var blogs = from blog in _context.Blog
                        select blog;
            
            // search title
            if (!string.IsNullOrEmpty(SearchStringTitle))
            {
                blogs = blogs.Where(s => s.title.Contains(SearchStringTitle));
            }
            // search category
            if (!string.IsNullOrEmpty(SearchStringCategory))
            {
                blogs = blogs.Where(s => s.category.Contains(SearchStringCategory));
            }
            // search tag
            if (!string.IsNullOrEmpty(SearchStringTag))
            {
                blogs = blogs.Where(s => s.tag.Contains(SearchStringTag));
            }

            // pagination
            TotalRecords = blogs.Count();
            Blog = await blogs
                .OrderBy(x => x.id)
                .Skip((P - 1) * S)
                .Take(S)
                .ToListAsync();
        }

        [BindProperty(SupportsGet = true)]
        public string SearchStringTitle { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchStringCategory { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchStringTag { get; set; }

    }
}
