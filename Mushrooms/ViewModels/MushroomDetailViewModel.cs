using System;
using System.Diagnostics;
using Mushrooms.Models;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
    [QueryProperty(nameof(MushroomId), nameof(MushroomId))]
    public class MushroomDetailViewModel : BaseViewModel<Mushroom>
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
        private int capId;
        
        public string Id { get; set; }
        public string CommonName
        {
            get => commonName;
            set => SetProperty(ref commonName, value);
        }
        public string ScientificName
        {
            get => scientificName;
            set => SetProperty(ref scientificName, value);
        }
        public string Cap
        {
            get { return "cap test"; }
            set => SetProperty(ref capId, Int32.Parse(value));
        }

        public async void LoadMushroomId(string mushroomId)
        {
            try
            {
                var mushroom = await DataStore.GetAsync(mushroomId);
                Id = mushroom.Id.ToString();
                CommonName = mushroom.CommonName;
                ScientificName = mushroom.ScientificName;
                Cap = mushroom.Cap.ToString();
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Mushroom");
            }
        }
        
        //todo to add the rest of the properties

        // Cap = cap;
        // MarginType = marginType;
        // MarginCurvature = marginCurvature;
        // GillAttachment = gillAttachment;
        // StemShape = stemShape;
        // RingType = ringType;
    }
}