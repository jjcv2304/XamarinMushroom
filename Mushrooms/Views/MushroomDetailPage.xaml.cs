using Mushrooms.Utils;
using Xamarin.Forms;

namespace Mushrooms.Views
{
    public partial class MushroomDetailPage : ContentPage
    {
        public MushroomDetailPage()
        {
            InitializeComponent();
      this.BindingContext = ViewModelLocator.MushroomDetailVM;
    }
    }
}