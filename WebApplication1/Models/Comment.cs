using WebApplication1.Models;

public class Comment
{
    public int Id { get; set; }
    public int? MovieId { get; set; } // Nullable, çünkü bazı yorumlar sadece TV show'lar için olabilir
    public int? TVShowId { get; set; } // Nullable, çünkü bazı yorumlar sadece film için olabilir
    public string Author { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public int Rating { get; set; }

    public virtual Movie Movie { get; set; }
    public virtual TVShow TVShow { get; set; }
}
