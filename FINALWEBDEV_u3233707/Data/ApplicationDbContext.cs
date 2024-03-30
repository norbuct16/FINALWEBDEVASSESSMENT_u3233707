using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FINALWEBDEV_u3233707.Models;

namespace FINALWEBDEV_u3233707.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<FINALWEBDEV_u3233707.Models.AddNewGenAI>? AddNewGenAI { get; set; }
        

    }
}