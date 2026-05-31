using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Parcial1Cejas.Messages;
using Parcial1Cejas.Model;
using Parcial1Cejas.Services;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace Parcial1Cejas.ViewModels
{
    public partial class AddGameViewModel : ObservableObject
    {
        private readonly ApiService _api;
        private readonly NavigationService _navigation;

        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private string? genre;

        [ObservableProperty]
        private string? developer;

        [ObservableProperty]
        private string? publisher;

        [ObservableProperty]
        private string? status;

        public AddGameViewModel(
            ApiService api,
            NavigationService navigation)
        {
            _api = api;
            _navigation = navigation;
        }

        [RelayCommand]
        public async Task AddGame()
        {
            // Validacion para revisar si se introdujo un nombre al juego
            if (string.IsNullOrWhiteSpace(Name))
            {
                Status = "Debe ingresar un nombre";

                await Toast.Make("Falta el nombre del juego")
                    .Show();

                return;
            }

            try
            {
                var game = new Game
                {
                    Name = Name,
                    Genre = Genre,
                    Developer = Developer,
                    Publisher = Publisher
                };

                await _api.AddGame(game);

                // Este es un Mensaje que es recibido entre ViewModels
                WeakReferenceMessenger.Default.Send(
                    new GameAddedMessage
                    {
                        Game = game
                    });

                Status = "Juego agregado correctamente";

                // Linea para agregar el Toast de una forma visual
                await Toast.Make(
                    $"Juego {game.Name} agregado")
                    .Show();

                // Con esta linea se puede volver para atras en el codigo
                await _navigation.GoBackAsync();
            }
            catch (Exception ex)
            {
                Status = ex.Message;

                await Toast.Make(
                    "Error al guardar")
                    .Show();
            }
        }
    }
}