using System.Collections.Generic;

namespace Movie_Library_Management_System.Management
{
    public interface IFilmLibrary
    {
        void AddFilm(IFilm film);
        void RemoveFilm(string title);
        IFilm GetFilm(string title);
        List<IFilm> GetAllFilms();
        List<IFilm> SearchFilms(string keyword);
    }
}
