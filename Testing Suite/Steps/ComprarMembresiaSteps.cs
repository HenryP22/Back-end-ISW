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
    public class ComprarMembresiaSteps : BasePruebas
    {
        [Given(@"la cuenta del docente es relativamente nueva")]
        public void GivenLaCuentaDelDocenteEsRelativamenteNueva()
        {
            var Docente = new Docente()
            {
                DocenteId = 1,
                Nombres = " Henrry",
                Apellidos = " Mendoza",
                DNI = "16534786",
                Domicilio = "San Miguel calle puquina los condominios la waka",
                Correo = "henrry@gmail.com",
                Disponibilidad = "No Disponible",
                Numero_cuenta = "2534586198371450",
                Membresia = "NoActiva"
            };
        }

        [When(@"inicie sesión los primeros días")]
        public void WhenInicieSesionLosPrimerosDias()
        {
            
        }

        [Then(@"se le mostrará una promoción de prueba de la membresía")]
        public void ThenSeLeMostraraUnaPromocionDePruebaDeLaMembresia()
        {
            
        }

        [Given(@"el docente está interesado en suscribirse al periodo de prueba")]
        public void GivenElDocenteEstaInteresadoEnSuscribirseAlPeriodoDePrueba()
        {
            
        }

        [When(@"seleccione “Aceptar” en la promoción")]
        public void WhenSeleccioneAceptarEnLaPromocion()
        {
            
        }

        [Then(@"se le pedirá sus datos personales y de su tarjeta para iniciar el periodo de prueba")]
        public void ThenSeLePediraSusDatosPersonalesYDeSuTarjetaParaIniciarElPeriodoDePrueba()
        {
            var membresiaCreateDTO = new MembresiaCreateDto() 
            { 
                Cvc_tarjeta = "956", 
                Fecha_expiracion = "22-05", 
                TarjetaId = 1, 
                DocenteId = 1 
            };
        }

        [Given(@"un docente quiere realizar la compra de una membresía por medio de la página web")]
        public void GivenUnDocenteQuiereRealizarLaCompraDeUnaMembresiaPorMedioDeLaPaginaWeb()
        {
            
        }

        [When(@"El docente iniciará sesión a la web, luego seleccionará la opción “Obtener membresía”")]
        public void WhenElDocenteIniciaraSesionALaWebLuegoSeleccionaraLaOpcionObtenerMembresia()
        {
            
        }

        [Then(@"e mostrará una interfaz donde se le pedirá al docente que seleccione la tarjeta anteriormente registrada")]
        public void ThenEMostraraUnaInterfazDondeSeLePediraAlDocenteQueSeleccioneLaTarjetaAnteriormenteRegistrada()
        {
            
        }

        [Then(@"luego de ello colocara el cvc, asimismo escogerá el plan de membresía que más le convenga")]
        public void ThenLuegoDeElloColocaraElCvcAsimismoEscogeraElPlanDeMembresiaQueMasLeConvenga()
        {
            
        }

        [Then(@"finalmente seleccionará la opción “comprar”")]
        public void ThenFinalmenteSeleccionaraLaOpcionComprar()
        {
            
        }

        [Given(@"el docente desea continuar con la membresía activa")]
        public void GivenElDocenteDeseaContinuarConLaMembresiaActiva()
        {
            
        }

        [When(@"este quiera prolongar su suscripción, se dirigirá a la opción “Mi Perfil”")]
        public async Task WhenEsteQuieraProlongarSuSuscripcionSeDirigiraALaOpcionMiPerfil()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Docentes.Add(new Docente()
            {
                DocenteId = 1,
                Nombres = " Henrry",
                Apellidos = " Mendoza",
                DNI = "16534786",
                Domicilio = "San Miguel calle puquina los condominios la waka",
                Correo = "henrry@gmail.com",
                Disponibilidad = "No Disponible",
                Numero_cuenta = "2534586198371450",
                Membresia = "NoActiva"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new DocenteServiceImpl(context2, mapper);

            var respuesta = await controller.GetById(id);

            //Verificación

            var Docentes = respuesta.DocenteId;
            Assert.AreEqual(id, Docentes);
        }

        [Then(@"en la sección de status de la membresía, el docente podrá seleccionar la opción “Renovar Membresía”")]
        public async Task ThenEnLaSeccionDeStatusDeLaMembresiaElDocentePodraSeleccionarLaOpcionRenovarMembresia()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Membresias.Add(new Membresia() { MembresiaId = 1, Cvc_tarjeta = "956", Fecha_expiracion = "22-05", TarjetaId = 1, DocenteId = 1 });


            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            var membresiaUpdateDTO = new MembresiaUpdateDto() { MembresiaId = 1, Cvc_tarjeta = "499", Fecha_expiracion = "18-05", TarjetaId = 1, DocenteId = 1 };

            int id = 1;
            var controller = new MembresiaServiceImpl(context2, mapper);

            await controller.Update(id, membresiaUpdateDTO);

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Membresias.AnyAsync(x => x.Cvc_tarjeta == "499");
            Assert.IsTrue(existe);
        }

        [Given(@"Un docente ya no quiere contar con la membresía")]
        public void GivenUnDocenteYaNoQuiereContarConLaMembresia()
        {
            
        }

        [When(@"el docente iniciará sesión en la web, entonces se dirigirá a su perfil de docente")]
        public void WhenElDocenteIniciaraSesionEnLaWebEntoncesSeDirigiraASuPerfilDeDocente()
        {
            
        }

        [Then(@"se le mostrará el status de su membresía con la opción de “Cancelar Membresía”")]
        public async Task ThenSeLeMostraraElStatusDeSuMembresiaConLaOpcionDeCancelarMembresia()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Membresias.Add(new Membresia() { MembresiaId = 1, Cvc_tarjeta = "956", Fecha_expiracion = "22-05", TarjetaId = 1, DocenteId = 1 });
            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);
            var controller = new MembresiaServiceImpl(context2, mapper);

            await controller.Remove(1);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Membresias.AnyAsync();
            Assert.IsFalse(existe);
        }

    }
}
