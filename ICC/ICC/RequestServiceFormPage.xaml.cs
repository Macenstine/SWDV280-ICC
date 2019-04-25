using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using static Xamarin.Forms.Color;
using System.Text.RegularExpressions;

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
            //build the message body from the form entries
            //Phone and Address2 are optional, so only add if they are not null
            bool isValid = true;
            string fName = EntryFName.Text;
            string lName = EntryLName.Text;
            string email = EntryEmail.Text;
            string phone = EntryPhone.Text;
            string address1 = EntryAddress1.Text;
            string address2 = EntryAddress2.Text;
            string city = EntryCity.Text;
            string state = EntryState.Text;
            string zip = EntryZip.Text;


            if (fName == null || fName == "")
            {
                isValid = false;
                EntryFName.Placeholder = "First Name *";
                EntryFName.PlaceholderColor = Red;
            }
            if (lName == null || lName == "")
            {
                isValid = false;
                EntryLName.Placeholder = "Last Name *";
                EntryLName.PlaceholderColor = Red;
            }
            if (email == null || email == "")
            {
                isValid = false;
                EntryEmail.Placeholder = "Email address *";
                EntryEmail.PlaceholderColor = Red;
            }
            else if (!IsValidEmail(email))
            {
                isValid = false;
                EntryEmail.Placeholder = "Enter a valid Email";
                EntryEmail.PlaceholderColor = Red;
                EntryEmail.Text = "";
            }
            /*if(phone == null || phone == "")
            {
                isValid = false;
                EntryPhone.Placeholder = EntryPhone.Placeholder + " *";
                EntryPhone.PlaceholderColor = Red;
            }*/
            if (phone == null || phone == "" || IsValidPhone(phone))
            {
                //do nothing, isValid should already be true
            }
            else if (!IsValidPhone(phone) && phone != null && phone != "")
            {
                isValid = false;
                EntryPhone.Placeholder = "Enter a Valid Phone Number";
                EntryPhone.PlaceholderColor = Red;
                EntryPhone.Text = "";
            }
            if (address1 == null || address1 == "")
            {
                isValid = false;
                EntryAddress1.Placeholder = "Address 1 *";
                EntryAddress1.PlaceholderColor = Red;
            }
            if (city == null || city == "")
            {
                isValid = false;
                EntryCity.Placeholder = "City *";
                EntryCity.PlaceholderColor = Red;
            }
            if (zip == null || zip == "")
            {
                isValid = false;
                EntryZip.Placeholder = "Zip *";
                EntryZip.PlaceholderColor = Red;
            }

            //build the message body from the form entries
            if (isValid)
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
                

        }
        public static bool IsValidPhone(string phoneNumber)
        {
            //string pattern = @"^(?: (?:\+? 1\s * (?:[.-]\s *)?)?(?:\(\s * ([2 - 9]1[02 - 9] |[2 - 9][02 - 8]1 |[2 - 9][02 - 8][02 - 9])\s *\)| ([2 - 9]1[02 - 9] |[2 - 9][02 - 8]1 |[2 - 9][02 - 8][02 - 9]))\s * (?:[.-]\s *)?)?([2 - 9]1[02 - 9] |[2 - 9][02 - 9]1 |[2 - 9][02 - 9]{ 2})\s * (?:[.-]\s *)?([0 - 9]{ 4})(?:\s * (?:#|x\.?|ext\.?|extension)\s*(\d+))?$";
            //var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            //return regex.IsMatch(phoneNumber);
            string numbersOnly = RemoveNonNumeric(phoneNumber);
            if (numbersOnly.Length == 7 || numbersOnly.Length == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string RemoveNonNumeric(string phone)
        {
            return Regex.Replace(phone, @"[^0-9]+", "");
        }
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
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
