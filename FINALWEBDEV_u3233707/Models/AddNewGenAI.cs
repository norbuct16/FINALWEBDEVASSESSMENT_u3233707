using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FINALWEBDEV_u3233707.Models
{
    public class AddNewGenAI:DbContext
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "GenAI Name")]
        public string? GenAIName { get; set; }
        [Required]
        [Display(Name = "Summary")]
        public string? Summary { get; set; }

        public string? ImageFilename { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-FINALWEBDEV_u3233707-da2eca11-47f0-4caf-8efe-bd53bd7996cc;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }
        [Display(Name = "Anchor Link")]
        public string? AnchorLink { get; set; }

        [Display(Name = "Like")]
        public int Like { get; set; }

        public bool isLiked { get; set; }




    }
  
}

