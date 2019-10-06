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

        public SettingsPage(MainPage prevPage)
        {
            InitializeComponent();
            PrevPage = prevPage;
        }

        private void Btn_ReturnToHomepage_Clicked(object sender, EventArgs e)
        {
            if (PrevPage != null)
            {
                Application.Current.MainPage = PrevPage;
            }
        }
    }
}