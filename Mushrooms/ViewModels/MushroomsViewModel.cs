using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Mushrooms.Models;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
    internal class MushroomsViewModel: BaseViewModel<Mushroom>
    {
        
    private Mushroom _selectedMushroom;

    public ObservableCollection<Mushroom> Mushrooms { get; }
    public Command LoadMushroomsCommand { get; }
    public Command AddMushroomCommand { get; }
    public Command<Mushroom> MushroomTapped { get; }

    public MushroomsViewModel()
    {
      Title = "Browse";
      Mushrooms = new ObservableCollection<Mushroom>();
      LoadMushroomsCommand = new Command(async () => await ExecuteLoadMushroomsCommand());

      MushroomTapped = new Command<Mushroom>(OnMushroomSelected);

      AddMushroomCommand = new Command(OnAddMushroom);
    }

    async Task ExecuteLoadMushroomsCommand()
    {
      IsBusy = true;

      try
      {
        Mushrooms.Clear();
        var mushrooms = await DataStore.GetAsync(true);
        foreach (var mushroom in mushrooms)
        {
          Mushrooms.Add(mushroom);
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
      finally
      {
        IsBusy = false;
      }
    }

    public void OnAppearing()
    {
      IsBusy = true;
      SelectedMushroom = null;
    }

    public Mushroom SelectedMushroom
    {
      get => _selectedMushroom;
      set
      {
        SetProperty(ref _selectedMushroom, value);
        OnMushroomSelected(value);
      }
    }

    private async void OnAddMushroom(object obj)
    {
     // await Shell.Current.GoToAsync(nameof(NewMushroomPage));
    }

    async void OnMushroomSelected(Mushroom mushroom)
    {
      if (mushroom == null)
        return;

      // This will push the MushroomDetailPage onto the navigation stack
      await Shell.Current.GoToAsync($"{nameof(MushroomDetailPage)}?{nameof(MushroomDetailViewModel.MushroomId)}={mushroom.Id}");
    }
    }
}