using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace ChooseYourPokemon.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp("com.ChooseYourPokemon")
                    .PreferIdeSettings()
                    .EnableLocalScreenshots()
                    .StartApp();
            }

            return ConfigureApp.iOS
                .EnableLocalScreenshots()
                .StartApp();
        }
    }
}