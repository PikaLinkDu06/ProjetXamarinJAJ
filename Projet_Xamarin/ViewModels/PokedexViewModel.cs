using Projet_Xamarin.Models;
using Projet_Xamarin.Views;
using Projet_Xamarin.Views.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projet_Xamarin.ViewModels
{
    public class PokedexViewModel : BaseViewModel
    {
        // On stocke la page Pokedex, une liste de pokémon a afficher, un filtre (pour le bouton recherche) ainsi que le nombre max de pokémon sur chaque ligne
        private PokedexPage currentPage;
        private List<Pokemon> shownPokemon;
        string filter = "";
        private const int MAX_POKEMON_BY_ROW = 2;  
        public string Filter
        {
            get { return filter; }
            set { SetProperty(ref filter, value); }
        }
        public PokedexViewModel(PokedexPage page)
        {
            currentPage = page;
            IsBusy = true;
        }

        // Fonction servant a initialiser l'affichage de la liste de Pokémons 
        public void InitializeContent()
        { 
            shownPokemon = PokemonController.Pokemons;
            StackLayout mainLayout = (StackLayout)currentPage.Content.FindByName("contentStack");
            StackLayout tmpLayout = new StackLayout();
            tmpLayout.Orientation = StackOrientation.Horizontal;

            // On boucle afin de creer l'affichage des différents Pokémons contenus dans la classe PokemonController
            for (int i = 0; i < shownPokemon.Count; i++)
            {                                
                if (((i % MAX_POKEMON_BY_ROW) == 0) && i != 0)
                {              
                    mainLayout.Children.Add(tmpLayout);
                    tmpLayout = new StackLayout();
                    tmpLayout.Orientation = StackOrientation.Horizontal;
                }
                Pokemon currentPokemon = shownPokemon[i];
                PokemonCard PC = new PokemonCard();
                PC.Image = currentPokemon.Sprites.Image;
                PC.Name = currentPokemon.Name;
                PC.OnPokemonTapped = new Command(() => PokemonClicked(currentPokemon));
                tmpLayout.Children.Add(PC);
            }
            if (tmpLayout.Children.Count != 0) mainLayout.Children.Add(tmpLayout);
            IsBusy = false;
        }

        // Fonction qui s'execute lorsque l'on clique sur un Pokémon
        // Elle sert à afficher la page de détail du Pokémon sélectionné
        private void PokemonClicked(object obj)
        {
            currentPage.Navigation.PushAsync(new PokemonDetailPage((Pokemon)obj));
        }

        // Fonction appelée lorsaue lùon appuie sur le bouton "Search" qui permet de rechercher un Pokémon spécifique
        public ICommand SearchSpecifiedPokemon => new Command(SearchPokemon);
        private void SearchPokemon(object obj)
        {
            // On définit une expression reguliere en fonction du filtre
            Regex rgx = new Regex("^" + Filter);
            // Si le filtre n'est pas vide alors on souhaite afficher tous les Pokémons qui matchent avec le regex
            if (!Filter.Equals("")) shownPokemon = PokemonController.Pokemons.FindAll(pokemon => rgx.IsMatch(pokemon.Name));
            // Sinon on recharge entièrement la liste des Pokémons
            else shownPokemon = PokemonController.Pokemons;
            // On lance la fonction reloadContent() 
            reloadContent();
        }

        // Cette fonction permet de recharger l'affichage des Pokémons sur la page Pokedex
        private void reloadContent()
        {
            IsBusy = true;
            StackLayout mainLayout = (StackLayout)currentPage.Content.FindByName("contentStack");
            mainLayout.Children.Clear();

            StackLayout tmpLayout = new StackLayout();
            tmpLayout.Orientation = StackOrientation.Horizontal;

            for (int i = 0; i < shownPokemon.Count; i++)
            {
                if (((i % MAX_POKEMON_BY_ROW) == 0) && i != 0)
                {
                    mainLayout.Children.Add(tmpLayout);
                    tmpLayout = new StackLayout();
                    tmpLayout.Orientation = StackOrientation.Horizontal;
                }
                Pokemon currentPokemon = shownPokemon[i];
                PokemonCard PC = new PokemonCard();
                PC.Image = currentPokemon.Sprites.Image ;
                PC.Name = currentPokemon.Name ;
                PC.OnPokemonTapped = new Command(() => PokemonClicked(currentPokemon));
                tmpLayout.Children.Add(PC);
            }
            if (tmpLayout.Children.Count != 0) mainLayout.Children.Add(tmpLayout);
            IsBusy = false;
        }

    }
}
