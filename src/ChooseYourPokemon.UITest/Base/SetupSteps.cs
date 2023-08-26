using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace ChooseYourPokemon.UITest.Base
{
    [Binding]
    public class SetupSteps
    {
        [Given("a started app")]
        public void TheMainPageIsDisplayed()
        {
            if (Global.Platform == Platform.iOS)
            {
                Global.App = ConfigureApp.iOS.StartApp();
            }
            else
            {
                Global.App = ConfigureApp
                    .Android
                    .InstalledApp("com.ChooseYourPokemon")
                    .PreferIdeSettings()
                    .EnableLocalScreenshots()
                    .StartApp();
            }
        }
    }
}
