using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;
using PomodoriTimer.Interfaces;

namespace danielCherrin_PomodoriTimer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        internal PomodoriUserTimer HomeTimer = JsonConvert.DeserializeObject<PomodoriUserTimer>(Preferences.Get("UserPomodori", JsonConvert.SerializeObject(new PomodoriUserTimer())));
        private Task CountingThread;

        public MainPage()
        {
            InitializeComponent();
            CountingThread = StartCountingThread();
            PomodoriTimerAPI.RefreshDynamicThemeResources(HomeTimer.UseDarkTheme);
            UpdateHomeUI();
        }

        private async Task StartCountingThread()
        { 
            while (true)
            {
                if (HomeTimer.Counting && HomeTimer.CurrentSpan.TotalSeconds <= 0)
                {
                    HomeTimer.ToggleCounting();
                    HomeTimer.NextTimerState();
                    UpdateHomeUI();


                    if (HomeTimer.UseAlarmNotification)
                    {
                        Random rand = new Random();
                        DependencyService.Get<IXamPixelNotification>().ShowNotification("Times Up", PomodoriTimerAPI.producivityQuotes[rand.Next(0, PomodoriTimerAPI.producivityQuotes.Length)]);
                    }
                    if (HomeTimer.UseAlarmSound)
                        DependencyService.Get<IXamPixelAudio>().PlayAudio("gentle_morning_alarmFaded.wav");

                }
                else if (HomeTimer.Counting)
                {
                    HomeTimer.CurrentSpan = HomeTimer.CurrentSpan.Add(new TimeSpan(0, 0, -1));
                    UpdateHomeUI();
                }
                await Task.Delay(1000);
            }
        }

        internal void OnClose()
        {
            Preferences.Set("UserPomodori", JsonConvert.SerializeObject(HomeTimer));
        }

        internal void UpdateHomeUI()
        {
            Lbl_HomeTimer.Text = HomeTimer.CurrentSpan.ToString(@"mm\:ss");

            #region PLAY/PAUSE UI
            //PLAY/PAUSE BUTTON UI
            if (HomeTimer.Counting)
            {
                Btn_PlayPause.Text = "\u25FC";
            }
            else
            {
                Btn_PlayPause.Text = "\u25B6";
            }
            #endregion

            #region CHECKPOINT UI
            //CHECKPOINT UI
            if (HomeTimer.CurrentTimerState == 0)
            {
                Lbl_FirstPom.Text = "\u25CB";
                Lbl_FirstBreak.Text = "\u25CB";
                Lbl_SecondPom.Text = "\u25CB";
                Lbl_SecondBreak.Text = "\u25CB";
                Lbl_ThirdPom.Text = "\u25CB";
                Lbl_ThirdBreak.Text = "\u25CB";
                Lbl_FourthPom.Text = "\u25CB";
                Lbl_FourthBreak.Text = "\u25CB";
            }
            else if(HomeTimer.CurrentTimerState == 1)
            {
                Lbl_FirstPom.Text = "\u25CF";
                Lbl_FirstBreak.Text = "\u25CB";
                Lbl_SecondPom.Text = "\u25CB";
                Lbl_SecondBreak.Text = "\u25CB";
                Lbl_ThirdPom.Text = "\u25CB";
                Lbl_ThirdBreak.Text = "\u25CB";
                Lbl_FourthPom.Text = "\u25CB";
                Lbl_FourthBreak.Text = "\u25CB";
            }
            else if (HomeTimer.CurrentTimerState == 2)
            {
                Lbl_FirstPom.Text = "\u25CF";
                Lbl_FirstBreak.Text = "\u25CF";
                Lbl_SecondPom.Text = "\u25CB";
                Lbl_SecondBreak.Text = "\u25CB";
                Lbl_ThirdPom.Text = "\u25CB";
                Lbl_ThirdBreak.Text = "\u25CB";
                Lbl_FourthPom.Text = "\u25CB";
                Lbl_FourthBreak.Text = "\u25CB";
            }
            else if (HomeTimer.CurrentTimerState == 3)
            {
                Lbl_FirstPom.Text = "\u25CF";
                Lbl_FirstBreak.Text = "\u25CF";
                Lbl_SecondPom.Text = "\u25CF";
                Lbl_SecondBreak.Text = "\u25CB";
                Lbl_ThirdPom.Text = "\u25CB";
                Lbl_ThirdBreak.Text = "\u25CB";
                Lbl_FourthPom.Text = "\u25CB";
                Lbl_FourthBreak.Text = "\u25CB";
            }
            else if (HomeTimer.CurrentTimerState == 4)
            {
                Lbl_FirstPom.Text = "\u25CF";
                Lbl_FirstBreak.Text = "\u25CF";
                Lbl_SecondPom.Text = "\u25CF";
                Lbl_SecondBreak.Text = "\u25CF";
                Lbl_ThirdPom.Text = "\u25CB";
                Lbl_ThirdBreak.Text = "\u25CB";
                Lbl_FourthPom.Text = "\u25CB";
                Lbl_FourthBreak.Text = "\u25CB";
            }
            else if (HomeTimer.CurrentTimerState == 5)
            {
                Lbl_FirstPom.Text = "\u25CF";
                Lbl_FirstBreak.Text = "\u25CF";
                Lbl_SecondPom.Text = "\u25CF";
                Lbl_SecondBreak.Text = "\u25CF";
                Lbl_ThirdPom.Text = "\u25CF";
                Lbl_ThirdBreak.Text = "\u25CB";
                Lbl_FourthPom.Text = "\u25CB";
                Lbl_FourthBreak.Text = "\u25CB";
            }
            else if (HomeTimer.CurrentTimerState == 6)
            {
                Lbl_FirstPom.Text = "\u25CF";
                Lbl_FirstBreak.Text = "\u25CF";
                Lbl_SecondPom.Text = "\u25CF";
                Lbl_SecondBreak.Text = "\u25CF";
                Lbl_ThirdPom.Text = "\u25CF";
                Lbl_ThirdBreak.Text = "\u25CF";
                Lbl_FourthPom.Text = "\u25CB";
                Lbl_FourthBreak.Text = "\u25CB";
            }
            else if (HomeTimer.CurrentTimerState == 7)
            {
                Lbl_FirstPom.Text = "\u25CF";
                Lbl_FirstBreak.Text = "\u25CF";
                Lbl_SecondPom.Text = "\u25CF";
                Lbl_SecondBreak.Text = "\u25CF";
                Lbl_ThirdPom.Text = "\u25CF";
                Lbl_ThirdBreak.Text = "\u25CF";
                Lbl_FourthPom.Text = "\u25CF";
                Lbl_FourthBreak.Text = "\u25CB";
            }
            else if (HomeTimer.CurrentTimerState == 8)
            {
                Lbl_FirstPom.Text = "\u25CF";
                Lbl_FirstBreak.Text = "\u25CF";
                Lbl_SecondPom.Text = "\u25CF";
                Lbl_SecondBreak.Text = "\u25CF";
                Lbl_ThirdPom.Text = "\u25CF";
                Lbl_ThirdBreak.Text = "\u25CF";
                Lbl_FourthPom.Text = "\u25CF";
                Lbl_FourthBreak.Text = "\u25CF";
            }
            #endregion
        }

        private void Btn_PlayPause_Clicked(object sender, EventArgs e)
        {
            HomeTimer.ToggleCounting();
            UpdateHomeUI();
        }

        private void Btn_Refresh_Clicked(object sender, EventArgs e)
        {
            HomeTimer.Counting = false;
            HomeTimer.RefreshTimerState();
            UpdateHomeUI();
        }

        private void Btn_HomeSettings_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new SettingsPage(this);
        }

        private void Checkpoint_TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            HomeTimer.Counting = false;
            HomeTimer.NextTimerState();
            UpdateHomeUI();
        }
    }
}
