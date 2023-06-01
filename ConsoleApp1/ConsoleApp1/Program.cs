using ConsoleApp1.Models;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;



namespace ConsoleApp1
{


    static void Main(string[] args)
    {

        User user1 = new User() { Name = "ahmet", Adress = "antalya" };
        User user2 = new User() { Name = "ali", Adress = "mersin" };
        User user3 = new() { Name = "anka", Adress = "antalya" };
        List<User> users = new List<User>()
        {
            user1 , user2
        };

        foreach (User u in users) { Console.WriteLine($"{u.Name},{u.Adress}"); }
        users.Where(usr => usr.Adress == "antalya").ToList();
        string? st=Console.ReadLine();
        List<User> us = users.Where(usr => usr.Name == st).ToList();
        foreach(User k in us) { Console.WriteLine($"{k.Name},{k.Adress}"); }



        }

}
    
