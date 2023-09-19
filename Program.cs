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

                    AddMovie();

                    break;

                case ConsoleKey.D2: //case för menyval2
                case ConsoleKey.NumPad2:



                    break;

                case ConsoleKey.D3: //case för menyval3
                case ConsoleKey.NumPad3:

                    Environment.Exit(0);

                    return;
            }

            Clear(); // Rensa skärmen efter val i meny
        }
    }

    private static void AddMovie()
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


