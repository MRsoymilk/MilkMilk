﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MilkMilk.Data;
using System;
using System.Linq;

namespace MilkMilk.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new MilkMilkContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MilkMilkContext>>());
            // Look for any blogs.
            if (context.Blog.Any())
            {
                return;   // DB has been seeded
            }

            context.Blog.AddRange(
                new Blog
                {
                    title = "Hello World",
                    content = "hello world! This is my first blog!",
                    release_date = DateTime.Parse("2020-1-1"),
                    update_date = DateTime.Parse("2020-1-1"),
                    category = "category",
                    tag = "tag"
                },
                new Blog
                {
                    title = "Markdown",
                    content = "test for `markdown`",
                    release_date = DateTime.Parse("2020-1-1"),
                    update_date = DateTime.Parse("2020-1-1"),
                    category = "category",
                    tag = "tag"
                }
            );
            context.SaveChanges();
        }
    }
}
