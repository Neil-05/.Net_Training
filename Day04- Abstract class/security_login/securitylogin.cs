using System;

namespace CAP
{
    // Abstract class
    abstract class CheckLogin
    {
        protected string username;
        protected string password;

        // Constructor in abstract class
        public CheckLogin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        // Abstract method
        public abstract bool ValidateLogin();
    }

    // Admin login
    class AdminLogin : CheckLogin
    {
        public AdminLogin(string username, string password)
            : base(username, password) { }

        public override bool ValidateLogin()
        {
            return username == "admin" && password == "admin123";
        }
    }

    // User login
    class UserLogin : CheckLogin
    {
        public UserLogin(string username, string password)
            : base(username, password) { }

        public override bool ValidateLogin()
        {
            return username == "user" && password == "user123";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CheckLogin login1 = new AdminLogin("admin", "admin123");
            Console.WriteLine(login1.ValidateLogin() ? "Admin Login Success" : "Admin Login Failed");

            CheckLogin login2 = new UserLogin("user", "wrong");
            Console.WriteLine(login2.ValidateLogin() ? "User Login Success" : "User Login Failed");
        }
    }
}
