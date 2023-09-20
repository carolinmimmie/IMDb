using System.ComponentModel.DataAnnotations;

namespace IMDb.Domain;

public class Actor
{
    public int Id { get; set; }

    [MaxLength(50)]
    public required string FirstName { get; set; }

    [MaxLength(50)]
    public required string LastName { get; set; }

    public required DateTime BirthDate { get; set; }

    //Navigation Property
    //many to many - en actor kan ha movies - representerar kopplingstabellen - skapa migrering efter skapat upp denna lista
    // genererar en ny migration - dotnet ef migrations add AddMovieActor - och därefter - dotnet ef database update

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}