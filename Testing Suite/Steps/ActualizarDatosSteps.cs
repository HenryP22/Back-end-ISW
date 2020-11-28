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
    public class ActualizarDatosSteps : BasePruebas
    {
        [Given(@"el usuario tiene datos existentes")]
        public async Task GivenElUsuarioTieneDatosExistentes()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Padres.Add(new Padre()
            {
                PadreId = 1,
                Nombres = " Moises",
                Apellidos = "Cahuana",
                DNI = " 35826791",
                Correo = "Moieses@hotmail.com"
            });

            await context.SaveChangesAsync();

        }
        
        [Given(@"que ya actualicé mis datos")]
        public void GivenQueYaActualiceMisDatos()
        {
            var PadreUpdateDTO = new PadreUpdateDto()
            {
                Nombres = "Henry",
                Apellidos = "Bustos",
                DNI = "75863340",
                Correo = "Moieses@hotmail.com"
            };

        }
        
        [Given(@"la contraseña de ingreso")]
        public void GivenLaContrasenaDeIngreso()
        {
            //No implementado
        }

        [When(@"quiera actualizar sus datos")]
        public void WhenQuieraActualizarSusDatos()
        {
            //No implementado
        }

        [When(@"quiera confirmar estos cambios")]
        public void WhenQuieraConfirmarEstosCambios()
        {
            //No implementado
        }

        [When(@"se da por terminado la actualización")]
        public async Task WhenSeDaPorTerminadoLaActualizacion()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Padres.Add(new Padre()
            {
                PadreId = 1,
                Nombres = " Moises",
                Apellidos = "Cahuana",
                DNI = " 35826791",
                Correo = "Moieses@hotmail.com"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            var PadreUpdateDTO = new PadreUpdateDto()
            {
                Nombres = "Henry",
                Apellidos = "Bustos",
                DNI = "75863340",
                Correo = "Moieses@hotmail.com"
            };

            //Prueba

            int id = 1;
            var controller = new PadreServiceImpl(context2, mapper);

            await controller.Update(id, PadreUpdateDTO);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Padres.AnyAsync(x => x.Nombres == "Henry");
            Assert.IsTrue(existe);
        }
        
        [Then(@"la aplicación le permitirá escribir sobre estos")]
        public void ThenLaAplicacionLePermitiraEscribirSobreEstos()
        {
            //No implementado
        }

        [Then(@"la aplicación me pedirá ingresar mi contrasena actual")]
        public void ThenLaAplicacionMePediraIngresarMiContrasenaActual()
        {
            //No implementado
        }

        [Then(@"me enviará un correo para informarme de los cambios realizados para que como docente pueda verificar si hice yo este cambio")]
        public void ThenMeEnviaraUnCorreoParaInformarmeDeLosCambiosRealizadosParaQueComoDocentePuedaVerificarSiHiceYoEsteCambio()
        {
            //No implementado
        }
    }
}
