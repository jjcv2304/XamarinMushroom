using System;
using System.Diagnostics;
using Mushrooms.Models;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
    [QueryProperty(nameof(MushroomId), nameof(MushroomId))]
    internal class MushroomDetailViewModel : BaseViewModel<Item>
    {
        private string mushroomId;
        private string commonName;
        private string scientificName;
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

        public string MushroomId
        {
            get { return mushroomId; }
            set
            {
                mushroomId = value;
                LoadMushroomId(value);
            }
        }

        public async void LoadMushroomId(string itemId)
        {
            try
            {
                var item = await DataStore.GetAsync(itemId);
                Id = item.Id;
                CommonName = item.Text;
                ScientificName = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Mushroom");
            }
        }
        
        //todo to add the rest of the properties
        // Id = id;
        // CommonName = commonName;
        // ScientificName = scientificName;
        // Cap = cap;
        // MarginType = marginType;
        // MarginCurvature = marginCurvature;
        // GillAttachment = gillAttachment;
        // StemShape = stemShape;
        // RingType = ringType;
    }
}