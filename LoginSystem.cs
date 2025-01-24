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

            // checkLogin() returnere true eller false, sæt IsLoggedIn til det
            user.IsLoggedIn = CheckLogin(username, password);
        } while (!user.IsLoggedIn); // bliv i loopet så længe IsLoggedIn er falsk

        Console.WriteLine("\nLogin succesfuldt...");
        Thread.Sleep(1250);
    }

    public bool CheckLogin(string? username, string? password) // parameter til at tage input username og -password med
    {
        string filePath = "users.csv";
        string[] users = File.ReadAllLines(filePath).Skip(1).ToArray();

        foreach (var user in users)
        {
            string[] values = user.Split(",");

            // tjek input med users.csv fil, brugernavn er case-insensitive
            if (username?.ToLower() == values[0].ToLower() && password == values[1])
                // hvis alt passer, return true
                return true;
        }

        Console.WriteLine("\nUgyldig bruger indtastet");
        Console.ReadKey();
        // hvis det ikke passer, return false, for at blive i loopet og prøve igen
        return false;
    }
}

public class User()
{
    // hold styr på om brugeren er logget ind
    public bool IsLoggedIn { get; set; }
}
