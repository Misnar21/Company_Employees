using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Seed;
namespace Repository
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions options) : base(options){}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CompanySeed());
			modelBuilder.ApplyConfiguration(new EmployeeSeed());
		}
		public DbSet<Company>? Companies { get; set; }
		public DbSet<Employee>? Employees { get; set; }
	}
}
