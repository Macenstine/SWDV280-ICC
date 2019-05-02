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
            RequestService("Relocation Services");
        }

        private void Corporate_Events(object sender, EventArgs e)
        {
            RequestService("Corporate Event");
        }

        private void Errand_Running(object sender, EventArgs e)
        {
            RequestService("Errand Running");
        }

        private void Temporary_Assisants(object sender, EventArgs e)
        {
            RequestService("Temporary Assistant");
        }

        private void AccommodationsBTN(object sender, EventArgs e)
        {
            RequestService("Accomodations");
        }

        private void Business_Retreats(object sender, EventArgs e)
        {
            RequestService("Business Retreat");
        }

        void btn_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new RequestServiceFormPage());
        }

        void RequestService(string service)
        {
            this.Navigation.PushModalAsync(new RequestServiceDatePage(service));
        }
    }
}

