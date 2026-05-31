using Parcial1Cejas.Model;
using Parcial1Cejas.ViewModels;

namespace Parcial1Cejas
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
