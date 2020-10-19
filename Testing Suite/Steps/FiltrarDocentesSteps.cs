using System;
using TechTalk.SpecFlow;

namespace Testing_Suite.Steps
{
    [Binding]
    public class FiltrarDocentesSteps
    {
        [Given(@"el padre ha iniciado sesión en la plataforma web")]
        public void GivenElPadreHaIniciadoSesionEnLaPlataformaWeb()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"el usuario padre se encuentra en la sección “Mis clases”")]
        public void GivenElUsuarioPadreSeEncuentraEnLaSeccionMisClases()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"seleccione la opción “Buscar” y redacte el nombre de un docente")]
        public void WhenSeleccioneLaOpcionBuscarYRedacteElNombreDeUnDocente()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"ingrese el nombre del curso en el formulario de búsqueda y presione en buscar")]
        public void WhenIngreseElNombreDelCursoEnElFormularioDeBusquedaYPresioneEnBuscar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"ingrese el rango de un costo deseado en el formulario de búsqueda y seleccione la opción “Buscar”")]
        public void WhenIngreseElRangoDeUnCostoDeseadoEnElFormularioDeBusquedaYSeleccioneLaOpcionBuscar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"ingrese una cantidad de horas en el formulario de búsqueda y seleccione “Buscar”")]
        public void WhenIngreseUnaCantidadDeHorasEnElFormularioDeBusquedaYSeleccioneBuscar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostrara el docente solicitado, donde al seleccionarlo se mostrara una interfaz con sus detalles")]
        public void ThenSeMostraraElDocenteSolicitadoDondeAlSeleccionarloSeMostraraUnaInterfazConSusDetalles()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se listaran los docentes que enseñen el curso ingresado")]
        public void ThenSeListaranLosDocentesQueEnsenenElCursoIngresado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se listaran solo los docentes que cobren esa cantidad")]
        public void ThenSeListaranSoloLosDocentesQueCobrenEsaCantidad()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostraran los docentes que estén enseñando la cantidad de horas deseadas")]
        public void ThenSeMostraranLosDocentesQueEstenEnsenandoLaCantidadDeHorasDeseadas()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
