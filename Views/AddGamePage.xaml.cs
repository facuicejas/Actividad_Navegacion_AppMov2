using Parcial1Cejas.ViewModels;

namespace Parcial1Cejas.Views;

public partial class AddGamePage : ContentPage
{
    public AddGamePage(AddGameViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}