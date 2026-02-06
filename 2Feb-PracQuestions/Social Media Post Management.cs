using System;
using System.Collections.Generic;
using System.Linq;

class User
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Bio { get; set; }
    public int FollowersCount { get; set; }
    public List<string> Following { get; set; }
        = new List<string>();
}

class Post
{
    public string PostId { get; set; }
    public string UserId { get; set; }
    public string Content { get; set; }
    public DateTime PostTime { get; set; }
    public string PostType { get; set; }
    public int Likes { get; set; }
    public List<string> Comments { get; set; }
        = new List<string>();
}

class SocialMediaManager
{
    private List<User> users = new List<User>();
    private List<Post> posts = new List<Post>();

    private int uCounter = 1;
    private int pCounter = 1;

    public void RegisterUser(string name, string bio)
    {
        users.Add(new User
        {
            UserId = "U" + uCounter++,
            UserName = name,
            Bio = bio
        });
    }

    public void CreatePost(string uid, string content, string type)
    {
        posts.Add(new Post
        {
            PostId = "P" + pCounter++,
            UserId = uid,
            Content = content,
            PostTime = DateTime.Now,
            PostType = type,
            Likes = 0
        });
    }

    public void LikePost(string pid, string uid)
    {
        var p = posts.FirstOrDefault(x => x.PostId == pid);

        if (p != null) p.Likes++;
    }

    public void AddComment(string pid, string uid, string comment)
    {
        var p = posts.FirstOrDefault(x => x.PostId == pid);

        if (p != null)
            p.Comments.Add(uid + ": " + comment);
    }

    public Dictionary<string, List<Post>> GroupPostsByUser()
    {
        return posts.GroupBy(p => p.UserId)
                    .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Post> GetTrendingPosts(int minLikes)
    {
        return posts.Where(p => p.Likes >= minLikes)
                    .OrderByDescending(p => p.Likes)
                    .ToList();
    }
}

class Program
{
    static void Main()
    {
        SocialMediaManager manager = new SocialMediaManager();

        manager.RegisterUser("Mukesh", "Coder");
        manager.RegisterUser("Amit", "Designer");

        manager.CreatePost("U1", "Hello World!", "Text");
        manager.CreatePost("U2", "My Photo", "Image");

        manager.LikePost("P1", "U2");
        manager.LikePost("P1", "U1");

        manager.AddComment("P1", "U2", "Nice!");

        Console.WriteLine("Posts By User:");

        var grouped = manager.GroupPostsByUser();

        foreach (var g in grouped)
        {
            Console.WriteLine("\nUser " + g.Key);

            foreach (var p in g.Value)
                Console.WriteLine(p.Content);
        }

        Console.WriteLine("\nTrending Posts:");

        foreach (var p in manager.GetTrendingPosts(2))
            Console.WriteLine(p.Content);
    }
}
