namespace CrudApiStreamberry.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string? Title { get; set; }
        public string? Rating { get; set; }
        public string? Comment { get; set; }
        public Reviewer Reviewer { get; set;}
        public Movie Movie { get; set; }

    }
}
