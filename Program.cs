namespace pokedex;

class Program
{
    static void Main(string[] args)
    {
        ShowMenu();
    }

    public static void ShowMenu()
    {
        Login login = new Login();
        User user = new User();
        PokedexManager pokedex = new PokedexManager();

        do
        {
            Console.Clear();
            if (user.IsLoggedIn)
                Console.WriteLine("1 - Se alle Pokémon\n2 - Søg efter Pokémon\n3 - Redigér pokedex\n9 - Afslut\n");
            else
                Console.WriteLine("1 - Login\n2 - Se alle Pokémon\n3 - Søg efter Pokémon\n9 - Afslut\n");

            string? menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
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
