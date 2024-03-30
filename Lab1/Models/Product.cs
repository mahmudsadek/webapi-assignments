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
    }
}
