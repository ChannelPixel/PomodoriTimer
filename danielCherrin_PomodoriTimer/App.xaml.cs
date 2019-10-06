using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Newtonsoft.Json;

namespace danielCherrin_PomodoriTimer
{
    public partial class App : Application
    {
        MainPage HomePage;

        public App()
        {
            InitializeComponent();
            OnStart();
            MainPage = new MainPage();
            HomePage = (MainPage)MainPage;
        }

        protected override void OnStart()
        {
            if(!Preferences.ContainsKey("UserPomodori"))
            {
                Preferences.Set("UserPomodori", JsonConvert.SerializeObject(new PomodoriUserTimer()));
            }
        }

        protected override void OnSleep()
        {
            HomePage.OnClose();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
