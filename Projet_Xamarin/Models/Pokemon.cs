using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Xamarin.Models
{
    // Classe Pokemon
    // Cette classe contiendra toutes les infos concernant un Pokemon
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int ID { get; set; }
        
        [JsonProperty("types")]
        public List<PokeType> Types { get; set; }
        
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }
        
        [JsonProperty("sprites")]
        public Sprite Sprites { get; set; }

        public partial class PokeType
        {
            [JsonProperty("type")]
            public Type Type { get; set; }
        }

        public partial class Type
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public partial class Sprite
        {
            [JsonProperty("front_default")]
            public string Image { get; set; }
        }
        public bool IsFavorite { get; set; }

    }
}
