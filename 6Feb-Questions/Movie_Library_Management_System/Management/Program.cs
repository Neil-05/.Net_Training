using System.Collections.Generic;
using System.Linq;

namespace Movie_Library_Management_System.Management
{
    public class FilmLibrary : IFilmLibrary
    {
        private readonly List<IFilm> films = new();

        public void AddFilm(IFilm film)
        {
            films.Add(film);
        }

        public void RemoveFilm(string title)
        {
            var film = films.FirstOrDefault(f => f.Title == title);
            if (film != null)
                films.Remove(film);
        }

        public IFilm GetFilm(string title)
        {
            return films.FirstOrDefault(f => f.Title == title);
        }

        public List<IFilm> GetAllFilms()
        {
            return films;
        }

        public List<IFilm> SearchFilms(string keyword)
        {
            return films
                .Where(f => f.Title.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }
    }
}
