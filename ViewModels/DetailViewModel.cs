using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using Parcial1Cejas.Model;

namespace Parcial1Cejas.ViewModels
{
    // Este codigo recibe los parametros que Shell Navigation manda 
    [QueryProperty(nameof(Game), "Game")]
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Game? game;

        partial void OnGameChanged(Game? value)
        {
            // Aca se hace la validacion para ver si se recibio algun dato ingresado por el usuario
            if (value == null)
            {
                Shell.Current.DisplayAlert(
                    "Error",
                    "No se recibieron datos",
                    "OK");

                return;
            }

            // Linea para agregar el Toast de una forma visual
            Toast.Make(
                $"Mostrando {value.Name}")
                .Show();
        }
    }
}