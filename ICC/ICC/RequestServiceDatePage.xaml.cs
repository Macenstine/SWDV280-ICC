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
		public RequestServiceDatePage ()
		{
			InitializeComponent ();
		}

        void OnClickSelect(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new RequestServiceFormPage());
        }


    }
}