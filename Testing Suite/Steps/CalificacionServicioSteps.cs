using System;
using TechTalk.SpecFlow;

namespace Testing_Suite.Steps
{
    [Binding]
    public class CalificacionServicioSteps
    {
        [Given(@"el docente desea que los clientes califiquen su desempeño laboral")]
        public void GivenElDocenteDeseaQueLosClientesCalifiquenSuDesempenoLaboral()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"el docente desea visualizar el detalle del comentario hecho por el cliente")]
        public void GivenElDocenteDeseaVisualizarElDetalleDelComentarioHechoPorElCliente()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"el usuario desea reportar una calificación negativa errónea respecto a su desempeño laboral")]
        public void GivenElUsuarioDeseaReportarUnaCalificacionNegativaErroneaRespectoASuDesempenoLaboral()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuario inicie sesión en la aplicación web y vaya a la opción “Mi perfil”")]
        public void WhenElUsuarioInicieSesionEnLaAplicacionWebYVayaALaOpcionMiPerfil()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"se encuentre en la sección ""(.*)"" de su perfil")]
        public void WhenSeEncuentreEnLaSeccionDeSuPerfil(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"se encuentra en la su perfil y en la sección comentarios")]
        public void WhenSeEncuentraEnLaSuPerfilYEnLaSeccionComentarios()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostrará una interfaz donde se seleccionará la opción “calificación”")]
        public void ThenSeMostraraUnaInterfazDondeSeSeleccionaraLaOpcionCalificacion()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se podrá visualizar los comentarios hechos por los clientes respecto al desempeño del usuario")]
        public void ThenSePodraVisualizarLosComentariosHechosPorLosClientesRespectoAlDesempenoDelUsuario()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se le mostrará la opción para clickear el comentario del cliente")]
        public void ThenSeLeMostraraLaOpcionParaClickearElComentarioDelCliente()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"podrá visualizar los comentarios, luego de ello seleccionará el comentario erróneo registrado")]
        public void ThenPodraVisualizarLosComentariosLuegoDeElloSeleccionaraElComentarioErroneoRegistrado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"finalmente seleccionará la opción “reportar”")]
        public void ThenFinalmenteSeleccionaraLaOpcionReportar()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
