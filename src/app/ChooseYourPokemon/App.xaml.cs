using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChooseYourPokemon
{
    public partial class App : Application
    {
        private Dictionary<string, string> _logParams = new Dictionary<string, string>();

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            _logParams.Add("Manufacturer", DeviceInfo.Manufacturer);
            _logParams.Add("Model", DeviceInfo.Model);
            _logParams.Add("Version ", DeviceInfo.VersionString);
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=ad682f24-01a8-4b7d-a793-c14b1d1da3b4;", typeof(Analytics), typeof(Crashes));
            Analytics.TrackEvent("App iniciado", _logParams);
        }

        protected override void OnSleep()
        {
            Analytics.TrackEvent("App fechado", _logParams);
        }

        protected override void OnResume()
        {
        }
    }
}
