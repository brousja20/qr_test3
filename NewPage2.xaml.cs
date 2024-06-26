namespace qr_test3
{
    public partial class NewPage2 : ContentPage
    {
        private const string ColorKey = "AppColor";
        private bool isDarkMode = false;

        public NewPage2()
        {
            InitializeComponent();
            LoadColor();
        }

        // Click event handler for the button to toggle between dark and light modes
        private void Change_Theme(object sender, EventArgs e)
        {
            if (isDarkMode)
            {
                SetLightMode();
            }
            else
            {
                SetDarkMode();
            }
        }

        // Method to set the UI to dark mode
        private void SetDarkMode()
        {
            this.BackgroundColor = Color.FromHex("#121212");
            ChangeFontColor("#ECECEC");
            isDarkMode = true;
            SaveColor("#121212");
        }

        // Method to set the UI to light mode
        private void SetLightMode()
        {
            this.BackgroundColor = Color.FromHex("#FFFFFF");
            ChangeFontColor("#000000");
            isDarkMode = false;
            SaveColor("#FFFFFF");
        }

        private void LoadColor()
        {
            if (Preferences.ContainsKey(ColorKey))
            {
                var savedColor = Preferences.Get(ColorKey, string.Empty);
                if (!string.IsNullOrEmpty(savedColor))
                {
                    this.BackgroundColor = Color.FromHex(savedColor);

                    // Determine mode based on background color
                    if (savedColor.Equals("#121212"))
                    {
                        SetDarkMode();
                    }
                    else
                    {
                        SetLightMode();
                    }
                }
            }
        }

        private void SaveColor(string color)
        {
            Preferences.Set(ColorKey, color);
        }

        private void ChangeFontColor(string colorHex)
        {
            var textColor = Color.FromHex(colorHex);

            // Change the font color of labels
            SettingsLabel.TextColor = textColor;
            ThemeLabel.TextColor = textColor;

            // Change the font color of the button
            ThemeButton.TextColor = textColor;
        }
    }
}


/*
 namespace qr_test3
{
    public partial class NewPage2 : ThemedContentPage // Ensure NewPage2 inherits from ThemedContentPage
    {
        public NewPage2()
        {
            InitializeComponent();
        }

        private void Change_Theme(object sender, EventArgs e)
        {
            if (isDarkMode)
            {
                SetLightMode();
            }
            else
            {
                SetDarkMode();
            }
        }
    }
}
 */