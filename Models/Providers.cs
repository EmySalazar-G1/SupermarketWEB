namespace SupermarketWEB.Models
{
    public class Providers
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<Providers>? Provider { get; set; }
    }
}
    

