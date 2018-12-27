using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagazinOnline.Models
{
    public class Rating
    {
        [Key, Column(Order=1)]
        private int productId { get; set; }
        [Key, Column(Order=2)]
        private int userId { get; set; }
        [Required]
        private int stars { get; set; }
    }
    public class RatingDBContext : DbContext
    {
        public RatingDBContext() : base("DBConnectionString") { }
        public DbSet<Rating> Ratings { get; set; }

    }
}