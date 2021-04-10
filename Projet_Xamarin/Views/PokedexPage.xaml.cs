using Projet_Xamarin.Models;
using Projet_Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Projet_Xamarin.Views
{
    public partial class PokedexPage : ContentPage
    {
        private bool firstLaunch;
        public PokedexPage()
        {
            InitializeComponent();
            firstLaunch = true;
            BindingContext = new PokedexViewModel(this);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Si c'est la première fois que la page apparait et que le BindingContext est bien un PokedexViewModel
            if(firstLaunch && BindingContext is PokedexViewModel vm)
            {
                // Alors on indique que la page a déjà été affiché, on initialise la liste de Pokémons dans la classe PokemonController
                // Enfin, on initialise l'affichage des pokémons dans la vue principale
                firstLaunch = false;
                await PokemonController.InitAsync();
                vm.InitializeContent();
            }
        }
    }
}
