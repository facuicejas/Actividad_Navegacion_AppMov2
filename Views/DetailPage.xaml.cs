using Parcial1Cejas.ViewModels;

namespace Parcial1Cejas.Views;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}