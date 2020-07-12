using System;

using ProgAvanzTarea1.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProgAvanzTarea1.Views
{
    public sealed partial class ProductoPage : Page
    {
        public ProductoViewModel ViewModel { get; } = new ProductoViewModel();

        public ProductoPage()
        {
            InitializeComponent();
        }
    }
}
