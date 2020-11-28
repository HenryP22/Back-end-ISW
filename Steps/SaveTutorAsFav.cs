using TechTalk.SpecFlow;
using System;
using NUnit.Framework;
namespace Back_end_ISW_master.Steps
{
    [Binding]
    public class SaveTutorAsFav
    {
        [Given(@"the loged in parent")]
      public void TheLogedinParent(){
            ScenarioContext.Current.Pending();
      }
        [Given(@"the parent wants to check their favorite tutors")]
      public void TheParentWantsToCheckTheirFavoriteTutors(){
            ScenarioContext.Current.Pending();
      }
        [When(@"enters the option "buscar clases" and founds a tutor they like")]
      public void EntersTheOptionBuscarClasesAndFoundsATutorTheyLike(){
          ScenarioContext.Current.Pending();
      }
        [When(@"hey enter the "tutorias" section and select the "favoritos" filter")]
      public void TheyEnterTheTutoriasSectionAndSelectTheFavoritosFilter(){
          ScenarioContext.Current.Pending();
      }

        [Then(@"they can mark the tutor as favorite.")]
      public void TheyCanMarkTheTutorAsFavorite(){
          ScenarioContext.Current.Pending();
      }
        [Then(@"they can't mark the tutor as favorite again")]
      public void TheyCantMarkTheTutorAsFavoriteAgain(){
          ScenarioContext.Current.Pending();
      }
        [Then(@"they will get a list of all the favorite tutors with their detailed info")]
      public void TheyWillGetAListOfAllTheFavoriteTutorsWithTheirDetailedInfo(){
          ScenarioContext.Current.Pending();
      }
    }
}