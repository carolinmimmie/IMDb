using System.ComponentModel.DataAnnotations;

namespace IMDb.Domain;

public class Movie
{
    public int Id { get; set; }

    [MaxLength(50)]
    public required string Title { get; set; }

    [MaxLength(500)]
    public required string Plot { get; set; }

    [MaxLength(50)]
    public required string Genre { get; set; }

    [MaxLength(50)]
    public required string Director { get; set; }

    public required DateTime ReleaseDate { get; set; }

    //Navigation Property
    //many to many - en movie kan ha actors - representerar kopplingstabellen - skapa migrering efter skapat upp denna lista
    public ICollection<Actor> Actors { get; set; } = new List<Actor>();
}