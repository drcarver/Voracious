﻿// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Voracious.Controls
{
    public sealed partial class PickLanguageControl : ContentView
    {
        public PickLanguageControl()
        {
            this.InitializeComponent();
        }
        public string GetSelectedLanguage()
        {
            return uiLanguage.Text;
        }
        public void SetInitialLanguage(string language)
        {
            uiLanguage.Text = language;
        }
        private void OnSelectLanguage(object sender, RoutedEventArgs e)
        {
            uiLanguage.Text = (sender as FrameworkElement).Tag as string;
        }
    }
}
