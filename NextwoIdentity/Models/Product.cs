using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextwoIdentity.Models

{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        [ForeignKey("Category")]
        public int  CategoryId { get; set; }
        public Category? Category { get; set; }
        
    }
}
