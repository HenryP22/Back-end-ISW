using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Testing;
using TutoFinder.Entity;

namespace Testing_Suite.Steps
{
    [Binding]
    public class RealizarPagoSteps: BasePruebas
    {
        [Given(@"un padre desea realizar el pago de una tutoria inscrita pro su hijo en la pagina web")]
        public void GivenUnPadreDeseaRealizarElPagoDeUnaTutoriaInscritaProSuHijoEnLaPaginaWeb()
        {
            //No implementado
        }

        [When(@"seleccione el usuario de su hijo, verifica las tutorias que realizo y seleccione la opcion “Realizar pago”")]
        public void WhenSeleccioneElUsuarioDeSuHijoVerificaLasTutoriasQueRealizoYSeleccioneLaOpcionRealizarPago()
        {
            //No implementado
        }

        [Then(@"se mostrará una interfaz donde se le pedirá al padre que seleccione la tarjeta registrada anteriormente, completar el campo cvc y seleccionar la opción “Pagar”")]
        public void ThenSeMostraraUnaInterfazDondeSeLePediraAlPadreQueSeleccioneLaTarjetaRegistradaAnteriormenteCompletarElCampoCvcYSeleccionarLaOpcionPagar()
        {
            //No implementado
        }

        [Given(@"el padre ya realizó el pago")]
        public async Task GivenElPadreYaRealizoElPago()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Pagos.Add(new Pago()
            {
                PagoId = 1,
                TarjetaId = 1,
                TutoriaId = 1,
                Descripcion = " Pago de tutoria de redes",
                CvcTarjeta = "123"
            });

            await context.SaveChangesAsync();
        }

        [When(@"el docente solicite un comprobante para inciar la tutoria")]
        public void WhenElDocenteSoliciteUnComprobanteParaInciarLaTutoria()
        {
            //No implementado
        }

        [Then(@"el padre podrá enviar el recibo para que no exista ningun inconveniente")]
        public void ThenElPadrePodraEnviarElReciboParaQueNoExistaNingunInconveniente()
        {
            //No implementado
        }

        [Given(@"el padre ya no quiere realizar el pago")]
        public void GivenElPadreYaNoQuiereRealizarElPago()
        {
            //No implementado
        }

        [When(@"este se encuentre en la seccion de pago")]
        public void WhenEsteSeEncuentreEnLaSeccionDePago()
        {
            //No implementado
        }

        [Then(@"se le mostrará la opcion “Cancelar” si es que el padre no se encuentra conforme con algun dato de pago")]
        public void ThenSeLeMostraraLaOpcionCancelarSiEsQueElPadreNoSeEncuentraConformeConAlgunDatoDePago()
        {
            //No implementado
        }

    }
}
