using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PlaceMark
{
    public class PlacesListViewModel : ViewModel
    {
        public ObservableCollection<PlaceViewModel> Places { get; private set; }
        public Command AddPlaceCommand { get; }
        public Command RefreshCommand { get; }
        private INavigation navigation;

        public PlacesListViewModel(INavigation nav)
        {
            navigation = nav;

            Places = new ObservableCollection<PlaceViewModel>();
            LoadPlaces();

            AddPlaceCommand = new Command(AddPlace);
        }

        public void LoadPlaces()
        {
            PlacesManager manager = new PlacesManager();
            Places.Clear();
            List<Place> result = manager.GetPlaces();

            foreach (Place place in result)
            {
                Places.Add(new PlaceViewModel(place, navigation));
            }

            OnPropertyChanged("Places");
        }

        private void AddPlace()
        {
            AddPlaceTabPage tabPage = new AddPlaceTabPage();
            AddPlaceViewModel viewModel = new AddPlaceViewModel(navigation);
            tabPage.BindingContext = viewModel;
            //viewModel.SetUserLocation(); TODO this is not working
            navigation.PushAsync(tabPage);
        }
    }
}