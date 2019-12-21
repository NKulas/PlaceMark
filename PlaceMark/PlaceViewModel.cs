using System;
using Xamarin.Forms;

namespace PlaceMark
{
    public class PlaceViewModel
    {
        public PlaceViewModel(Place place, INavigation nav)
        {
            navigation = nav;
            Place = place;
            SelectCommand = new Command(Select);
        }

        public Place Place { get; set; }
        public Command SelectCommand { get; }
        private INavigation navigation;

        private void Select()
        {
            PlaceDetailPage detailPage = new PlaceDetailPage();
            PlaceDetailViewModel viewModel = new PlaceDetailViewModel(Place, navigation);

            detailPage.BindingContext = viewModel;
            navigation.PushAsync(detailPage);
        }
    }
}