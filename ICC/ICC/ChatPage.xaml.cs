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
	public partial class ChatPage : ContentPage
	{
		public ChatPage ()
		{
			InitializeComponent ();
		}

        /*public async Task SendSms(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
        public async void OnEntryCompleted(object sender, EventArgs arg)
        {
            Entry data = (Entry)sender;
            string text = data.Text;
            string textRecipient = "+12083585398";
            string emailRecipient = "andrewmcfarland@mycwi.cc";
            await SendSms(text, textRecipient);
            //call to email function(text, emailRecipient);
        }*/
    }
}