using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilkMilk.Data;
using MilkMilk.Models;

namespace MilkMilk.Pages.PageBlog
{
    public class IndexModel : PageModel
    {
        private readonly MilkMilk.Data.MilkMilkContext _context;

        public IndexModel(MilkMilk.Data.MilkMilkContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get; set; }

        public async Task OnGetAsync()
        {
            var blogs = from blog in _context.Blog
                        select blog;

            var blogs_query = from blog in _context.Blog
                              orderby blog.release_date
                              select blog.release_date;

            if (!string.IsNullOrEmpty(SearchStringTitle))
            {
                blogs = blogs.Where(s => s.title.Contains(SearchStringTitle));
            }

            if (!string.IsNullOrEmpty(SearchStringReleaseDate))
            {
                blogs = blogs.Where(s => s.release_date.ToString().Contains(SearchStringReleaseDate));
            }

            SearchListReleaseDate = new SelectList(await blogs_query.ToListAsync());

            Blog = await blogs.ToListAsync();
        }

        [BindProperty(SupportsGet = true)]
        public string SearchStringTitle { get; set; }
        public SelectList SearchListReleaseDate { get; set; }
        public string SearchStringReleaseDate { get; set; }

    }
}
