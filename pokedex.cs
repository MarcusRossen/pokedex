namespace pokedex;

public class PokedexManager()
{
    public void ShowAllPokemon(bool showId = false)
    {
        ConsoleKey input;

        string filePath = "pokedex.csv";
        string[] allPokemon = File.ReadAllLines(filePath).Skip(1).ToArray();

        int currentPage = 1;
        int perPage = 5;
        int totalPage = (int)Math.Ceiling((double)allPokemon.Length / perPage);

        do
        {
            Console.Clear();

            Console.WriteLine($"Side: {currentPage}/{totalPage}");

            for (int i = (currentPage - 1) * perPage; i < currentPage * perPage; i++)
            {
                if (i < allPokemon.Length)
                {
                    string[] values = allPokemon[i].Split(",");
                    if (showId)
                        Console.WriteLine($"ID: {values[0]}, Name: {values[1]}, Type: {values[2]}, Strength: {values[3]}");
                    else
                        Console.WriteLine($"Name: {values[1]}, Type: {values[2]}, Strength: {values[3]}");
                }
            }

            Console.WriteLine("\n'Escape' for at gå tilbage");

            input = Console.ReadKey().Key;
            if (input == ConsoleKey.RightArrow && currentPage < totalPage)
                currentPage++;
            else if (input == ConsoleKey.LeftArrow && currentPage > 1)
                currentPage--;
        } while (input != ConsoleKey.Escape);
    }

    public void SearchPokemon()
    {
        Console.Clear();

        string filePath = "pokedex.csv";
        string[] allPokemon = File.ReadAllLines(filePath).Skip(1).ToArray();

        Console.Write("Søg efter Pokémon navn eller type: ");
        string? input = Console.ReadLine();

        foreach (var pokemon in allPokemon)
        {
            string[] values = pokemon.Split(",");

            if (values[1].ToLower().Contains(input.ToLower()) || values[2].ToLower().Contains(input.ToLower()))
                Console.WriteLine($" -  Name: {values[1]}, Type: {values[2]}, Strength: {values[3]}");
        }

        Console.ReadKey();
    }

    public void EditPokedexMenu()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("1 - Tilføj Pokémon\n2 - Redigér Pokémon\n3 - Slet Pokémon\n9 - Tilbage\n");
            string? menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    AddPokemon();
                    break;
                case "2":
                    EditPokemon();
                    break;
                case "3":
                    RemovePokemon();
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("\nForkert input, tryk på en tast for at prøve igen");
                    Console.ReadKey();
                    break;
            }
        } while (true);
    }

    private void AddPokemon()
    {
        Console.Clear();
        Console.Write("Pokemon navn: ");
        string? pokemonName = Console.ReadLine();

        Console.Write("Pokemon type: ");
        string? pokemonType = Console.ReadLine();

        Console.Write("Pokemon styrke: ");
        string? pokemonStrength = Console.ReadLine();

        string filePath = "pokedex.csv";
        string[] allPokemon = File.ReadAllLines(filePath);
        string? nextId = (Convert.ToInt32(allPokemon.Skip(allPokemon.Length - 1).ToArray()[0].Split(",")[0]) + 1).ToString();
        File.AppendAllText(filePath, $"{nextId},{pokemonName},{pokemonType},{pokemonStrength}\n");

        Console.WriteLine("\nPokémon tilføjet...");
        Console.ReadKey();
    }

    private void EditPokemon()
    {
        Console.Clear();
        Console.Write("ID'et på den Pokémon du vil redigere: ");
        string? pokemonToEdit = Console.ReadLine();

        string filePath = "pokedex.csv";
        string[] allPokemon = File.ReadAllLines(filePath);
        List<string> updatedPokemon = new List<string>();

        foreach (var pokemon in allPokemon)
        {
            string[] values = pokemon.Split(",");

            if (values[0] == Convert.ToString(pokemonToEdit))
            {
                Console.Write("Nyt navn (tryk Enter for at beholde det samme): ");
                string? newName = Console.ReadLine();
                if (string.IsNullOrEmpty(newName))
                    newName = values[1];

                Console.Write("Ny type (tryk Enter for at beholde det samme): ");
                string? newType = Console.ReadLine();
                if (string.IsNullOrEmpty(newType))
                    newType = values[2];

                Console.Write("Ny styrke (tryk Enter for at beholde det samme): ");
                string? newStrength = Console.ReadLine();
                if (string.IsNullOrEmpty(newStrength))
                    newStrength = values[3];

                updatedPokemon.Add($"{values[0]},{newName},{newType},{newStrength}");
            }
            else
                updatedPokemon.Add(pokemon);
        }

        File.WriteAllLines(filePath, updatedPokemon);

        Console.WriteLine("\nPokémon redigeret...");
        Console.ReadKey();
    }

    private void RemovePokemon()
    {
        Console.Clear();
        Console.Write("ID'et på den Pokémon du vil fjerne: ");
        int pokemonToRemove = Convert.ToInt32(Console.ReadLine());

        string filePath = "pokedex.csv";
        string[] allPokemon = File.ReadAllLines(filePath);
        List<string> tempList = new List<string>();

        foreach (var pokemon in allPokemon)
        {
            string[] values = pokemon.Split(",");

            if (values[0] == Convert.ToString(pokemonToRemove))
                Console.WriteLine($" -  ID: {values[0]}, Name: {values[1]}, Type: {values[2]}, Strength: {values[3]}");
            else
                tempList.Add(pokemon);
        }

        File.WriteAllLines(filePath, tempList);

        Console.WriteLine("\nPokémon fjernet...");
        Console.ReadKey();
    }
}
