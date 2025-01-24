# Pokedex Console Application

Dette projekt er en konsolapplikation skrevet i C#. Den fungerer som et Pokédex, hvor brugere kan logge ind, se en liste over Pokémon, søge efter Pokémon, samt tilføje, redigere og slette Pokémon.

## Funktioner

- **Brugerstyring:**
  - Login-system baseret på en `users.csv`-fil.

- **Pokédex-funktionalitet:**
  - Se alle Pokémon med mulighed for at navigere mellem sider.
  - Søg efter Pokémon baseret på navn eller type.
  - Tilføj, rediger eller slet Pokémon (kræver login).

## Filstruktur

- **`pokedex.csv`**: Indeholder data om alle Pokémon i formatet `ID,Name,Type,Strength`. Der er 10 pre defineret Pokémon.
- **`users.csv`**: Indeholder brugere i formatet `Username,Password`. Du kan bruge standard login `admin/admin`, for at logge på.

## Usage

1. **Login**: Brugere skal logge ind for at få adgang til at tilføje, redigere og slette Pokémon i Pokédexet.
2. **View All Pokemon**: Vis alle Pokémon i Pokédexet. Du kan også se ID'et hvis du er logget ind.
3. **Search Pokemon**: Søg efter navn eller type for at få en liste med resultater.
4. **Edit Pokedex**: Tilføj, redigere eller slet Pokémon i Pokédexet.
