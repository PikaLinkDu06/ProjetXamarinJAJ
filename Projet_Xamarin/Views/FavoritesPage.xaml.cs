using Projet_Xamarin.Models;
using Projet_Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet_Xamarin.Views
{
    public partial class FavoritesPage : ContentPage
    {
        public FavoritesPage()
        {
            InitializeComponent();
            BindingContext = new FavoritesViewModel(this);
        }

        protected override void OnAppearing()
        {            
            base.OnAppearing();
            // Lorsque la page s'affiche on vérifie que la variable TaskCompleted de la classe PokemonController est bien vraie et que le BindingContext est bien un FavoritesViewModel 
            if (PokemonController.TaskCompleted && BindingContext is FavoritesViewModel vm)
            {
                // Alors dans ce cas on supprime tous les enfants du StackLayout principal et on affiche les Pokemons favoris
                favoriteContent.Children.Clear();
                vm.InitFavoritePokemon() ;
            }
        }
    }
}