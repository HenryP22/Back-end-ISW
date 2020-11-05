using System;
using TechTalk.SpecFlow;

namespace Testing_Suite.Steps
{
    [Binding]
    public class SaveTutorAsFavoriteSteps
    {
        [Given(@"the loged in parent")]
        public void GivenTheLogedInParent()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"enters the option “Buscar clases” and founds a tutor they like")]
        public void WhenEntersTheOptionBuscarClasesAndFoundsATutorTheyLike()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"they can mark the tutor as favorite\.")]
        public void ThenTheyCanMarkTheTutorAsFavorite_()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"they can't mark the tutor as favorite again\.")]
        public void ThenTheyCanTMarkTheTutorAsFavoriteAgain_()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the parent wants to check their favorite tutors")]
        public void GivenTheParentWantsToCheckTheirFavoriteTutors()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"they enter the “Tutorías” section and select the “Favoritos” filter")]
        public void WhenTheyEnterTheTutoriasSectionAndSelectTheFavoritosFilter()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"they will get a list of all the favorite tutors with their detailed info\.")]
        public void ThenTheyWillGetAListOfAllTheFavoriteTutorsWithTheirDetailedInfo_()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
