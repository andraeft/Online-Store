using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagazinOnline.Models
{
    public class Review
    {
        [Key]
        private int reviewId { get; set; }
        private int productId { get; set; }
        private int userId { get; set; }
        [Required]
        private String comment { get; set; }
    }
    public class ReviewDBContext : DbContext
    {
        public ReviewDBContext() : base("DBConnectionString") { }
        public DbSet<Review> Reviews { get; set; }

    }
}