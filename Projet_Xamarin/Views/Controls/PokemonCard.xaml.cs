using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet_Xamarin.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonCard : ContentView
    {
        public PokemonCard()
        {
            InitializeComponent();
        }
    }
}