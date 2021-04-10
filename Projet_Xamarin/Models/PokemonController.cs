using Newtonsoft.Json;
using Projet_Xamarin.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Projet_Xamarin.Models
{
    // Classe PokemonController 
    // Cette classe servira à stocker les différents Pokémons obtenus lors des requetes HTTP
    public static class PokemonController
    {
        private static List<Pokemon> pokemons = new List<Pokemon>() ;
        private static bool taskCompleted = false ;
        public static bool TaskCompleted { get { return taskCompleted; } }
        public static List<Pokemon> Pokemons
        {
            get { return pokemons; }
        }

        // Fonction asynchrone qui permet l'initialisation des valeurs dans la liste de pokemons
        public static async Task InitAsync()
        {            
            // On cree 6 taches différentes avec des intervalles pour les ID de Pokémon différents 
            var task1 = GetPokemonFromRange(1, 25);
            var task2 = GetPokemonFromRange(26, 50);
            var task3 = GetPokemonFromRange(51, 75);
            var task4 = GetPokemonFromRange(76, 100);
            var task5 = GetPokemonFromRange(101, 125);
            var task6 = GetPokemonFromRange(126, 151);     
            // On lance toutes les taches en même temps (ceci afin de permettre de réduire le temps de récupération des données)
            await Task.WhenAll(task1, task2, task3, task4, task5, task6); 
            // On trie la liste des Pokémons par ordre croissant des ID
            Pokemons.Sort((pokemon1, pokemon2) => pokemon1.ID - pokemon2.ID);
            // On indique dans la variable taskCompleted que toutes les taches viennent d'etres terminées
            taskCompleted = true;
        }

        private static async Task GetPokemonFromRange(int min, int max)
        {
            // Fonction nous permettant de faire des requetes HTTP GET sur l'API pokeapi
            var client = HttpService.GetInstance();
            for (int i = min; i <= max; i++)
            {
                var result = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{i}");
                var serializedResponse = await result.Content.ReadAsStringAsync();
                var pokemonResponse = JsonConvert.DeserializeObject<Pokemon>(serializedResponse);
                if (pokemonResponse != null)
                {
                    // On definit depuis les User Preferences si le Pokémon est un pokémon enregistré en favoris
                    pokemonResponse.IsFavorite = Preferences.Get("fav_pokemon_" + pokemonResponse.ID, false);
                    // Enfin, on ajoute le Pokemon a la liste de Pokémons
                    pokemons.Add(pokemonResponse);
                }
            }
        }
    }
}
