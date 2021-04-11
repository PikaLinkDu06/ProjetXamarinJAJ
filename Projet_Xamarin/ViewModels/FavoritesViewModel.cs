using Projet_Xamarin.Models;
using Projet_Xamarin.Views;
using Projet_Xamarin.Views.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Projet_Xamarin.ViewModels
{
    public class FavoritesViewModel : BaseViewModel
    {
        // On stocke la page, les pokémons à afficher et on définit une constante qui representera le nombre de pokemon sur chaque ligne
        private FavoritesPage favoritePage;
        private List<Pokemon> shownPokemon;
        private const int MAX_POKEMON_BY_ROW = 2;
        public FavoritesViewModel(FavoritesPage page)
        {
            favoritePage = page;
            IsBusy = true;
        }

        public void InitFavoritePokemon()
        {
            // On definit la liste de Pokémons a afficher en fonction des pokémons favoris
            shownPokemon = PokemonController.Pokemons.FindAll(pokemon => pokemon.IsFavorite == true);
            StackLayout mainLayout = (StackLayout)favoritePage.Content.FindByName("favoriteContent");
            StackLayout tmpLayout = new StackLayout();
            tmpLayout.Orientation = StackOrientation.Horizontal;

            // On va boucler sur cette liste de Pokémons afin de permettre l'affichage des différents Pokémons
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

        // Fontion lancée lorsque l'on appuie sur un Pokémon
        // Cette fonction sert a aller sur la page de detail du Pokémon selectionné
        private void PokemonClicked(object obj)
        {
            favoritePage.Navigation.PushAsync(new PokemonDetailPage((Pokemon)obj));
        }

    }
}
