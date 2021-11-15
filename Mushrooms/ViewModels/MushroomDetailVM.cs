using System;
using System.Diagnostics;
using Mushrooms.Data;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
  [QueryProperty(nameof(MushroomId), nameof(MushroomId))]
  public class MushroomDetailVM : BaseViewModel
  {
    public string MushroomId
    {
      get { return mushroomId; }
      set
      {
        mushroomId = value;
        LoadMushroomId(value);
      }
    }

    private string mushroomId;
    private string commonName;
    private string scientificName;
    private string cap;
    private string marginType;
    private string marginCurvature;
    private string gillAttachment;
    private string stemShape;
    private string ringType;

    //public string Id { get; set; }
    //public string CommonName
    //{
    //  get => commonName;
    //  //set => SetProperty(ref commonName, value);
    //  set => OnPropertyChanged(nameof(CommonName));
    //}
    //public string ScientificName
    //{
    //  get => scientificName;
    //  set => SetProperty(ref scientificName, value);
    //}
    //public string Cap
    //{
    //  get { return cap; }
    //  set => SetProperty(ref cap, value);
    //}
    //public string MarginType
    //{
    //  get { return marginType; }
    //  set => SetProperty(ref marginType, value);
    //}
    //public string MarginCurvature
    //{
    //  get { return marginCurvature; }
    //  set => SetProperty(ref marginCurvature, value);
    //}
    //public string GillAttachment
    //{
    //  get { return gillAttachment; }
    //  set => SetProperty(ref gillAttachment, value);
    //}
    //public string StemShape
    //{
    //  get { return stemShape; }
    //  set => SetProperty(ref stemShape, value);
    //}
    //public string RingType
    //{
    //  get { return ringType; }
    //  set => SetProperty(ref ringType, value);
    //}

    public async void LoadMushroomId(string mushroomIdentifier)
    {
      try
      {
        MushroomsRepository database = await MushroomsRepository.Instance;
        var mushroom = await database.GetMushroomAsync(int.Parse(mushroomIdentifier));
        //var mushroom = await DataStore.GetAsync(mushroomId);
        //Id = mushroom.Id.ToString();
        //CommonName = mushroom.CommonName;
        //ScientificName = mushroom.ScientificName;
        //Cap = mushroom.Cap.ToString();
        //MarginType = mushroom.MarginType.ToString();
        //MarginCurvature = mushroom.MarginCurvature.ToString();
        //GillAttachment = mushroom.GillAttachment.ToString();
        //StemShape = mushroom.StemShape.ToString();
        //RingType = mushroom.RingType.ToString();
      }
      catch (Exception e)
      {
        Debug.WriteLine("Failed to Load Mushroom, details: " + e.Message);
      }
    }

  }
}