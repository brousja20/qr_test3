using System;
using System.ComponentModel;
/*using Xamarin.Forms;*/

namespace qr_test3
{
    public partial class NewPage1 : ContentPage
    {
        public NewPage1()
        {
            InitializeComponent();
        }

        private void Save_Info(object sender, EventArgs e)
        {
            // Create an object from user inputs
            var fullName = FullNameEntry.Text;
            var yearOfBirth = YearOfBirthEntry.Text;
            var placeOfBirth = PlaceOfBirthEntry.Text;
            var yearOfDeath = YearOfDeathEntry.Text;
            var placeOfDeath = PlaceOfDeathEntry.Text;
            var additionalInfo = AdditionalInfoEntry.Text;

            // You can create your own object or use a dictionary, for example
            var userData = new
            {
                FullName = fullName,
                YearOfBirth = yearOfBirth,
                PlaceOfBirth = placeOfBirth,
                YearOfDeath = yearOfDeath,
                PlaceOfDeath = placeOfDeath,
                AdditionalInfo = additionalInfo
            };

            // Convert object to string and set it as the Value for BarcodeGeneratorView
            string userDataString = Newtonsoft.Json.JsonConvert.SerializeObject(userData);
            qrCode.Value = userDataString;
        }
    }
}
