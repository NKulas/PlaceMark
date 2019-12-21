using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PlaceMark
{
    public class PlaceDetailViewModel
    {
        public PlaceDetailViewModel(Place place, INavigation nav)
        {
            Place = place;
            navigation = nav;
            DeleteCommand = new Command(Delete);
        }

        public Place Place { get; set; }
        public Command DeleteCommand { get; }
        private INavigation navigation;
        public Map Map { get; set; }

        private void Delete()
        {
            PlacesManager manager = new PlacesManager();
            manager.Delete(Place.Id);

            navigation.PopAsync();
        }

        public void SetMapLocation()
        {
            Position center = new Position(Place.Latitude, Place.Longitude);
            Map.MoveToRegion(new MapSpan(center, 10, 10));

            Pin pin = new Pin { Position = center, Label = Place.Name };
            Map.Pins.Add(pin);
        }
    }
}
