using System;
/*using Xamarin.Forms;*/

namespace qr_test3
{
    public partial class NewPage3 : ContentPage
    {
        public NewPage3(string decodedData)
        {
            InitializeComponent();

            // Display the decoded data in the UI
            DisplayDecodedData(decodedData);
        }

        private void DisplayDecodedData(string decodedData)
        {
            // Assuming decodedData is in JSON format, you can deserialize it to extract individual fields
            try
            {
                dynamic userData = Newtonsoft.Json.JsonConvert.DeserializeObject(decodedData);

                // Populate UI elements with the decoded data
                FullNameLabel.Text = userData.FullName;
                YearOfBirthLabel.Text = userData.YearOfBirth;
                PlaceOfBirthLabel.Text = userData.PlaceOfBirth;
                YearOfDeathLabel.Text = userData.YearOfDeath;
                PlaceOfDeathLabel.Text = userData.PlaceOfDeath;
                AdditionalInfoLabel.Text = userData.AdditionalInfo;
            }
            catch (Exception ex)
            {
                // Handle any exception occurred during decoding or populating UI elements
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
