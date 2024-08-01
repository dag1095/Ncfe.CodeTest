using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest
{
    public class CodeTestDbContext : DbContext
    {
        public DbSet<FailoverEntry> FailoverEntries { get; set; }
        public DbSet<Learner> Learners { get; set; }

        public CodeTestDbContext(string connectionString) : base(connectionString) 
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
