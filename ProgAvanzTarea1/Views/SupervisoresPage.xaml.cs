using System;

using ProgAvanzTarea1.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProgAvanzTarea1.Views
{
    public sealed partial class SupervisoresPage : Page
    {
        public SupervisoresViewModel ViewModel { get; } = new SupervisoresViewModel();

        public SupervisoresPage()
        {
            InitializeComponent();
        }
    }
}
