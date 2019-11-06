using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebCore.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) { }
    
        public DbSet<Login> Logins { get; set; }

        public DbSet<QuestionsHeaderContent> questionsHeaderContents { get; set; }

        public DbSet<Questions> questions { get; set; }
    }
}
