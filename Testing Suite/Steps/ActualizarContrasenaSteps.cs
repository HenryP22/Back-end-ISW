using System;
using TechTalk.SpecFlow;

namespace Testing_Suite.Steps
{
    [Binding]
    public class ActualizarContrasenaSteps
    {
        [Given(@"quiero actualizar mi contraseña")]
        public void GivenQuieroActualizarMiContrasena()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"ya actualicé mi contraseña")]
        public void GivenYaActualiceMiContrasena()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"la aplicación debe confirmar que soy yo")]
        public void GivenLaAplicacionDebeConfirmarQueSoyYo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiero introducir una nueva contraseña")]
        public void WhenQuieroIntroducirUnaNuevaContrasena()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"esta se ha confirmado")]
        public void WhenEstaSeHaConfirmado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiero actualizar mi contraseña")]
        public void WhenQuieroActualizarMiContrasena()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"la aplicación me indica que la contraseña debe tener más de (.*) caracteres, no debe contener especiales")]
        public void ThenLaAplicacionMeIndicaQueLaContrasenaDebeTenerMasDeCaracteresNoDebeContenerEspeciales(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"esta no podrá ser la misma que la actual u otras anteriores")]
        public void ThenEstaNoPodraSerLaMismaQueLaActualUOtrasAnteriores()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"la aplicación me mandará un email a mi correo registrado con la confirmación")]
        public void ThenLaAplicacionMeMandaraUnEmailAMiCorreoRegistradoConLaConfirmacion()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"este me pedirá introducir mi contraseña actual para asegurarse de ello")]
        public void ThenEsteMePediraIntroducirMiContrasenaActualParaAsegurarseDeEllo()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
