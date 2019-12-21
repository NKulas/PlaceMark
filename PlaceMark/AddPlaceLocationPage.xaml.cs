using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PlaceMark
{
    public partial class AddPlaceLocationPage : ContentPage
    {
        public AddPlaceLocationPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AddPlaceViewModel viewModel = (AddPlaceViewModel)BindingContext;
            viewModel.Map = TheMap;
            viewModel.SetUserLocation();
            viewModel.MoveMap();
        }
    }
}
