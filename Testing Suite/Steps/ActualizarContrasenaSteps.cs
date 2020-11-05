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
            
        }
        
        [Given(@"ya actualicé mi contraseña")]
        public void GivenYaActualiceMiContrasena()
        {
            
        }
        
        [Given(@"la aplicación debe confirmar que soy yo")]
        public void GivenLaAplicacionDebeConfirmarQueSoyYo()
        {
            
        }
        
        [When(@"quiero introducir una nueva contraseña")]
        public void WhenQuieroIntroducirUnaNuevaContrasena()
        {
            
        }
        
        [When(@"esta se ha confirmado")]
        public void WhenEstaSeHaConfirmado()
        {
            
        }
        
        [When(@"quiero actualizar mi contraseña")]
        public void WhenQuieroActualizarMiContrasena()
        {
            
        }

        [Then(@"la aplicación me indica que la contraseña debe tener más de ocho caracteres, no debe contener especiales")]
        public void ThenLaAplicacionMeIndicaQueLaContrasenaDebeTenerMasDeOchoCaracteresNoDebeContenerEspeciales()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"esta no podrá ser la misma que la actual u otras anteriores")]
        public void ThenEstaNoPodraSerLaMismaQueLaActualUOtrasAnteriores()
        {
            
        }
        
        [Then(@"la aplicación me mandará un email a mi correo registrado con la confirmación")]
        public void ThenLaAplicacionMeMandaraUnEmailAMiCorreoRegistradoConLaConfirmacion()
        {
            
        }
        
        [Then(@"este me pedirá introducir mi contraseña actual para asegurarse de ello")]
        public void ThenEsteMePediraIntroducirMiContrasenaActualParaAsegurarseDeEllo()
        {
            
        }
    }
}
