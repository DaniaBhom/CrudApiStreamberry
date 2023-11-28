namespace CrudApiStreamberry.Models
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string? Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
