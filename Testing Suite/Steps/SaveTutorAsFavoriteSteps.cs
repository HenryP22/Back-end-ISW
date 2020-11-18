using System;
using TechTalk.SpecFlow;
using TutoFinder.Entity;

namespace Testing_Suite.Steps
{
    [Binding]
    public class SaveTutorAsFavoriteSteps
    {
        [Given(@"the loged in parent")]
        public void GivenTheLogedInParent()
        {
            //No implementado
        }

        [When(@"enters the option “Buscar clases” and founds a tutor they like")]
        public void WhenEntersTheOptionBuscarClasesAndFoundsATutorTheyLike()
        {
            //No implementado
        }

        [Then(@"they can mark the tutor as favorite\.")]
        public void ThenTheyCanMarkTheTutorAsFavorite_()
        {
            new Favorito()
            {
                FavoritoId = 1,
                DocenteId = 1,
                PadreId = 1
            };
        }

        [Then(@"they can't mark the tutor as favorite again\.")]
        public void ThenTheyCanTMarkTheTutorAsFavoriteAgain_()
        {
            //No implementado
        }

        [Given(@"the parent wants to check their favorite tutors")]
        public void GivenTheParentWantsToCheckTheirFavoriteTutors()
        {
            //No implementado
        }

        [When(@"they enter the “Tutorías” section and select the “Favoritos” filter")]
        public void WhenTheyEnterTheTutoriasSectionAndSelectTheFavoritosFilter()
        {
            //No implementado
        }

        [Then(@"they will get a list of all the favorite tutors with their detailed info\.")]
        public void ThenTheyWillGetAListOfAllTheFavoriteTutorsWithTheirDetailedInfo_()
        {
            //No implementado
        }

    }
}
