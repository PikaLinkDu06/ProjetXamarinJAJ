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
    public partial class PokemonDetailPage : ContentPage
    {
        public PokemonDetailPage(Pokemon pokemon)
        {
            InitializeComponent();
            BindingContext = new PokemonDetailViewModel(pokemon);
        }

        void FavouriteButtonClicked(Object sender, EventArgs args)
        {
            if (BindingContext is PokemonDetailViewModel vm)
            {
                vm.OnFavouriteButtonClicked.Execute(sender);
            }
        }
    }
}