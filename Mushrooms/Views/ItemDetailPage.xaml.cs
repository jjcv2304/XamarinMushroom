using Mushrooms.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Mushrooms.Views
{
  public partial class ItemDetailPage : ContentPage
  {
    public ItemDetailPage()
    {
      InitializeComponent();
      BindingContext = new ItemDetailViewModel();
    }
  }
}