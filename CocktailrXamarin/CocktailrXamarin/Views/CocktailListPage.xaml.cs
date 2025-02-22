﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailrXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailrXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CocktailListPage : ContentPage
	{
		public CocktailListPage ()
		{
			InitializeComponent ();
            BindingContext = App.cocktailViewModel;
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            await App.cocktailViewModel.FetchCocktailById((Cocktail) e.Item);
            await Navigation.PushAsync(new CocktailDetailPage());
        }

        private async void ToolbarItem_OnActivated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IngredientsListPage());
        }
    }
}