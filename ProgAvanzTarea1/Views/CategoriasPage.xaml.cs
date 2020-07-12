using System;

using ProgAvanzTarea1.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProgAvanzTarea1.Views
{
    public sealed partial class CategoriasPage : Page
    {
        public CategoriasViewModel ViewModel { get; } = new CategoriasViewModel();

        public CategoriasPage()
        {
            InitializeComponent();
        }
    }
}
