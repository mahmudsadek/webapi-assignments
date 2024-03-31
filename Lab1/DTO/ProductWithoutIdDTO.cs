using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.ViewModels
{
    public class ProductWithoutIdDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
    }
}
