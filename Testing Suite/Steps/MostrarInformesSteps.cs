using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Testing;
using TutoFinder.Entity;
using TutoFinder.Service.Impl;

namespace Testing_Suite.Steps
{
    [Binding]
    public class MostrarInformesSteps : BasePruebas
    {
        [Given(@"el padre de familia se encuentra en la sección “Mis clases”")]
        public void GivenElPadreDeFamiliaSeEncuentraEnLaSeccionMisClases()
        {
            //No implementado
        }

        [Given(@"el informe ya está disponible")]
        public void GivenElInformeYaEstaDisponible()
        {
            new Informe
            {
                InformeId = 1,
                Descripcion = " no hizo nada en todo el ciclo",
                TutoriaId = 1,
                Fecha = "12/02/2000"
            };
        }

        [When(@"se dirija a los detalles de una clase y no hay informacion")]
        public void WhenSeDirijaALosDetallesDeUnaClaseYNoHayInformacion()
        {
            //No implementado
        }

        [When(@"se dirija a los detalles de la clase y el informe ha sido subido")]
        public async Task WhenSeDirijaALosDetallesDeLaClaseYElInformeHaSidoSubido()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Informes.Add(new Informe()
            {
                InformeId = 1,
                Descripcion = " no hizo nada en todo el ciclo",
                TutoriaId = 1,
                Fecha = "12/02/2000"
            });
            await context.SaveChangesAsync();
        }
        
        [When(@"el padre determine que el archivo no cumple con lo esperado y seleccione la opción notificar docente")]
        public void WhenElPadreDetermineQueElArchivoNoCumpleConLoEsperadoYSeleccioneLaOpcionNotificarDocente()
        {
            //No implementado
        }

        [Then(@"no podra descargar el informe del alumno y se mostrara el mensaje “informe no disponible”")]
        public void ThenNoPodraDescargarElInformeDelAlumnoYSeMostraraElMensajeInformeNoDisponible()
        {
            //No implementado
        }

        [Then(@"podra visualizar el nombre del informe y al lado un botón para descargarlo")]
        public async Task ThenPodraVisualizarElNombreDelInformeYAlLadoUnBotonParaDescargarlo()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Informes.Add(new Informe()
            {
                InformeId = 1,
                Descripcion = " no hizo nada en todo el ciclo",
                TutoriaId = 1,
                Fecha = "12/02/2000"
            });
            context.Tutorias.Add(new Tutoria()
            {
                TutoriaId = 1
            });

            var context2 = ConstruirContext(nombreDB);

            await context.SaveChangesAsync();

            int id = 1;
            var controller = new InformeServiceImpl(context2, mapper);

            var respuesta = await controller.GetById(id);

            //Verificación

            var informes = respuesta.InformeId;
            Assert.AreEqual(id, informes);
        }
        
        [Then(@"se enviara una notificación al docente solicitando la corrección del informe\.")]
        public void ThenSeEnviaraUnaNotificacionAlDocenteSolicitandoLaCorreccionDelInforme_()
        {
            //No implementado
        }
    }
}
