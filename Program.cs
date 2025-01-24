namespace pokedex;

class Program
{
    static void Main(string[] args)
    {
        // vis startmenuen
        ShowMenu();
    }

    public static void ShowMenu()
    {
        // deklarer instanser
        Login login = new Login();
        User user = new User();
        PokedexManager pokedex = new PokedexManager();

        // startmenu
        do
        {
            Console.Clear();

            // vis forskellige valgmuligheder ift. om man er logget ind
            if (user.IsLoggedIn)
                Console.WriteLine("1 - Se alle Pokémon\n2 - Søg efter Pokémon\n3 - Redigér pokedex\n9 - Afslut\n");
            else
                Console.WriteLine("1 - Login\n2 - Se alle Pokémon\n3 - Søg efter Pokémon\n9 - Afslut\n");
            string? menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                // forskellige handlinger udfra om man er logget ind
                case "1":
                    if (user.IsLoggedIn)
                        pokedex.ShowAllPokemon(true);
                    else
                        login.ShowLoginMenu(user);
                    break;
                case "2":
                    if (user.IsLoggedIn)
                        pokedex.SearchPokemon();
                    else
                        pokedex.ShowAllPokemon();
                    break;
                case "3":
                    if (user.IsLoggedIn)
                        pokedex.EditPokedexMenu();
                    else
                        pokedex.SearchPokemon();
                    break;
                case "9":
                    Console.Clear();
                    Console.WriteLine("Lukker programmet...");
                    Thread.Sleep(1250);
                    Console.Clear();
                    // lukker programmet
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nForkert input, tryk på en tast for at prøve igen");
                    Console.ReadKey();
                    break;
            }
        } while (true);
    }
}
