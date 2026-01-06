using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProyectoUWPenBlanco
{
    public sealed partial class PokedexPage : Page
    {
        public List<Pokemon> ListaPokemon { get; set; }
        private List<Pokemon> ListaPokemonOriginal { get; set; }

        public PokedexPage()
        {
            this.InitializeComponent();

            // Lista original de Pokémon
            ListaPokemonOriginal = new List<Pokemon>()
            {
                new Pokemon { Nombre = "Pikachu", Tipo = "Eléctrico", Imagen = "ms-appx:///AssetsGrupal/pikachu.png", Descripcion = "Ratón eléctrico muy popular." },
                new Pokemon { Nombre = "Charmander", Tipo = "Fuego", Imagen = "ms-appx:///AssetsGrupal/charmander.png", Descripcion = "Lagarto de fuego con una llama en la cola." },
                new Pokemon { Nombre = "Mankey", Tipo = "Lucha", Imagen = "ms-appx:///AssetsGrupal/mankey.png", Descripcion = "Mono agresivo que reacciona al menor estímulo." },
                new Pokemon { Nombre = "Gardevoir", Tipo = "Psíquico / Hada", Imagen = "ms-appx:///AssetsGrupal/Gardevoir.png", Descripcion = "Protegerá a su entrenador incluso a costa de su vida." },
                new Pokemon { Nombre = "Gengar", Tipo = "Fantasma / Veneno", Imagen = "ms-appx:///AssetsGrupal/Gengar2.png", Descripcion = "Acecha en la sombra con una risa escalofriante." },
                new Pokemon { Nombre = "Swablu", Tipo = "Normal / Volador", Imagen = "ms-appx:///AssetsGrupal/Swablu.png", Descripcion = "Sus alas parecen nubes, se posa sobre cabezas humanas." },
                new Pokemon { Nombre = "Rowlet", Tipo = "Planta / Volador", Imagen = "ms-appx:///AssetsGrupal/Rowlet.png", Descripcion = "Ataca lanzando hojas con precisión desde su pico." },
                new Pokemon { Nombre = "Wartortle", Tipo = "Agua", Imagen = "ms-appx:///AssetsGrupal/Wartortle.png", Descripcion = "Sus orejas peludas simbolizan longevidad." },
                new Pokemon { Nombre = "Mimikyu", Tipo = "Fantasma / Hada", Imagen = "ms-appx:///AssetsGrupal/Mimikyu.png", Descripcion = "Se disfraza de Pikachu para hacer amigos." },
                new Pokemon { Nombre = "Psyduck", Tipo = "Agua", Imagen = "ms-appx:///AssetsGrupal/Psyduck.png", Descripcion = "Sufre constantes dolores de cabeza que potencian sus poderes psíquicos." },
                new Pokemon { Nombre = "Riolu", Tipo = "Lucha", Imagen = "ms-appx:///AssetsGrupal/Riolu.png", Descripcion = "Comprende los sentimientos y emociones de otros Pokémon." },
                new Pokemon { Nombre = "Sprigatito", Tipo = "Planta", Imagen = "ms-appx:///AssetsGrupal/Sprigatito.png", Descripcion = "Un felino lleno de curiosidad y con aroma embriagador." },
                new Pokemon { Nombre = "Victini", Tipo = "Psíquico / Fuego", Imagen = "ms-appx:///AssetsGrupal/Victini.png", Descripcion = "Se dice que da la victoria a quien lo posee." },
                new Pokemon { Nombre = "Corphish", Tipo = "Agua", Imagen = "ms-appx:///AssetsGrupal/Corphish.png", Descripcion = "Pequeño crustáceo extremadamente resistente." },
                new Pokemon { Nombre = "Geodude", Tipo = "Roca / Tierra", Imagen = "ms-appx:///AssetsGrupal/Geodude.png", Descripcion = "Suele confundirse con piedras al descansar en caminos." },
                new Pokemon { Nombre = "Pignite", Tipo = "Fuego / Lucha", Imagen = "ms-appx:///AssetsGrupal/Pignite.png", Descripcion = "Cuando corre, las llamas de su nariz se intensifican. Le encanta luchar cuerpo a cuerpo." },
                new Pokemon { Nombre = "Pachirisu", Tipo = "Eléctrico", Imagen = "ms-appx:///AssetsGrupal/Pachirisu.png", Descripcion = "Ardilla hiperactiva que almacena electricidad en sus mejillas." },
                new Pokemon { Nombre = "Azumarill", Tipo = "Agua / Hada", Imagen = "ms-appx:///AssetsGrupal/Azumarill.png", Descripcion = "Puede hacer estallar burbujas mientras nada ágilmente." },
                new Pokemon { Nombre = "Bulbasaur", Tipo = "Planta / Veneno", Imagen = "ms-appx:///AssetsGrupal/bulbasaur.png", Descripcion = "Tiene una semilla en la espalda desde que nace." },
                new Pokemon { Nombre = "Dunsparce", Tipo = "Normal", Imagen = "ms-appx:///AssetsGrupal/Dunsparce.png", Descripcion = "Cava su madriguera usando su cola en forma de taladro." },
                new Pokemon { Nombre = "Golbat", Tipo = "Veneno / Volador", Imagen = "ms-appx:///AssetsGrupal/Golbat.png", Descripcion = "Succiona la sangre de sus víctimas con sus afilados colmillos." },
                new Pokemon { Nombre = "Horsea", Tipo = "Agua", Imagen = "ms-appx:///AssetsGrupal/Horsea.png", Descripcion = "Nada hábilmente y escupe tinta para defenderse." },
                new Pokemon { Nombre = "Oshawott", Tipo = "Agua", Imagen = "ms-appx:///AssetsGrupal/Oshawott.png", Descripcion = "Usa su concha para cortar y defenderse." },
                new Pokemon { Nombre = "Pichu", Tipo = "Eléctrico", Imagen = "ms-appx:///AssetsGrupal/Pichu.png", Descripcion = "Su electricidad es inestable, pero lo hace adorable." },
                new Pokemon { Nombre = "Porygon", Tipo = "Normal", Imagen = "ms-appx:///AssetsGrupal/Porygon.png", Descripcion = "Pokémon virtual creado completamente con código." },
                new Pokemon { Nombre = "Regice", Tipo = "Hielo", Imagen = "ms-appx:///AssetsGrupal/Regice.png", Descripcion = "Su cuerpo de hielo eterno lo protege del calor." },
                new Pokemon { Nombre = "Zygarde", Tipo = "Dragón / Tierra", Imagen = "ms-appx:///AssetsGrupal/Zygarde.png", Descripcion = "Protege el ecosistema desde las profundidades." }
            };

            // Ordenar alfabéticamente
            ListaPokemonOriginal = ListaPokemonOriginal.OrderBy(p => p.Nombre).ToList();

            // Inicializar la lista de Pokémon visible
            ListaPokemon = new List<Pokemon>(ListaPokemonOriginal);
            this.DataContext = this;

            // Poblar ComboBox con tipos
            var tipos = ListaPokemonOriginal
                .Select(p => p.Tipo)
                .SelectMany(t => t.Split('/'))
                .Select(t => t.Trim())
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            tipos.Insert(0, "Todos"); // opción para mostrar todos
            cbTipos.ItemsSource = tipos;
            cbTipos.SelectedIndex = 0;
        }

        private void gvPokedex_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pokemonSeleccionado = e.ClickedItem as Pokemon;
            Frame.Navigate(typeof(InfoPokemonPage), pokemonSeleccionado);
        }

        private void cbTipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tipoSeleccionado = cbTipos.SelectedItem as string;

            if (tipoSeleccionado == "Todos")
            {
                ListaPokemon = new List<Pokemon>(ListaPokemonOriginal);
            }
            else
            {
                ListaPokemon = ListaPokemonOriginal
                    .Where(p => p.Tipo.Contains(tipoSeleccionado))
                    .ToList();
            }

            gvPokedex.ItemsSource = ListaPokemon;
        }
        private void tbBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            string textoBusqueda = tbBusqueda.Text.ToLower();
            string tipoSeleccionado = cbTipos.SelectedItem as string;

            IEnumerable<Pokemon> listaFiltrada = ListaPokemonOriginal;

            // Filtrado por tipo
            if (tipoSeleccionado != "Todos")
            {
                listaFiltrada = listaFiltrada.Where(p => p.Tipo.ToLower().Contains(tipoSeleccionado.ToLower()));
            }

            // Filtrado por nombre
            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                listaFiltrada = listaFiltrada.Where(p => p.Nombre.ToLower().Contains(textoBusqueda));
            }

            ListaPokemon = listaFiltrada.ToList();
            gvPokedex.ItemsSource = ListaPokemon;
        }

    }
}
