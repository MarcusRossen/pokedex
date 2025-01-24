using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace pokedex;

public class Login()
{
    public void ShowLoginMenu(User user)
    {
        do
        {
            Console.Clear();

            Console.Write("Indtast brugernavn: ");
            string? username = Console.ReadLine();

            Console.Write("Indtast adgangskode: ");
            string? password = Console.ReadLine();

            user.IsLoggedIn = CheckLogin(username, password);
        } while (!user.IsLoggedIn);

        Console.WriteLine("\nLogin succesfuldt...");
        Thread.Sleep(1500);
    }

    public bool CheckLogin(string? username, string? password)
    {
        string filePath = "users.csv";
        string[] users = File.ReadAllLines(filePath).Skip(1).ToArray();

        foreach (var user in users)
        {
            string[] values = user.Split(",");

            if (username?.ToLower() == values[0].ToLower() && password == values[1])
                return true;
        }

        Console.WriteLine("\nUgyldig bruger indtastet");
        Console.ReadKey();
        return false;
    }
}

public class User()
{
    public bool IsLoggedIn { get; set; }
}
