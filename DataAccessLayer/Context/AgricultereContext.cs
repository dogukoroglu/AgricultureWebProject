using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
	public class AgricultereContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=LAPTOP-GPMKKC5N\\SQLEXPRESS;database=AgricultereDB;integrated security=true;TrustServerCertificate=True;");
		}

		public DbSet<Address> Addresses { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Announcement> Announcements { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Team> Teams { get; set; }
	}
}
