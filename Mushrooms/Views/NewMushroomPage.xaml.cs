using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mushrooms.Models;
using Mushrooms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mushrooms.Views
{
    public partial class NewMushroomPage : ContentPage
    {
        internal Mushroom Mushroom { get; set; }
        
        public NewMushroomPage()
        {
            InitializeComponent();
            BindingContext = new NewMushroomViewModel();
        }
    }
}