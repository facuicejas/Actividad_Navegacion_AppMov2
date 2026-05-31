using Parcial1Cejas.Model;

namespace Parcial1Cejas.Services
{
    // Todo esto es el servicio de navegacion centralizada que hay en el programa 
    public class NavigationService
    {
        // Con esta linea se navega hasta a pantalla de los detalles
        public async Task GoToDetailAsync(Game game)
        {
            // Linea para poder hacer la validacin del parametro del juego
            if (game == null)
            {
                await Shell.Current.DisplayAlert(
                    "Error",
                    "No se pudo abrir el detalle del juego",
                    "OK");

                return;
            }

            // Aca se navega usando el shell 
            await Shell.Current.GoToAsync(
                nameof(Views.DetailPage),
                true,
                new Dictionary<string, object>
                {
                    { "Game", game }
                });
        }

        // Con esta linea se navega hasta la pantalla para agregar juegos
        public async Task GoToAddGameAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.AddGamePage));
        }

        // Con esta linea se vuelve para atras en el codigo
        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}