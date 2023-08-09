using ahlatciapp.Models;
using Microsoft.EntityFrameworkCore;

namespace ahlatciapp.Context
{
	public class AhlContext:DbContext
	{

		public DbSet<AboneKsBilgi> AboneBilgi { get; set; }
		public DbSet<AboneAdres> AboneAdres { get; set; }
		public DbSet<Fatura> Faturalar { get; set; }
		public DbSet<Personel> Personel { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-NB3VLFD;Initial Catalog=ahldb;Integrated Security=True");
			base.OnConfiguring(optionsBuilder);
		}

	}
}
