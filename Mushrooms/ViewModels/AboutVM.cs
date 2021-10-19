﻿using System;
using System.Windows.Input;
using Mushrooms.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
    internal class AboutVM : BaseVM<Mushroom>
    {
        public AboutVM()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}