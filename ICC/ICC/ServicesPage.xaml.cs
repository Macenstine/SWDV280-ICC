using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICC
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ServicesPage : ContentPage
	{
		public ServicesPage ()
		{
			InitializeComponent ();
		}

        private void Relocation_Services(object sender, EventArgs e)
        {

        }

        private void Corporate_Events(object sender, EventArgs e)
        {

        }

        private void Errand_Running(object sender, EventArgs e)
        {

        }

        private void Temporary_Assisants(object sender, EventArgs e)
        {

        }

        private void AccommodationsBTN(object sender, EventArgs e)
        {

        }

        private void Business_Retreats(object sender, EventArgs e)
        {

        }

        void btn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new RequestServiceFormPage());
        }

        void OnClickTest(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new RequestServiceFormPage());
        }
    }
}

