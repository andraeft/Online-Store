using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagazinOnline.Models
{
    public class Category
    {
        [Key]
        private int categoryId { get; set; }
        private String name { get; set; }

        public virtual ICollection<Product> product { get; set; }
    }

    public class CategoryDBContext : DbContext
    {
        public CategoryDBContext() : base("DBConnectionString") { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}