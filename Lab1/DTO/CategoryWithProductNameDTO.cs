namespace Lab1.DTO
{
    public class CategoryWithProductNameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<string> ProductNames { get; set; }
    }
}
