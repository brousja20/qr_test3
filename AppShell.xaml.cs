using Microsoft.Maui.Controls;

namespace qr_test3
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        // Event handler for button click
        private async void OnButtonClick(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage.xaml.cs"); // Replace "NewPage" with the actual route of the page you want to navigate to
        }
    }
}