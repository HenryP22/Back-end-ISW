using System;
using TechTalk.SpecFlow;

namespace Testing_Suite.Steps
{
    [Binding]
    public class RealizarPagoSteps
    {
        [Given(@"un padre desea realizar el pago de una tutoria inscrita pro su hijo en la pagina web")]
        public void GivenUnPadreDeseaRealizarElPagoDeUnaTutoriaInscritaProSuHijoEnLaPaginaWeb()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"el padre ya realizó el pago")]
        public void GivenElPadreYaRealizoElPago()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"el padre ya no quiere realizar el pago")]
        public void GivenElPadreYaNoQuiereRealizarElPago()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"seleccione el usuario de su hijo, verifica las tutorias que realizo y seleccione la opcion ""(.*)""")]
        public void WhenSeleccioneElUsuarioDeSuHijoVerificaLasTutoriasQueRealizoYSeleccioneLaOpcion(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el docente solicite un comprobante para inciar la tutoria")]
        public void WhenElDocenteSoliciteUnComprobanteParaInciarLaTutoria()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"este se encuentre en la seccion de pago")]
        public void WhenEsteSeEncuentreEnLaSeccionDePago()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostrará una interfaz donde se le pedirá al padre que seleccione la tarjeta registrada anteriormente, completar el campo cvc y seleccionar la opción ""(.*)""")]
        public void ThenSeMostraraUnaInterfazDondeSeLePediraAlPadreQueSeleccioneLaTarjetaRegistradaAnteriormenteCompletarElCampoCvcYSeleccionarLaOpcion(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"el padre podrá enviar el recibo para que no exista ningun inconveniente")]
        public void ThenElPadrePodraEnviarElReciboParaQueNoExistaNingunInconveniente()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se le mostrará la opcion ""(.*)"" si es que el padre no se encuentra conforme con algun dato de pago")]
        public void ThenSeLeMostraraLaOpcionSiEsQueElPadreNoSeEncuentraConformeConAlgunDatoDePago(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
