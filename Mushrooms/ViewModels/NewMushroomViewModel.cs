using System;
using Mushrooms.Models;
using Xamarin.Forms;

namespace Mushrooms.ViewModels
{
    internal class NewMushroomViewModel : BaseViewModel<Mushroom>
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

        internal Cap Cap
        {
            get => _cap;
            set => SetProperty(ref _cap, value);
        }

        internal MarginType MarginType
        {
            get => _marginType;
            set => SetProperty(ref _marginType, value);
        }

        internal MarginCurvature MarginCurvature
        {
            get => _marginCurvature;
            set => SetProperty(ref _marginCurvature, value);
        }

        internal GillAttachment GillAttachment
        {
            get => _gillAttachment;
            set => SetProperty(ref _gillAttachment, value);
        }

        internal StemShape StemShape
        {
            get => _stemShape;
            set => SetProperty(ref _stemShape, value);
        }

        internal RingType RingType
        {
            get => _ringType;
            set => SetProperty(ref _ringType, value);
        }


        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(_commonName)
                   && !string.IsNullOrWhiteSpace(_scientificName);
        }
        internal Command SaveCommand { get; }
        internal Command CancelCommand { get; }
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private async void OnSave()
        {
            Mushroom newMushroom = new Mushroom(Guid.NewGuid(), CommonName, _scientificName, _cap, _marginType,
                _marginCurvature, _gillAttachment, _stemShape, _ringType
            );

            await DataStore.AddAsync(newMushroom);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}