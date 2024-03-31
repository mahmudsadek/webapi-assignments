using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.DTO
{
    public class ProductWithIdDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
    }
}
