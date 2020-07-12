using System;

using ProgAvanzTarea1.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProgAvanzTarea1.Views
{
    public sealed partial class RegistrosPage : Page
    {
        public RegistrosViewModel ViewModel { get; } = new RegistrosViewModel();

        public RegistrosPage()
        {
            InitializeComponent();
        }
    }
}
