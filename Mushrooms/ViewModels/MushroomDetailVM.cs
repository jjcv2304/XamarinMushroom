using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using Mushrooms.Data;
using Mushrooms.Models;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
  public class MushroomDetailVM : BaseViewModel, IQueryAttributable
  {
    public void ApplyQueryAttributes(IDictionary<string, string> query)
    {
      // The query parameter requires URL decoding.
      string id = HttpUtility.UrlDecode(query["Id"]);
     LoadMushroomId(id);
    }
    public async void LoadMushroomId(string mushroomIdentifier)
    {
      try
      {
        MushroomsRepository database = await MushroomsRepository.Instance;
        SelectedMushroom = await database.GetMushroomAsync(int.Parse(mushroomIdentifier));
      }
      catch (Exception e)
      {
        Debug.WriteLine("Failed to Load Mushroom, details: " + e.Message);
      }
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
  }
}