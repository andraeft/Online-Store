using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Campul de titlu este obligatoriu")]
        [StringLength(50, ErrorMessage = "Introduceti maxim 50 de caractere")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Campul de continur este obligatoriu")]
        //[MinLength(30, ErrorMessage = "Introduceti minim 30 de caractere")]
        public string Description { get; set; }
        //[Required(ErrorMessage = "Campul de data este obligatoriu")]
        public string Picture { get; set; }
        //[Required(ErrorMessage = "Campul de data este obligatoriu")]
        public string Price { get; set; }
        //[Required(ErrorMessage = "Campul de data este obligatoriu")]
        public string ColabId { get; set; }


        //[Required(ErrorMessage = "Campul de data este obligatoriu")]
        public DateTime Date { get; set; }
        //[Required(ErrorMessage = "Campul de categorie este obligatoriu")]
        public int CategoryId { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public virtual Category Category { get; set; }

        
    }

    public class ProductDBContext : DbContext
    {
        public ProductDBContext() : base("DBConnectionString") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}