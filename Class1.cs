namespace qr_test3
{
    public class ThemedContentPage : ContentPage
    {
        private const string ColorKey = "AppColor";
        private bool isDarkMode = false;

        public ThemedContentPage()
        {
            LoadColor();
        }

        // Method to set the UI to dark mode
        protected void SetDarkMode()
        {
            this.BackgroundColor = Color.FromHex("#121212");
            ChangeFontColor("#ECECEC");
            isDarkMode = true;
            SaveColor("#121212");
        }

        // Method to set the UI to light mode
        protected void SetLightMode()
        {
            this.BackgroundColor = Color.FromHex("#FFFFFF");
            ChangeFontColor("#000000");
            isDarkMode = false;
            SaveColor("#FFFFFF");
        }

        protected void LoadColor()
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

        protected void SaveColor(string color)
        {
            Preferences.Set(ColorKey, color);
        }

        protected void ChangeFontColor(string colorHex)
        {
            var textColor = Color.FromHex(colorHex);
            ApplyFontColorRecursive(this.Content, textColor);
        }

        private void ApplyFontColorRecursive(View view, Color color)
        {
            if (view is Layout layout)
            {
                foreach (var child in layout.Children)
                {
                    if (child is View)
                    {
                        ApplyFontColorRecursive((View)child, color);
                    }
                }
            }
            else if (view is Label label)
            {
                label.TextColor = color;
            }
            else if (view is Button button)
            {
                button.TextColor = color;
            }
        }
    }
}