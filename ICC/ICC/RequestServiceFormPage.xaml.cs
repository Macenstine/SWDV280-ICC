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
        //a few fields we'll need from the previous page.
        string requestService;
        DateTime requestDate;

        public RequestServiceFormPage(string service, DateTime date)
        {
            InitializeComponent();
            //store arguments from previous page
            requestService = service;
            requestDate = date;
        }

        async void OnClickSubmit(object sender, EventArgs e)
        {
            //add the email address and text address to send the email to
            List<string> address = new List<string>();
            address.Add("imbencowan20@gmail.com");
            address.Add("2089215438@vtext.com");

            //build the message body from the form entries
            string message = "";
            message += "New " + requestService + " Request from: \n";
            message += EntryFName.Text + " " + EntryLName.Text + "\n";
            message += EntryEmail.Text + "\n";
            message += EntryPhone.Text + "\n";
            message += EntryAddress1.Text + "\n";
            if (EntryAddress2.Text != "" && EntryAddress2.Text != "Address 2 (optional)")
            {
                message += EntryAddress2.Text + "\n";
            }
            message += EntryCity.Text + ", " + EntryState.Text + " " + EntryZip.Text + "\n";
            //requestDate and Time were sent from the previous page to this page's constructor
            message += "on " + requestDate;


            //call send email function. function body is below.
            await SendEmail("Test", message, address);
            
            //not sure if await operator is necessary for this call
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