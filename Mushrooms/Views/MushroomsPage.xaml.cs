using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mushrooms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mushrooms.Views
{
    public partial class MushroomsPage : ContentPage
    {
        private MushroomsViewModel _mushroomsViewModel;
        public MushroomsPage()
        {
            InitializeComponent();
            BindingContext = _mushroomsViewModel = new MushroomsViewModel();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _mushroomsViewModel.OnAppearing();
        }
    }
}