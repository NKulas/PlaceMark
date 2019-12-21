using System;
using Xamarin.Forms;

namespace PlaceMark
{
    public partial class PlacesListPage : ContentPage
    {
        public PlacesListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            PlacesListViewModel viewModel = (PlacesListViewModel)BindingContext;
            viewModel.LoadPlaces();
        }
    }
}
