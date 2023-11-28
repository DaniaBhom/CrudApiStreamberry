namespace CrudApiStreamberry.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Gender? Gender { get; set; }
        public ICollection<Review> Reviews  { get; set; }
        
    }
}
