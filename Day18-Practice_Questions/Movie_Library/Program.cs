public class Film
{
    public string Title{get; set;}
    public string Director{get;set;}

    public int Year{get;set;}

    public Film(string title, string director, int year)
    {
        Title = title;
        Director = director;
        Year = year;
    }

}

public class FilmLibrary
{
    private List<Film> _films;
    private static int count=0;

    public static void AddFilm(List<Film> films, Film film)
    {
        films.Add(film);
        count++;
    }

    public static void RemoveFilm(List<Film> films, Film film)
    {
        films.Remove(film);
    }
    public List<Film>  GetFilms()
    {
        return _films;
    }
    
    public static List<Film> SearchFilms(List<Film> films, string query)
    {
        return films.Where(f=> f.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || 
                             f.Director.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

    }

    public static int GetFilmCount()
    {
        return count;
    }



}
public class Program
{
    public static void Main(string[] args)
    {
        List<Film> films= new List<Film>();
        Film film1=new Film("Inception","Christopher Nolan",2010);
        Film film3= new Film("Interstellar","Christopher Nolan",2014);
        Film film2=new Film("The Dead Poets Society","Peter Weir",1989);
        FilmLibrary.AddFilm(films,film1);
        FilmLibrary.AddFilm(films,film3);
        FilmLibrary.AddFilm(films,film2);   
        Console.WriteLine("Total Films: "+FilmLibrary.GetFilmCount());
        var searchResults=FilmLibrary.SearchFilms(films,"Nolan");
        Console.WriteLine("Search Results:");
        foreach(var film in searchResults)
        {
            Console.WriteLine($"{film.Title} directed by {film.Director} ({film.Year})");
        }
        Console.WriteLine("\n--- Menu ---");
        Console.WriteLine("1. Add Film");
        Console.WriteLine("2. Search Films");
        Console.WriteLine("3. View Film Count");
        Console.Write("Choose an option: ");
        
        string choice = Console.ReadLine();
        
        switch(choice)
        {
            case "1":
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            Console.Write("Enter director: ");
            string director = Console.ReadLine();
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            Film newFilm = new Film(title, director, year);
            FilmLibrary.AddFilm(films, newFilm);
            Console.WriteLine("Film added successfully!");
            break;
            case "2":
            Console.Write("Enter search query: ");
            string query = Console.ReadLine();
            var results = FilmLibrary.SearchFilms(films, query);
            Console.WriteLine("Search Results:");
            foreach(var film in results)
            {
                Console.WriteLine($"{film.Title} directed by {film.Director} ({film.Year})");
            }
            break;
            case "3":
            Console.WriteLine("Total Films: " + FilmLibrary.GetFilmCount());
            break;
            default:
            Console.WriteLine("Invalid option!");
            break;
        }

}}