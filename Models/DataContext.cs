using Microsoft.EntityFrameworkCore;

namespace Indigo.Models
{
	public class DataContext:DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
		public DbSet<Slider> Sliders { get; set; }
	}
}
