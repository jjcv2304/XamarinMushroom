using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Mushrooms.Data;
using Mushrooms.Models;
using Mushrooms.Views;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
  public class MushroomsVM : BaseVM<Mushroom>
  {
    public MushroomsVM()
    {
      Title = "All Mushrooms";
      Mushrooms = new ObservableCollection<Mushroom>();
      //LoadMushroomsCommand = new Command(async () => await ExecuteLoadMushroomsCommand());
      LoadMushroomsCommand = new Command(ExecuteLoadMushroomsCommand);

      MushroomTapped = new Command<Mushroom>(OnMushroomSelected);

      AddMushroomCommand = new Command(OnAddMushroom);

      DeleteMushroomCommand = new Command(OnDeleteMushroom);

      EditMushroomCommand = new Command(OnEditMushroom);
    }

    private Mushroom _selectedMushroom;

    public Mushroom SelectedMushroom
    {
      get => _selectedMushroom;
      set
      {
        SetProperty(ref _selectedMushroom, value);
        OnMushroomSelected(value);
      }
    }
    public ObservableCollection<Mushroom> Mushrooms { get; }
    public Command LoadMushroomsCommand { get; }
    public Command AddMushroomCommand { get; }
    public Command<Mushroom> MushroomTapped { get; }
    public Command DeleteMushroomCommand { get;  }
    public Command EditMushroomCommand { get; }



    private async void ExecuteLoadMushroomsCommand()
    {
      IsBusy = true;

      try
      {
        Mushrooms.Clear();
        //var mushrooms = await DataStore.GetAsync(true);
        MushroomsDatabase database = await MushroomsDatabase.Instance;
        var mushrooms = await database.GetMushroomsAsync();
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

    private async void OnAddMushroom(object obj)
    {
      // await Shell.Current.GoToAsync(nameof(NewMushroomPage));
    }
    
    private async void OnDeleteMushroom(object obj)
    {
      // await Shell.Current.GoToAsync(nameof(NewMushroomPage));
    }

    private async void OnEditMushroom(object obj)
    {
      // await Shell.Current.GoToAsync(nameof(NewMushroomPage));
    }

    async void OnMushroomSelected(Mushroom mushroom)
    {
      if (mushroom == null)
        return;

      // This will push the MushroomDetailPage onto the navigation stack
      await Shell.Current.GoToAsync(
          $"{nameof(MushroomDetailPage)}?{nameof(MushroomDetailVM.MushroomId)}={mushroom.Id}");
    }
  }
}