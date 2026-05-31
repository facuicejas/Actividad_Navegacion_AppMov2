using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Parcial1Cejas.Messages;
using Parcial1Cejas.Model;
using Parcial1Cejas.Services;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;

namespace Parcial1Cejas.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ApiService _api;
        private readonly NavigationService _navigation;

        [ObservableProperty]
        private ObservableCollection<Game> games = new();

        private List<Game> allGames = new();

        [ObservableProperty]
        private string status = "";

        [ObservableProperty]
        private string searchText = "";

        public MainViewModel(
            ApiService api,
            NavigationService navigation)
        {
            _api = api;
            _navigation = navigation;

            // Esta linea manda un mensaje cuando se agrega un juego
            WeakReferenceMessenger.Default.Register<GameAddedMessage>(
                this,
                (r, m) =>
                {
                    Games.Insert(0, m.Game);
                    allGames.Insert(0, m.Game);
                });

            LoadGamesCommand.Execute(null);
        }

        [RelayCommand]
        public async Task LoadGames()
        {
            try
            {
                Status = "Cargando juegos...";

                var list = await _api.GetGames();

                allGames = list;

                Games.Clear();

                foreach (var game in list)
                {
                    Games.Add(game);
                }

                Status = $"Se cargaron {Games.Count} juegos";

                await Toast.Make("Lista cargada")
                    .Show();
            }
            catch (Exception ex)
            {
                Status = ex.Message;

                await Toast.Make("Error al cargar")
                    .Show();
            }
        }

        [RelayCommand]
        public void FilterGames()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Games.Clear();

                foreach (var g in allGames)
                    Games.Add(g);

                return;
            }

            var filtered = allGames
                .Where(g =>
                    g.Name != null &&
                    g.Name.Contains(
                        SearchText,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            Games.Clear();

            foreach (var g in filtered)
            {
                Games.Add(g);
            }
        }

        // Esta es la parte de la Navegacion, que esta centralizada 
        [RelayCommand]
        public async Task GoToDetail(Game game)
        {
            if (game == null)
            {
                await Toast.Make(
                    "Juego inválido")
                    .Show();

                return;
            }

            await _navigation.GoToDetailAsync(game);
        }

        [RelayCommand]
        public async Task GoToAdd()
        {
            await _navigation.GoToAddGameAsync();
        }
    }
}