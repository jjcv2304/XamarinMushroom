using Mushrooms.Data;
using Mushrooms.Models;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
  public class MushroomEditVM : BaseViewModel
  {
    private string _commonName;
    private string _scientificName;
    private Cap _cap;
    private MarginType _marginType;
    private MarginCurvature _marginCurvature;
    private GillAttachment _gillAttachment;
    private StemShape _stemShape;
    private RingType _ringType;

    public MushroomEditVM()
    {
      SaveCommand = new Command(OnSave, ValidateSave);
      CancelCommand = new Command(OnCancel);
      this.PropertyChanged +=
          (_, __) => SaveCommand.ChangeCanExecute();
    }

    //public string CommonName
    //{
    //  get => _commonName;
    //  set => SetProperty(ref _commonName, value);
    //}

    //public string ScientificName
    //{
    //  get => _scientificName;
    //  set => SetProperty(ref _scientificName, value);
    //}

    //public Cap Cap
    //{
    //  get => _cap;
    //  set => SetProperty(ref _cap, value);
    //}
    //public List<string> CapList => Enum<Cap>.ToList;

    //public MarginType MarginType
    //{
    //  get => _marginType;
    //  set => SetProperty(ref _marginType, value);
    //}
    //public List<string> MarginTypeList => Enum<Cap>.ToList;

    //public MarginCurvature MarginCurvature
    //{
    //  get => _marginCurvature;
    //  set => SetProperty(ref _marginCurvature, value);
    //}
    //public List<string> MarginCurvatureList => Enum<MarginCurvature>.ToList;

    //public GillAttachment GillAttachment
    //{
    //  get => _gillAttachment;
    //  set => SetProperty(ref _gillAttachment, value);
    //}
    //public List<string> GillAttachmentList => Enum<GillAttachment>.ToList;

    //public StemShape StemShape
    //{
    //  get => _stemShape;
    //  set => SetProperty(ref _stemShape, value);
    //}
    //public List<string> StemShapeList => Enum<StemShape>.ToList;

    //public RingType RingType
    //{
    //  get => _ringType;
    //  set => SetProperty(ref _ringType, value);
    //}
    //public List<string> RingTypeList => Enum<RingType>.ToList;

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
      MushroomsRepository database = await MushroomsRepository.Instance;
      Mushroom newMushroom = new Mushroom(0, _commonName, _scientificName, _cap, _marginType,
                _marginCurvature, _gillAttachment, _stemShape, _ringType
            );

     // var t = Cap;

      await database.SaveAsync(newMushroom);

      // This will pop the current page off the navigation stack
      await Shell.Current.GoToAsync("..");
    }
  }
}