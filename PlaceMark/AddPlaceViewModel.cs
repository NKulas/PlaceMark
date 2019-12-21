using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PlaceMark
{
    public class AddPlaceViewModel : ViewModel
    {
        public AddPlaceViewModel(INavigation nav)
        {
            navigation = nav;
            SaveCommand = new Command(Save);
            ViewOnMapCommand = new Command(MoveMap);
            Place = new Place();
            bufferLatitude = 0;
            bufferLongitude = 0;
        }

        public Command SaveCommand { get; }
        public Command ViewOnMapCommand { get; }
        public Place Place { get; }
        public Xamarin.Forms.Maps.Map Map { get; set; }
        private INavigation navigation;

        private bool useCurrentLocation;
        public bool UseCurrentLocation
        {
            get
            {
                return useCurrentLocation;
            }
            set
            {
                useCurrentLocation = value;
                OnPropertyChanged();
                OnPropertyChanged("Latitude");
                OnPropertyChanged("Longitude");
            }
        }

        private double userLatitude;
        private double userLongitude;
        private double bufferLatitude;
        private double bufferLongitude;

        public double Latitude
        {
            get
            {
                if (useCurrentLocation) return userLatitude;
                else return bufferLatitude;
            }
            set
            {
                if (!useCurrentLocation) bufferLatitude = value;
                OnPropertyChanged();
            }
        }

        public double Longitude
        {
            get
            {
                if (useCurrentLocation) return userLongitude;
                else return bufferLongitude;
            }
            set
            {
                if (!useCurrentLocation) bufferLongitude = value;
                OnPropertyChanged();
            }
        }

        public async void SetUserLocation()
        {
            var location = await Geolocation.GetLocationAsync();
            userLatitude = location.Latitude;
            userLongitude = location.Longitude;
        }

        public void MoveMap()
        {
            Position center = new Position(Latitude, Longitude);
            Map.MoveToRegion(new MapSpan(center, 10, 10));
        }

        public void Save()
        {
            PlacesManager manager = new PlacesManager();

            Place.Id = manager.GetNextId();
            Place.Latitude = Latitude;
            Place.Longitude = Longitude;
            Place.CreatedDate = DateTime.UtcNow;

            if (!Place.NameIsValidate()) Place.Name = $"Place #{Place.Id}";

            manager.SavePlace(Place);
            navigation.PopAsync();
        }
    }
}