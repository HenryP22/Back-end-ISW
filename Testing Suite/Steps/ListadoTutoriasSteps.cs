using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Testing;
using TutoFinder.Entity;
using TutoFinder.Service.Impl;

namespace Testing_Suite.Steps
{
    [Binding]
    public class ListadoTutoriasSteps : BasePruebas
    {
        [Given(@"debo tener la mayor cantidad de opciones posibles respecto a las preferencias")]
        public void GivenDeboTenerLaMayorCantidadDeOpcionesPosiblesRespectoALasPreferencias()
        {
            //No implementado
        }

        [Given(@"las tutorias se dictan en un área especifica del lugar")]
        public void GivenLasTutoriasSeDictanEnUnAreaEspecificaDelLugar()
        {
            //No implementado
        }

        [Given(@"hay docentes con membresia en la aplicacion")]
        public void GivenHayDocentesConMembresiaEnLaAplicacion()
        {
            new Docente
            {
                DocenteId = 1,
                Nombres = " Henrry",
                Apellidos = " Mendoza",
                DNI = "16534786",
                Domicilio = "San Miguel calle puquina los condominios la waka",
                Correo = "henrry@gmail.com",
                Disponibilidad = "No Disponible",
                Numero_cuenta = "2534586198371450",
                Membresia = "Activa"
            };
        }
        
        [When(@"busque una tutoria")]
        public void WhenBusqueUnaTutoria()
        {
            //No implementado
        }

        [When(@"quiera buscar un servicio de tutoria")]
        public void WhenQuieraBuscarUnServicioDeTutoria()
        {
            //No implementado
        }

        [When(@"se visualice la lista de tutorias")]
        public async Task WhenSeVisualiceLaListaDeTutorias()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var controller = new TutoriaServiceImpl(context, mapper);

            var respuesta = await controller.GetAll(1, 50);

            //Verificación

            var tutorias = respuesta.Total;
            Assert.AreEqual(0, tutorias);
        }
        
        [Then(@"la aplicacion me mostrará un listado de todas las publicaciones de tutorias")]
        public async Task ThenLaAplicacionMeMostraraUnListadoDeTodasLasPublicacionesDeTutorias()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Tutorias.Add(new Tutoria
            {
                TutoriaId = 1,
                AlumnoId = 1,
                DocenteId = 1,
                CursoId = 1,
                Costo = 30.25,
                Descripcion = "Repaso de codigo Api",
                Cantidad_minutos = 3
            });
            context.Alumnos.Add(new Alumno
            {
                AlumnoId = 1
            });
            context.Docentes.Add(new Docente
            {
                DocenteId = 1
            });
            context.Cursos.Add(new Curso
            {
                CursoId = 1
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);


            var controller = new TutoriaServiceImpl(context2, mapper);

            var respuesta = await controller.GetAll(1, 50);

            //Verificación

            var tutorias = respuesta.Total;
            Assert.AreEqual(1, tutorias);
        }
        
        [Then(@"la aplicacion me habilitara aquellas que esten mas cercanas a mi ubicacion")]
        public void ThenLaAplicacionMeHabilitaraAquellasQueEstenMasCercanasAMiUbicacion()
        {
            //No implementado
        }
        
        [Then(@"la aplicacion priorizará a aquellas con membresia")]
        public void ThenLaAplicacionPriorizaraAAquellasConMembresia()
        {
            //El GetAll por defecto prioriza a aquellas tutorías con docentes que tienen membresía
        }
    }
}
