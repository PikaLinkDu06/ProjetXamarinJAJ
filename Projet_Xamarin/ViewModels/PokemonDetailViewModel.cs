using Projet_Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Projet_Xamarin.ViewModels
{
    public class PokemonDetailViewModel : BaseViewModel
    {
        private Pokemon currentPokemon;
        public string Image { get; set; } 
        public string PokemonName { get; set; }
        public string PokemonType { get; set; }
        public string PokemonID { get; set; }
        public string PokemonHeight { get; set; }
        public string PokemonWeight { get; set; }

        private ImageSource favouriteImage;
        public ImageSource FavouriteImage { get { return favouriteImage; } set { SetProperty(ref favouriteImage, value); } }

        public PokemonDetailViewModel(Pokemon pokemon)
        {
            currentPokemon = pokemon;
            Image = pokemon.Sprites.Image;
            PokemonName = pokemon.Name;
            string tmpStr = "";
            pokemon.Types.ForEach(type => tmpStr += type.Type.Name + ", ");
            tmpStr = tmpStr.Substring(0, tmpStr.Length - 2);
            PokemonType = tmpStr;
            PokemonID = "" + pokemon.ID;
            PokemonHeight = "" + pokemon.Height;
            PokemonWeight = "" + pokemon.Weight;           
            if(pokemon.IsFavorite) FavouriteImage = "ic_favorite.png";
            else FavouriteImage = "ic_favorite_border.png";
        }

        // Fonction permettant de gerer le click sur l'ImageButton qui indique a l'utilisateur l'etat de l'ajout en favoris
        public ICommand OnFavouriteButtonClicked { get { return new Command(FavouriteButtonClicked); } }
        private void FavouriteButtonClicked(object obj)
        {
            // Si le Pokémon est dans les favoris alors on le supprime et on change l'image
            if(currentPokemon.IsFavorite)
            {
                currentPokemon.IsFavorite = false;
                FavouriteImage = "ic_favorite_border.png";
                Preferences.Set("fav_pokemon_" + currentPokemon.ID, false);
            } 
            // Sinon on ajoute le Pokémon en tant que pokémon favoris
            else
            {
                currentPokemon.IsFavorite = true;
                FavouriteImage = "ic_favorite.png";
                Preferences.Set("fav_pokemon_" + currentPokemon.ID, true);
            }
        }
    }
}
