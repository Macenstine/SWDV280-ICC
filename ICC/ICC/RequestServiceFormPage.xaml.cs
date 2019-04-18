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
    public partial class RequestServiceFormPage : ContentPage
    {
        public RequestServiceFormPage()
        {
            InitializeComponent();
        }

        void OnClickSubmit(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new ServiceConfirmationPage());
        }
    }
}