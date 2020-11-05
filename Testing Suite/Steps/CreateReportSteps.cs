using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Testing;
using TutoFinder.Dto;
using TutoFinder.Entity;
using TutoFinder.Service.Impl;

namespace Testing_Suite.Steps
{
    [Binding]
    public class CreateReportSteps : BasePruebas
    {
        [Given(@"the tutor has to create an inform after every tutorship")]
        public void GivenTheTutorHasToCreateAnInformAfterEveryTutorship()
        {
            
        }

        [When(@"the tutorship has ended")]
        public void WhenTheTutorshipHasEnded()
        {
           
        }

        [Then(@"the “Realizar reporte” option will appear\.")]
        public void ThenTheRealizarReporteOptionWillAppear_()
        {
            
        }

        [Given(@"the tutor wants to edit wrong information in the report")]
        public async Task GivenTheTutorWantsToEditWrongInformationInTheReport()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Informes.Add(new Informe
            {
                InformeId = 1,
                Descripcion = " no hizo nada en todo el ciclo",
                TutoriaId = 1,
                Fecha = "12/02/2000"
            });

            context.Tutorias.Add(
                new Tutoria
                {
                    TutoriaId = 1,
                    AlumnoId = 1,
                    DocenteId = 1,
                    CursoId = 1,
                    Costo = 30.25,
                    Descripcion = "Repaso de codigo Api",
                    Cantidad_minutos = 3
                });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            var InformeUpdateDTO = new InformeUpdateDto()
            {
                Descripcion = " completó todo el contenido",
                TutoriaId = 1,
                Fecha = "12/02/2000"
            };

            int id = 1;
            var controller = new InformeServiceImpl(context2, mapper);

            await controller.Update(id, InformeUpdateDTO);

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Informes.AnyAsync(x => x.Descripcion == " completó todo el contenido");
            Assert.IsTrue(existe);
        }

        [When(@"they go to the option “anterior”")]
        public void WhenTheyGoToTheOptionAnterior()
        {
            
        }

        [Then(@"the report interface will appear with the previous information\.")]
        public async Task ThenTheReportInterfaceWillAppearWithThePreviousInformation_()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Informes.Add(new Informe
            {
                InformeId = 1,
                Descripcion = " no hizo nada en todo el ciclo",
                TutoriaId = 1,
                Fecha = "12/02/2000"
            });
            context.Tutorias.Add(
                new Tutoria
                {
                    TutoriaId = 1,
                    AlumnoId = 1,
                    DocenteId = 1,
                    CursoId = 1,
                    Costo = 30.25,
                    Descripcion = "Repaso de codigo Api",
                    Cantidad_minutos = 3
                });
            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new InformeServiceImpl(context2, mapper);

            var respuesta = await controller.GetById(id);

            //Verificación

            var Informes = respuesta.InformeId;
            Assert.AreEqual(id, Informes);
        }

        [Given(@"the tutor wants to send the report")]
        public void GivenTheTutorWantsToSendTheReport()
        {
            
        }

        [When(@"they finish editing the report, they need to select the “siguiente” option")]
        public void WhenTheyFinishEditingTheReportTheyNeedToSelectTheSiguienteOption()
        {
            
        }

        [Then(@"the interface with the filled report will appear so they can verify the info so they can select the “Enviar” option\.")]
        public void ThenTheInterfaceWithTheFilledReportWillAppearSoTheyCanVerifyTheInfoSoTheyCanSelectTheEnviarOption_()
        {
            
        }

        [Given(@"the parent hasn't understood completely the report")]
        public void GivenTheParentHasnTUnderstoodCompletelyTheReport()
        {
            
        }

        [When(@"they make a complain")]
        public void WhenTheyMakeAComplain()
        {
            
        }

        [Then(@"the tutor has to edit it so the client has agreed\.")]
        public void ThenTheTutorHasToEditItSoTheClientHasAgreed_()
        {
            
        }

    }
}
