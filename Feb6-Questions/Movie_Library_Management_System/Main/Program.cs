using System;
using System.Collections.Generic;
using Movie_Library_Management_System.Data;
using Movie_Library_Management_System.Management;

namespace Movie_Library_Management_System
{
    class Program
    {
        public static void Main(string[] args)
        {
            IFilmLibrary filmLibrary = new FilmLibrary();

            filmLibrary.AddFilm(new Film
            {
                Title = "Inception",
                Director = "Christopher Nolan",
                Year = 2010
            });

            filmLibrary.AddFilm(new Film
            {
                Title = "The Matrix",
                Director = "The Wachowskis",
                Year = 1999
            });

            Console.WriteLine("All Films:");
            foreach (var film in filmLibrary.GetAllFilms())
            {
                Console.WriteLine(film);
            }

            Console.WriteLine("\nSearch Results for 'Inception':");
            var result = filmLibrary.SearchFilms("Inception");
            foreach (var film in result)
            {
                Console.WriteLine(film);
            }

            Console.WriteLine("\nGet Film by Title:");
            var singleFilm = filmLibrary.GetFilm("The Matrix");
            Console.WriteLine(singleFilm);

            Console.WriteLine("\nRemoving 'Inception'...");
            filmLibrary.RemoveFilm("Inception");

            Console.WriteLine("\nRemaining Films:");
            foreach (var film in filmLibrary.GetAllFilms())
            {
                Console.WriteLine(film);
            }
        }
    }
}
