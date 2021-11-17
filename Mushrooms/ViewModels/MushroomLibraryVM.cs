﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Mushrooms.Models;
using Mushrooms.Services;
using Mushrooms.Views;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
  internal class MushroomLibraryVM : BaseViewModel
  {
    private MushroomDataService _mushroomDataService;
    private ObservableCollection<Mushroom> _mushroomList;
    public ObservableCollection<Mushroom> MushroomList
    {
      get => _mushroomList;
      set
      {
        _mushroomList = value;
        OnPropertyChanged("MushroomList");
      }
    }
    public ICommand MushroomSelectedCommand { get; }
    public ICommand AddMushroomCommand { get; }

    public MushroomLibraryVM(MushroomDataService mushroomDataService)
    {
      _mushroomDataService = mushroomDataService;

      AddMushroomCommand = new Command(OnAddMushroomCommand);
      MushroomSelectedCommand = new Command<Mushroom>(OnMushroomSelectedCommand);

      MushroomList = new ObservableCollection<Mushroom>();
    }

    public async Task OnAppearing()
    {
      //IsBusy = true;
      //todo verify is ok to return void for delegates?
      MushroomList = new ObservableCollection<Mushroom>(await _mushroomDataService.GetAsync());
    }


    private async void OnMushroomSelectedCommand(Mushroom mushroom)
    {
      await Shell.Current.GoToAsync($"{nameof(MushroomDetailPage)}?Id={mushroom.Id}");
    }

    private async void OnAddMushroomCommand()
    {
      await Shell.Current.GoToAsync($"{nameof(MushroomEditPage)}");
    }
    //private void OnPieChanged(PieDetailViewModel sender, Pie pie)
    //{
    //  //Pies = new ObservableCollection<Pie>(PieRepository.Pies);
    //  //Pies = new ObservableCollection<Pie>(App.PieDataServie.GetAllPies());
    //  Pies = new ObservableCollection<Pie>(_pieDataService.GetAllPies());
    //}
  }
}