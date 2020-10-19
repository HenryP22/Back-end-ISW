using System;
using TechTalk.SpecFlow;

namespace Testing_Suite.Steps
{
    [Binding]
    public class MostrarInformesSteps
    {
        [Given(@"el padre de familia se encuentra en la sección “Mis clases”")]
        public void GivenElPadreDeFamiliaSeEncuentraEnLaSeccionMisClases()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"el informe ya está disponible")]
        public void GivenElInformeYaEstaDisponible()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"se dirija a los detalles de una clase y no hay informacion")]
        public void WhenSeDirijaALosDetallesDeUnaClaseYNoHayInformacion()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"se dirija a los detalles de la clase y el informe ha sido subido")]
        public void WhenSeDirijaALosDetallesDeLaClaseYElInformeHaSidoSubido()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el padre determine que el archivo no cumple con lo esperado y seleccione la opción notificar docente")]
        public void WhenElPadreDetermineQueElArchivoNoCumpleConLoEsperadoYSeleccioneLaOpcionNotificarDocente()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"no podra descargar el informe del alumno y se mostrara el mensaje “informe no disponible”")]
        public void ThenNoPodraDescargarElInformeDelAlumnoYSeMostraraElMensajeInformeNoDisponible()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"podra visualizar el nombre del informe y al lado un botón para descargarlo")]
        public void ThenPodraVisualizarElNombreDelInformeYAlLadoUnBotonParaDescargarlo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se enviara una notificación al docente solicitando la corrección del informe\.")]
        public void ThenSeEnviaraUnaNotificacionAlDocenteSolicitandoLaCorreccionDelInforme_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
