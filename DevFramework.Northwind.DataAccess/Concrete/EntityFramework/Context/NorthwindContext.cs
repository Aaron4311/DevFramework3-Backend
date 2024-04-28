using DevFramework.Core.Entity.Concrete;
using DevFramework.Northwind.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Context
{
    public class NorthwindContext : DbContext
    {
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
		public DbSet<OperationClaim> OperationClaims { get; set; }
		public DbSet<Order> Orders { get; set; }
		//public DbSet<OrderDetail> OrderDetails { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<OrderDetail>().HasKey(x => new { x.OrderId,x.ProductId});

			//modelBuilder.Entity<Product>()
			//	.HasMany(x => x.OrderDetails)
			//	.WithOne(x => x.Product)
			//	.OnDelete(DeleteBehavior.Cascade);
				
		}
	}
}
