using Microsoft.EntityFrameworkCore;
using CapstoneOptichain.Models;
namespace CapstoneOptichain.Data
{
	public class ProjectContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Optichain1;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
		}
		public DbSet<Manager> Managers { get; set; }
		public DbSet<Worker> Workers { get; set; }
		public DbSet<Inventory> Inventories { get; set; }
		public DbSet<Distribution> Distributions { get; set; }
		public DbSet<FinishedProduct> FinishedProducts { get; set; }
		public DbSet<Production> Productions { get; set; }
		public DbSet<RawMaterial> RawMaterials { get; set; }
	}
}
