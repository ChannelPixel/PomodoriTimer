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
            Swtch_UseAlarmNotification.IsToggled = PrevPage.HomeTimer.UseAlarmNotification;
            Swtch_UseAlarmSound.IsToggled = PrevPage.HomeTimer.UseAlarmSound;

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
            if(PrevPage.HomeTimer.PomLength != Pckr_StudyMin.SelectedIndex && (
                PrevPage.HomeTimer.CurrentTimerState == 0
                || PrevPage.HomeTimer.CurrentTimerState == 2
                || PrevPage.HomeTimer.CurrentTimerState == 4
                || PrevPage.HomeTimer.CurrentTimerState == 6))
            {
                PrevPage.HomeTimer.Counting = false;
                PrevPage.HomeTimer.PomLength = Pckr_StudyMin.SelectedIndex;
                PrevPage.HomeTimer.RefreshTimerState();
                UpdateHomepage();
            }

            if(PrevPage.HomeTimer.PomLength != Pckr_StudyMin.SelectedIndex)
            {
                PrevPage.HomeTimer.PomLength = Pckr_StudyMin.SelectedIndex;
            }
            
        }

        private void Pckr_ShortBreakMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PrevPage.HomeTimer.BreakLength != Pckr_ShortBreakMin.SelectedIndex && (
                PrevPage.HomeTimer.CurrentTimerState == 1
                || PrevPage.HomeTimer.CurrentTimerState == 3
                || PrevPage.HomeTimer.CurrentTimerState == 5
                || PrevPage.HomeTimer.CurrentTimerState == 7))
            {
                PrevPage.HomeTimer.Counting = false;
                PrevPage.HomeTimer.BreakLength = Pckr_ShortBreakMin.SelectedIndex;
                PrevPage.HomeTimer.RefreshTimerState();
                UpdateHomepage();
            }

            if (PrevPage.HomeTimer.BreakLength != Pckr_ShortBreakMin.SelectedIndex)
            {
                PrevPage.HomeTimer.BreakLength = Pckr_ShortBreakMin.SelectedIndex;
            }
        }

        private void Pckr_LongBreakMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PrevPage.HomeTimer.LongBreakLength != Pckr_LongBreakMin.SelectedIndex &&
                PrevPage.HomeTimer.CurrentTimerState == 8)
            {
                PrevPage.HomeTimer.Counting = false;
                PrevPage.HomeTimer.LongBreakLength = Pckr_LongBreakMin.SelectedIndex;
                PrevPage.HomeTimer.RefreshTimerState();
                UpdateHomepage();
            }

            if(PrevPage.HomeTimer.LongBreakLength != Pckr_LongBreakMin.SelectedIndex)
            {
                PrevPage.HomeTimer.LongBreakLength = Pckr_LongBreakMin.SelectedIndex;
            }
        }

        private void UpdateHomepage()
        {
            PrevPage.UpdateUI();
        }

        private void Swtch_UseDarkTheme_Toggled(object sender, ToggledEventArgs e)
        {
            PrevPage.HomeTimer.UseDarkTheme = Swtch_UseDarkTheme.IsToggled;
            PomodoriTimerAPI.RefreshDynamicThemeResources(PrevPage.HomeTimer.UseDarkTheme);
        }

        private void Swtch_UseAlarmSound_Toggled(object sender, ToggledEventArgs e)
        {
            PrevPage.HomeTimer.UseAlarmSound = Swtch_UseAlarmSound.IsToggled;
        }

        private void Swtch_UseAlarmNotification_Toggled(object sender, ToggledEventArgs e)
        {
            PrevPage.HomeTimer.UseAlarmNotification = Swtch_UseAlarmNotification.IsToggled;
        }
    }
}