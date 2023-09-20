using System.ComponentModel.DataAnnotations;
using IMDb.Data;
using IMDb.Domain;
using static System.Console;//Slipper skriva console

// En namnrymd används för att organisera och separera olika delar av din kod
//All kod inom den här filen är nu en del av namnrymden "IMDb."
namespace IMDb;

//Detta är deklarationen av en klass med namnet "Program." Klassen fungerar som ingångspunkten 
//för din applikation. Det är här programmet börjar köra när det startas. Det är vanligt att ha 
//en klass med namnet "Program" eller liknande som innehåller Main-metoden.
class Program
{
    //Detta är definitionen av Main-metoden inom klassen "Program." 
    //Main-metoden är den punkt där programmet börjar utföra sin logik
    //Den är alltid statisk (static) och har ingen returtyp (void).
    //Det innebär att den inte returnerar något värde när den är klar.
    public static void Main()
    {
        Title = "Product Manager"; //sätter namnet på tabben
        CursorVisible = false; //stänger av markör

        while (true) //Loop som körs tills vi stänger ner den
        {
            WriteLine("1. Lägg till film");
            WriteLine("2. Lägg till skådespelare");
            WriteLine("3. Lägg till skådespelare till film");
            WriteLine("4. Sök film");

            var keyPressed = ReadKey(true); //Läser in knapptryck

            Clear(); // Rensa skärmen efter vi gjort ett val

            switch (keyPressed.Key)
            {
                case ConsoleKey.D1: //case för menyval1
                case ConsoleKey.NumPad1:

                    AddMovieView();

                    break;

                case ConsoleKey.D2: //case för menyval2
                case ConsoleKey.NumPad2:

                    AddActorView();



                    break;

                case ConsoleKey.D3: //case för menyval3
                case ConsoleKey.NumPad3:

                    AddActorToMovieView();

                    return;
            }

            Clear(); // Rensa skärmen efter val i meny
        }
    }

    private static void AddActorToMovieView()
    {
        Write("Skådespelare: ");

        var actorFullName = ReadLine();

        Write("Film: ");

        var movieTitle = ReadLine();

        var actor = FindActorByFullName(actorFullName);

        var movie = FindMovieByTitle(movieTitle);

        if (movie is not null && actor is not null)
        {

            using var context = new ApplicationDbContext();
            //minnet
            context.Movie.Attach(movie);

            movie.Actors.Add(actor);
            //Synkas till databasen
            context.SaveChanges();

            WriteLine("Skådespelare tillagd");

        }
        else
        {
            WriteLine("Skådespelare och/eller film saknas");
        }
        Thread.Sleep(2000);

    }

    private static Actor? FindActorByFullName(string fullName)
    {
        using var context = new ApplicationDbContext();

        // Resultatet av detta uttryck är att den första filmen i databastabellen som matchar titeln 
        // i title kommer att lagras i variabeln movie. Om ingen matchning hittas kommer movie att vara null.
        var fullNameParts = fullName.Split(" ");

        var firstName = fullNameParts[0];
        var lastName = fullNameParts[1];

        var actor = context.Actor.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

        return actor;
    }

    private static Movie? FindMovieByTitle(string title)// den här metoden kan returna två olika värden antingen movie eller null
    {
        using var context = new ApplicationDbContext();
        // Resultatet av detta uttryck är att den första filmen i databastabellen som matchar titeln 
        // i title kommer att lagras i variabeln movie. Om ingen matchning hittas kommer movie att vara null.
        var movie = context.Movie.FirstOrDefault(x => x.Title == title);

        return movie;
    }

    private static void AddActorView()
    {
        Write("Förnamn: ");

        var firstName = ReadLine();

        Write("Efternamn ");

        var lastName = ReadLine();

        Write("Födelsedatum (YYYY-MM-DD) ");
        var birthDateStr = Console.ReadLine();//konventera DateStr till typen DateTime
        var birthDate = DateTime.Parse(birthDateStr);

        //en modell som representerar skådespelare
        var actor = new Actor
        {
            FirstName = firstName,
            LastName = lastName,
            BirthDate = birthDate
        };

        SaveActor(actor);

        WriteLine("Skådespelare sparad");

        Thread.Sleep(2000);


    }

    private static void SaveActor(Actor actor)
    {

        using var context = new ApplicationDbContext();//context klass

        context.Actor.Add(actor);//Lägger till vår film till Dbset Movir

        context.SaveChanges();// sen sparar vi till databasen
    }

    private static void AddMovieView()
    {
        Write("Titel: ");

        var title = ReadLine();

        Write("Handling: ");

        var plot = ReadLine();

        Write("Regissör: ");

        var director = ReadLine();

        Write("Genre: ");

        var genre = ReadLine();

        Write("Premiär (YYYY-MM-DD) ");

        var releaseDateStr = Console.ReadLine();//konventera DateStr till typen DateTime
        var releaseDate = DateTime.Parse(releaseDateStr);

        //samla ihop alla värden i ett objekt som representera en film
        var movie = new Movie
        {
            Title = title,
            Plot = plot,
            Director = director,
            Genre = genre,
            ReleaseDate = releaseDate
        };

        SaveMovie(movie);

        Clear();

        WriteLine("Film sparad");

        Thread.Sleep(2000);


    }

    //metoder
    private static void SaveMovie(Movie movie)
    {
        using var context = new ApplicationDbContext();//context klass

        context.Movie.Add(movie);//Lägger till vår film till Dbset Movir

        context.SaveChanges();// sen sparar vi till databasen

    }
}


