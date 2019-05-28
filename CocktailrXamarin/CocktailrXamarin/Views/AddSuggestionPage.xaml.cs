using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailrXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddSuggestionPage : ContentPage
	{
        bool madePicture = false;

		public AddSuggestionPage ()
		{
			InitializeComponent ();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (madePicture && cocktailName.Text != null && cocktailName.Text != "" && cocktailDescription.Text != "" && cocktailDescription.Text != null)
            {
                await DisplayAlert("Make a suggestion", "Thank you for your suggestion!", "Ok");
            }
        }

        async void Handle_Clicked_1Async(object sender, System.EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                madePicture = true;
                return stream;
            });
        }
    }
}