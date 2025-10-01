using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBillingApp
{
    public class InsuranceDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<InsurancePolicy> Policies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var projectRoot = Directory.GetParent(AppContext.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
            var dbPath = Path.Combine(projectRoot, "Data", "insurance.db");
            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}
