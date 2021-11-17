using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using Mushrooms.Data;
using Mushrooms.Extensions;
using Mushrooms.Models;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
  {
    public class MushroomEditVM : BaseViewModel, IQueryAttributable
    {
      public void ApplyQueryAttributes(IDictionary<string, string> query)
      {
        string id = "0";
        if (query.Count > 0)
        {
          id = HttpUtility.UrlDecode(query["Id"]);
        }
        LoadMushroomId(id);
      }

      private Mushroom _selectedMushroom = null!;
      public Mushroom SelectedMushroom
      {
        get => _selectedMushroom;
        set
        {
          _selectedMushroom = value;
          OnPropertyChanged(nameof(SelectedMushroom));
        }
      }
      public MushroomEditVM()
      {
        SaveCommand = new Command(OnSave);
        CancelCommand = new Command(OnCancel);
        this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
      }

      public Command SaveCommand { get; }
      public Command CancelCommand { get; }


      private async void LoadMushroomId(string mushroomIdentifier)
      {
        try
        {
          if (mushroomIdentifier == "0")
          {
            SelectedMushroom = new Mushroom();
          }
          else
          {
            MushroomsRepository database = await MushroomsRepository.Instance;
            SelectedMushroom = await database.GetMushroomAsync(int.Parse(mushroomIdentifier));
          }
        }
        catch (Exception e)
        {
          Debug.WriteLine("Failed to Load Mushroom, details: " + e.Message);
        }
      }
      private bool ValidateSave()
      {
        return !string.IsNullOrWhiteSpace(SelectedMushroom.CommonName)
               && !string.IsNullOrWhiteSpace(SelectedMushroom.ScientificName);
      }
      private async void OnCancel()
      {
        await Shell.Current.GoToAsync("..");
      }
      private async void OnSave()
      {
        if (!ValidateSave()) return;
        MushroomsRepository database = await MushroomsRepository.Instance;
        await database.SaveAsync(SelectedMushroom);

        await Shell.Current.GoToAsync("..");
      }
      public List<string> CapList => Enum<Cap>.ToList;
      public List<string> MarginTypeList => Enum<MarginType>.ToList;
      public List<string> MarginCurvatureList => Enum<MarginCurvature>.ToList;
      public List<string> GillAttachmentList => Enum<GillAttachment>.ToList;
      public List<string> StemShapeList => Enum<StemShape>.ToList;
      public List<string> RingTypeList => Enum<RingType>.ToList;

  }
  }