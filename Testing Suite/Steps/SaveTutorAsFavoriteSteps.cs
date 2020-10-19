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
        
        [Given(@"the parent wants to check their favorite tutors")]
        public void GivenTheParentWantsToCheckTheirFavoriteTutors()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"enters the option ""(.*)"" and founds a tutor they like")]
        public void WhenEntersTheOptionAndFoundsATutorTheyLike(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"they enter the ""(.*)"" section and select the ""(.*)"" filter")]
        public void WhenTheyEnterTheSectionAndSelectTheFilter(string p0, string p1)
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
        
        [Then(@"they will get a list of all the favorite tutors with their detailed info\.")]
        public void ThenTheyWillGetAListOfAllTheFavoriteTutorsWithTheirDetailedInfo_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
