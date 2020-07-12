using System;

using ProgAvanzTarea1.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProgAvanzTarea1.Views
{
    public sealed partial class CajerosPage : Page
    {
        public CajerosViewModel ViewModel { get; } = new CajerosViewModel();

        public CajerosPage()
        {
            InitializeComponent();
        }
    }
}
