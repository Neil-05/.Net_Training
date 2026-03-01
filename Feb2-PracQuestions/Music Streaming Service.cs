using System;
using System.Collections.Generic;
using System.Linq;

class Song
{
    public string SongId { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }
    public string Album { get; set; }
    public TimeSpan Duration { get; set; }
    public int PlayCount { get; set; }
}

class Playlist
{
    public string PlaylistId { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public List<Song> Songs { get; set; } = new List<Song>();
}

class User
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public List<string> FavoriteGenres { get; set; } = new List<string>();
    public List<Playlist> UserPlaylists { get; set; } = new List<Playlist>();
}

class MusicManager
{
    private List<Song> songs = new List<Song>();
    private List<User> users = new List<User>();
    private int sCounter = 1;
    private int pCounter = 1;

    public void AddSong(string title, string artist,
                        string genre, string album, TimeSpan dur)
    {
        songs.Add(new Song
        {
            SongId = "S" + sCounter++,
            Title = title,
            Artist = artist,
            Genre = genre,
            Album = album,
            Duration = dur,
            PlayCount = 0
        });
    }

    public void CreateUser(string name)
    {
        users.Add(new User
        {
            UserId = "U" + users.Count + 1,
            UserName = name
        });
    }

    public void CreatePlaylist(string uid, string name)
    {
        var u = users.FirstOrDefault(x => x.UserId == uid);

        if (u == null) return;

        u.UserPlaylists.Add(new Playlist
        {
            PlaylistId = "P" + pCounter++,
            Name = name,
            CreatedBy = uid
        });
    }

    public bool AddSongToPlaylist(string pid, string sid)
    {
        var song = songs.FirstOrDefault(s => s.SongId == sid);

        foreach (var u in users)
        {
            var p = u.UserPlaylists.FirstOrDefault(x => x.PlaylistId == pid);

            if (p != null && song != null)
            {
                p.Songs.Add(song);
                return true;
            }
        }

        return false;
    }

    public Dictionary<string, List<Song>> GroupSongsByGenre()
    {
        return songs.GroupBy(s => s.Genre)
                    .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Song> GetTopPlayedSongs(int count)
    {
        return songs.OrderByDescending(s => s.PlayCount)
                    .Take(count).ToList();
    }
}

class Program
{
    static void Main()
    {
        MusicManager manager = new MusicManager();

        manager.AddSong("Kesariya", "Arijit", "Romantic",
                        "Brahmastra", TimeSpan.FromMinutes(4));

        manager.AddSong("Believer", "Imagine Dragons", "Rock",
                        "Evolve", TimeSpan.FromMinutes(3));

        manager.AddSong("Tum Hi Ho", "Arijit", "Romantic",
                        "Aashiqui 2", TimeSpan.FromMinutes(5));

        manager.CreateUser("Mukesh");

        manager.CreatePlaylist("U1", "MyHits");

        manager.AddSongToPlaylist("P1", "S1");
        manager.AddSongToPlaylist("P1", "S3");

        Console.WriteLine("Songs By Genre:");

        var grouped = manager.GroupSongsByGenre();

        foreach (var g in grouped)
        {
            Console.WriteLine("\n" + g.Key);

            foreach (var s in g.Value)
                Console.WriteLine(s.Title);
        }
    }
}
