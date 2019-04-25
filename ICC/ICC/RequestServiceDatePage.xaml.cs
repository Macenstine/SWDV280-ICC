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
	public partial class RequestServiceDatePage : ContentPage
	{
        string passService;

		public RequestServiceDatePage (string service)
		{
			InitializeComponent ();
            promptLabel.Text += service + "?";
            passService = service;
		}

        // Initialize.
        //OnDateSelected(null, null);

        void OnClickSelect(object sender, EventArgs e)
        {
            //could have done the next three lines in one, but it's probably clearer this way
            //pull the date selected and the time selected
            DateTime passDate = serviceDatePicker.Date;
            TimeSpan passTime = serviceTimePicker.Time;
            //and then add the time to the date
            passDate = passDate.Add(passTime);
            this.Navigation.PushModalAsync(new RequestServiceFormPage(passService, passDate));
        }
    }
}