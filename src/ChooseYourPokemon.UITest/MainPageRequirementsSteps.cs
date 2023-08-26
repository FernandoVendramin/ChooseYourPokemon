using ChooseYourPokemon.UITest.Base;
using System;
using TechTalk.SpecFlow;
using Xamarin.UITest.Queries;

namespace ChooseYourPokemon.UITest
{
    [Binding]
    [Scope(Feature = "MainPageRequirements")]
    public class MainPageRequirementsSteps
    {
        static readonly Func<AppQuery, AppQuery> InitialMessage = c => c.Marked("MainPageTitle");
        static readonly Func<AppQuery, AppQuery> btnChoosePokemon = c => c.Marked("btnChoosePokemon");
        static readonly Func<AppQuery, AppQuery> btnClearPokemon = c => c.Marked("btnClearPokemon");
        static readonly Func<AppQuery, AppQuery> btnBulbasaur = c => c.Marked("btnBulbasaur");
        static readonly Func<AppQuery, AppQuery> btnSquirtle = c => c.Marked("btnSquirtle");
        static readonly Func<AppQuery, AppQuery> btnCharmander = c => c.Marked("btnCharmander");
        static readonly Func<AppQuery, AppQuery> Modal = c => c.Marked("ChoosePokemonTitle");
        static readonly Func<AppQuery, AppQuery> InitialPageWithPokemon = c => c.Marked("lblPokemon").Text("Seu pokemon escolhido foi ...");


        [Given(@"an user at main page screen")]
        public void MainPageScreenIsDisplayed()
        {
            Global.App.Query(InitialMessage);
            Global.App.Screenshot("MainPage screen.");
        }

        [When(@"he press button choose pokemon")]
        public void ChoosePokemonClick()
        {
            Global.App.Tap(btnChoosePokemon);
        }

        [When(@"he selected charmander pokemon")]
        public void CharmanderClick()
        {
            Global.App.Tap(btnCharmander);
        }

        [Then(@"show charmander selected")]
        public void CharmanderSelected()
        {
            Global.App.WaitForElement(InitialPageWithPokemon, "Não foi localizar o pokemon selecionado", TimeSpan.FromMinutes(1));
            Global.App.Screenshot("Charmander selected.");
        }
    }
}
