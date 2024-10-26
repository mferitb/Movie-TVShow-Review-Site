namespace WebApplication1.Models
{
    public class TVShow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public double Rating { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); 

    }
}
