using Microsoft.EntityFrameworkCore;
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
    public class MetodosPagoSteps : BasePruebas
    {
        [Given(@"el usuario padre ha iniciado sesión correctamente")]
        public void GivenElUsuarioPadreHaIniciadoSesionCorrectamente()
        {
            //No implementado
        }

        [Given(@"se encuentra en la sección Tarjetas de la vista Perfil")]
        public void GivenSeEncuentraEnLaSeccionTarjetasDeLaVistaPerfil()
        {
            //No implementado
        }

        [Given(@"el ususario padre se encuentra en el formulario de registro de nueva tarjeta")]
        public void GivenElUsusarioPadreSeEncuentraEnElFormularioDeRegistroDeNuevaTarjeta()
        {
            new Tarjeta
            {
                TarjetaId = 1,
                Fecha_expiracion = "20/02/2025",
                Nombre_poseedor = " Henry Papi",
                Numero_tarjeta = "5536848370023594"
            };
        }
        
        [When(@"seleccione la opción “Agregar tarjeta”")]
        public void WhenSeleccioneLaOpcionAgregarTarjeta()
        {
            //No implementado
        }

        [When(@"se ingrese información incorrecta y se envié el formulario")]
        public void WhenSeIngreseInformacionIncorrectaYSeEnvieElFormulario()
        {
            //Si algún datos está mal colocado, no se admitirá la información
            //entityBuilder.Property(x => x.Fecha_expiracion)
            //    .IsRequired().HasMaxLength(10);
            //entityBuilder.Property(x => x.Nombre_poseedor)
            //    .IsRequired().HasMaxLength(20);
            //entityBuilder.Property(x => x.Numero_tarjeta)
            //    .IsRequired().HasMaxLength(20);
        }
        
        [When(@"seleccione la opción “eliminar” de una tarjeta registrada")]
        public async Task WhenSeleccioneLaOpcionEliminarDeUnaTarjetaRegistrada()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Tarjetas.Add(new Tarjeta()
            {
                TarjetaId = 1
            });
            await context.SaveChangesAsync();

            //Prueba

            var context2 = ConstruirContext(nombreDB);
            var controller = new TarjetaServiceImpl(context2, mapper);

            await controller.Remove(1);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Padres.AnyAsync();
            Assert.IsFalse(existe);
        }
        
        [Then(@"se mostrara un formulario para el registro de una nueva tarjeta")]
        public void ThenSeMostraraUnFormularioParaElRegistroDeUnaNuevaTarjeta()
        {
            //No implementado
        }

        [Then(@"el sistema mostrara el mensaje “los datos no son correctos”")]
        public void ThenElSistemaMostraraElMensajeLosDatosNoSonCorrectos()
        {
            //No implementado
        }

        [Then(@"se mostrara una ventana de confirmación para esa accion\.")]
        public void ThenSeMostraraUnaVentanaDeConfirmacionParaEsaAccion_()
        {
            //No implementado
        }
    }
}
