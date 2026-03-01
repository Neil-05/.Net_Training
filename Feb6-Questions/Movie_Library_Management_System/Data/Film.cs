namespace Movie_Library_Management_System.Data
{
    public class Film : IFilm
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Year}) - Directed by {Director}";
        }
    }
}
