using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChooseYourPokemon
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private const string charmander = "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";
        private const string squirtle = "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";
        private const string bulbasaur = "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";

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SelectPokemonCommand { get; set; }
        public ICommand ClearPokemonCommand { get; set; }
        public ICommand ChamanderCommand { get; set; }
        public ICommand SquirtleCommand { get; set; }
        public ICommand BulbasaurCommand { get; set; }

        private async Task ScaleEffect(Frame frame)
        {
            await frame.ScaleTo(0.95, 25, Easing.Linear);
            await Task.Delay(50);
            await frame.ScaleTo(1, 50, Easing.Linear);
        }


        public MainViewModel()
        {
            SelectPokemonCommand = new Command(async () => await SelectPokemonExecuteAsync());
            ClearPokemonCommand = new Command(async () => await ClearPokemonExecuteAsync());
            ChamanderCommand = new Command<Frame>(async (frame) => await ChoosePokemonExecuteAsync(frame, Charmander, "Charmander", "#ff9441"));
            SquirtleCommand = new Command<Frame>(async (frame) => await ChoosePokemonExecuteAsync(frame, Squirtle, "Squirtle", "#8bc5cd"));
            BulbasaurCommand = new Command<Frame>(async (frame) => await ChoosePokemonExecuteAsync(frame, Bulbasaur, "Bulbasaur", "#83eec5"));
        }

        private ImageSource selected;

        public ImageSource Selected
        {
            get
            {
                if (selected == null)
                {
                    return ImageSource.FromFile("pokebola");
                }
                return selected;
            }

            set
            {
                selected = value;
                OnPropertyChanged(nameof(Selected));
                OnPropertyChanged(nameof(SelectedText));
            }
        }


        private string selectedName;

        public string SelectedName
        {
            get
            {
                return selectedName;
            }

            set
            {
                selectedName = value;
                OnPropertyChanged(nameof(SelectedName));
            }
        }

        private string selectedBackground = "#FFFFFF";

        public string SelectedBackground
        {
            get
            {
                return selectedBackground;
            }

            set
            {
                selectedBackground = value;
                OnPropertyChanged(nameof(SelectedBackground));
            }
        }


        public string SelectedText
        {
            get
            {
                if (selected != null)
                    return "Seu pokemon escolhido foi ...";

                return string.Empty;
            }
        }

        public ImageSource Charmander
        {
            get
            {
                var ms = new MemoryStream(Convert.FromBase64String(charmander));
                var img = ImageSource.FromStream(() => ms);
                return img;
            }
        }

        public ImageSource Squirtle
        {
            get
            {
                var ms = new MemoryStream(Convert.FromBase64String(squirtle));
                var img = ImageSource.FromStream(() => ms);
                return img;
            }
        }

        public ImageSource Bulbasaur
        {
            get
            {
                var ms = new MemoryStream(Convert.FromBase64String(bulbasaur));
                var img = ImageSource.FromStream(() => ms);
                return img;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task SelectPokemonExecuteAsync()
        {

            var page = new ChoosePokemonModal();
            await PopupNavigation.Instance.PushAsync(page, true);
        }

        private async Task ClearPokemonExecuteAsync()
        {
            try
            {
                if (selected != null)
                {
                    Selected = null;
                    SelectedName = null;
                    SelectedBackground = "#ffffff";
                    throw new Exception("Não quero um Pokemon!");
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                await App.Current.MainPage.DisplayAlert("Aviso", "O Pokemon selecionado se foi :( ", "Ok");
            }
        }

        private async Task ChoosePokemonExecuteAsync(Frame frame, ImageSource pokemon, string name, string color)
        {
            try
            {
                await this.ScaleEffect(frame);
                Selected = pokemon;
                SelectedName = name;
                SelectedBackground = color;
                await PopupNavigation.Instance.PopAllAsync(true);

                Dictionary<string, string> logParams = new Dictionary<string, string>();
                logParams.Add("Pokemon", name);
                logParams.Add("Cor", color);
                logParams.Add("Manufacturer", DeviceInfo.Manufacturer);
                logParams.Add("Model", DeviceInfo.Model);
                logParams.Add("Version ", DeviceInfo.VersionString);

                Analytics.TrackEvent("Pokemon Escolhido", logParams);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }
    }
}
