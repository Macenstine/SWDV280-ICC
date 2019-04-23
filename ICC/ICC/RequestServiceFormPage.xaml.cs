using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ICC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestServiceFormPage : ContentPage
    {
        public RequestServiceFormPage()
        {
            InitializeComponent();
        }

        async void OnClickSubmit(object sender, EventArgs e)
        {
            List<string> address = new List<string>();
            address.Add("imbencowan20@gmail.com");
            address.Add("2089215438@vtext.com");

            string message = "";
            message += "Request from: \n";
            message += EntryFName.Text + " " + EntryLName.Text + "\n";
            message += EntryEmail.Text + "\n";
            message += EntryPhone.Text + "\n";
            message += EntryAddress1.Text + "\n";
            message += EntryAddress2.Text + "\n";
            message += EntryCity.Text + ", " + EntryState.Text + " " + EntryZip.Text;


            await SendEmail("Test", message, address);
            
            this.Navigation.PushModalAsync(new ServiceConfirmationPage());
        }
        
        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
            
        }
    }
}