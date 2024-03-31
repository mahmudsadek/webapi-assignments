using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models
{
    public class Product
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        [Column(TypeName = "money")]
        public decimal Price{ get; set; }

        [ForeignKey("Category")]
        public int? CategoryId{ get; set; }

        public Category? Category { get; set; }

        public bool isDeleted { get; set; } = false;

        public DateTime? DeletedTime { get; set; }
    }
}
