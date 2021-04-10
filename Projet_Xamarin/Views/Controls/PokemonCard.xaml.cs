using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet_Xamarin.Views.Controls
{
    public partial class PokemonCard : ContentView
    {
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(ImageSource), typeof(PokemonCard), null, propertyChanged: (bindable, oldValue, newvalue) =>
        {
            if (newvalue is ImageSource && bindable is PokemonCard)
            {
                ((PokemonCard)bindable).pokeImage.Source = (ImageSource)newvalue;
            }
        });
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(PokemonCard), null, propertyChanged: (bindable, oldValue, newvalue) =>
        {
            if (newvalue is string && bindable is PokemonCard)
            {
                ((PokemonCard)bindable).pokeName.Text = (string)newvalue;
            }
        });
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly BindableProperty OnPokemonTappedProperty = BindableProperty.Create(nameof(OnPokemonTapped), typeof(ICommand), typeof(PokemonCard), null, propertyChanged: (bindable, oldValue, newvalue) =>
        {
            if (newvalue is ICommand && bindable is PokemonCard)
            {
                ((PokemonCard)bindable).gestureRecognizer.Command = (ICommand)newvalue;
            }
        });
        public ICommand OnPokemonTapped
        {
            get { return (ICommand)GetValue(OnPokemonTappedProperty); }
            set { SetValue(OnPokemonTappedProperty, value); }
        }

        public PokemonCard()
        {
            InitializeComponent();
        }
    }
}