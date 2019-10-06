using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace danielCherrin_PomodoriTimer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        MainPage PrevPage;
        int[] MinutesArray = new int[60];

        public SettingsPage(MainPage prevPage)
        {
            InitializeComponent();
            PrevPage = prevPage;

            for(int i = 0; i < 60; i++)
            {
                MinutesArray[i] = i;
            }

            Swtch_UseDarkTheme.IsToggled = PrevPage.HomeTimer.UseDarkTheme;

            Pckr_StudyMin.ItemsSource = MinutesArray;
            Pckr_ShortBreakMin.ItemsSource = MinutesArray;
            Pckr_LongBreakMin.ItemsSource = MinutesArray;

            Pckr_StudyMin.SelectedIndex = PrevPage.HomeTimer.PomLength;
            Pckr_ShortBreakMin.SelectedIndex = PrevPage.HomeTimer.BreakLength;
            Pckr_LongBreakMin.SelectedIndex = PrevPage.HomeTimer.LongBreakLength;
        }

        private void Btn_ReturnToHomepage_Clicked(object sender, EventArgs e)
        {
            if (PrevPage != null)
            {
                Application.Current.MainPage = PrevPage;
            }
        }

        private void Pckr_Lengths_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrevPage.HomeTimer.PomLength = Pckr_StudyMin.SelectedIndex;
            UpdateHomepage();
        }

        private void Pckr_ShortBreakMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrevPage.HomeTimer.BreakLength = Pckr_ShortBreakMin.SelectedIndex;
            UpdateHomepage();
        }

        private void Pckr_LongBreakMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrevPage.HomeTimer.LongBreakLength = Pckr_LongBreakMin.SelectedIndex;
            UpdateHomepage();
        }

        private void UpdateHomepage()
        {
            PrevPage.HomeTimer.RefreshTimerState();
            PrevPage.HomeTimer.Counting = false;
            PrevPage.UpdateUI();
        }

        private void Swtch_UseDarkTheme_Toggled(object sender, ToggledEventArgs e)
        {
            PrevPage.HomeTimer.UseDarkTheme = Swtch_UseDarkTheme.IsToggled;
            PomodoriTimerAPI.RefreshDynamicThemeResources(PrevPage.HomeTimer.UseDarkTheme);
        }
    }
}