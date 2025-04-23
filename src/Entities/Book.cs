namespace Rocketseat_Gestão_Livraria.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    
    }
}
