using System;
using System.Linq;
/*using Xamarin.Forms;*/

namespace qr_test3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
            {
                Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
                AutoRotate = true,
                Multiple = true
            };
        }

        private void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var first = e.Results?.FirstOrDefault();
            if (first is null)
                return;

            // Extract the data from the barcode result
            string decodedData = first.Value?.ToString();

            // Navigate to NewPage3 and pass the decoded data
            Dispatcher.DispatchAsync(async () =>
            {
                await Navigation.PushAsync(new NewPage3(decodedData));
            });
        }

        private void Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewPage1());
        }

        private void About_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewPage2());
        }
    }
}
