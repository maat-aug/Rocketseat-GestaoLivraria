namespace Rocketseat_Gestao_Livraria.Communication.Request
{
    public class RequestBookJson
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
