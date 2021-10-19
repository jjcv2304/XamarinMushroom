using Mushrooms.ViewModels;
using Mushrooms.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Mushrooms
{
  public partial class AppShell : Xamarin.Forms.Shell
  {
    public AppShell()
    {
      InitializeComponent();
      //todo check theory of routes usage
      Routing.RegisterRoute(nameof(MushroomDetailPage), typeof(MushroomDetailPage));
      Routing.RegisterRoute(nameof(NewMushroomPage), typeof(NewMushroomPage));

      Routing.RegisterRoute(nameof(IdentifyMushroomPage), typeof(IdentifyMushroomPage));
      Routing.RegisterRoute(nameof(MushroomLibraryPage), typeof(MushroomLibraryPage));
      Routing.RegisterRoute(nameof(MushroomDiaryPage), typeof(MushroomDiaryPage));
      Routing.RegisterRoute(nameof(ImportDataPage), typeof(ImportDataPage));
      Routing.RegisterRoute(nameof(ExportDataPage), typeof(ExportDataPage));

    }

    private async void OnMenuItemClicked(object sender, EventArgs e)
    {
      await Shell.Current.GoToAsync("//LoginPage");
    }
  }
}
