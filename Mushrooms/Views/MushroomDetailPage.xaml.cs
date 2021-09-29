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
    public partial class MushroomDetailPage : ContentPage
    {
        public MushroomDetailPage()
        {
            InitializeComponent();
            BindingContext = new MushroomDetailViewModel();
        }
    }
}