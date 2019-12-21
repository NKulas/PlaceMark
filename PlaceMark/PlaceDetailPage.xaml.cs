using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlaceMark
{
    public partial class PlaceDetailPage : ContentPage
    {
        public PlaceDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PlaceDetailViewModel viewModel = (PlaceDetailViewModel)BindingContext;
            viewModel.Map = DetailMap;
            viewModel.SetMapLocation();
        }
    }
}