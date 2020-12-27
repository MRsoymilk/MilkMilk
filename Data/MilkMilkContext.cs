using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilkMilk.Models;

namespace MilkMilk.Data
{
    public class MilkMilkContext : DbContext
    {
        public MilkMilkContext (DbContextOptions<MilkMilkContext> options)
            : base(options)
        {
        }

        public DbSet<MilkMilk.Models.Blog> Blog { get; set; }
    }
}
