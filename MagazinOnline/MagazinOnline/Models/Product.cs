using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagazinOnline.Models
{
    public class Product
    {
        [Key]
        private int productId { get; set; }
        private String name { get; set; }
        private String description { get; set; }
        private String picture { get; set; }
        private Double price { get; set; }
        private int categoryId { get; set; }
        private int colabUserId { get; set; }
        private Double rating { get; set; }

        private Category category;
        public virtual ICollection<Review> product { get; set; }
    }

    public class ProductDBContext : DbContext
    {
        public ProductDBContext(): base("DBConnectionString") { }
        public DbSet <Product> Products { get; set; }

    }
}