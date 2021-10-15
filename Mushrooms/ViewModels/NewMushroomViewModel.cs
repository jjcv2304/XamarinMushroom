using System;
using System.Collections.Generic;
using System.Linq;
using Mushrooms.Data;
using Mushrooms.Extensions;
using Mushrooms.Models;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
  public class NewMushroomViewModel : BaseViewModel<Mushroom>
  {
    private string _commonName;
    private string _scientificName;
    private Cap _cap;
    private MarginType _marginType;
    private MarginCurvature _marginCurvature;
    private GillAttachment _gillAttachment;
    private StemShape _stemShape;
    private RingType _ringType;

    public NewMushroomViewModel()
    {
      SaveCommand = new Command(OnSave, ValidateSave);
      CancelCommand = new Command(OnCancel);
      this.PropertyChanged +=
          (_, __) => SaveCommand.ChangeCanExecute();
    }

    public string CommonName
    {
      get => _commonName;
      set => SetProperty(ref _commonName, value);
    }

    public string ScientificName
    {
      get => _scientificName;
      set => SetProperty(ref _scientificName, value);
    }

    public Cap Cap
    {
      get => _cap;
      set => SetProperty(ref _cap, value);
    }
    public List<string> CapList
    {
      get
      {
        return Enum.GetNames(typeof(Cap)).Select(b => b.SplitCamelCase()).ToList();
      }
    }


    public MarginType MarginType
    {
      get => _marginType;
      set => SetProperty(ref _marginType, value);
    }
    public List<string> MarginTypeList
    {
      get
      {
        return Enum.GetNames(typeof(MarginType)).Select(b => b.SplitCamelCase()).ToList();
      }
    }

    public MarginCurvature MarginCurvature
    {
      get => _marginCurvature;
      set => SetProperty(ref _marginCurvature, value);
    }
    public List<string> MarginCurvatureList
    {
      get
      {
        return Enum.GetNames(typeof(MarginCurvature)).Select(b => b.SplitCamelCase()).ToList();
      }
    }

    public GillAttachment GillAttachment
    {
      get => _gillAttachment;
      set => SetProperty(ref _gillAttachment, value);
    }
    public List<string> GillAttachmentList
    {
      get
      {
        return Enum.GetNames(typeof(GillAttachment)).Select(b => b.SplitCamelCase()).ToList();
      }
    }

    public StemShape StemShape
    {
      get => _stemShape;
      set => SetProperty(ref _stemShape, value);
    }
    public List<string> StemShapeList
    {
      get
      {
        return Enum.GetNames(typeof(StemShape)).Select(b => b.SplitCamelCase()).ToList();
      }
    }

    public RingType RingType
    {
      get => _ringType;
      set => SetProperty(ref _ringType, value);
    }
    public List<string> RingTypeList
    {
      get
      {
        return Enum.GetNames(typeof(RingType)).Select(b => b.SplitCamelCase()).ToList();
      }
    }

    private bool ValidateSave()
    {
      return !string.IsNullOrWhiteSpace(_commonName)
             && !string.IsNullOrWhiteSpace(_scientificName);
    }
    public Command SaveCommand { get; }
    public Command CancelCommand { get; }
    private async void OnCancel()
    {
      // This will pop the current page off the navigation stack
      await Shell.Current.GoToAsync("..");
    }
    private async void OnSave()
    {
      MushroomsDatabase database = await MushroomsDatabase.Instance;
      Mushroom newMushroom = new Mushroom(0, _commonName, _scientificName, _cap, _marginType,
                _marginCurvature, _gillAttachment, _stemShape, _ringType
            );

      var t = Cap;

      await database.SaveAsync(newMushroom);

      // This will pop the current page off the navigation stack
      await Shell.Current.GoToAsync("..");
    }
  }
}