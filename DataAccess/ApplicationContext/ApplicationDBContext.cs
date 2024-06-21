using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ApplicationContext
{
    public class ApplicationDBContext : DbContext
    {


        public ApplicationDBContext() : base()
        {

        }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Students> students { get; set; }
        public DbSet<School> schools { get; set; }

    }
}
