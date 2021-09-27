﻿using Mushrooms.ViewModels;
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
      Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
      Routing.RegisterRoute(nameof(NewMushroomPage), typeof(NewMushroomPage));
    }

    private async void OnMenuItemClicked(object sender, EventArgs e)
    {
      await Shell.Current.GoToAsync("//LoginPage");
    }
  }
}
