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
    public class FiltrarDocentesSteps : BasePruebas
    {
        [Given(@"el padre ha iniciado sesión en la plataforma web")]
        public void GivenElPadreHaIniciadoSesionEnLaPlataformaWeb()
        {
            //No implementado
        }

        [Given(@"el usuario padre se encuentra en la sección “Mis clases”")]
        public void GivenElUsuarioPadreSeEncuentraEnLaSeccionMisClases()
        {
            //No implementado
        }

        [When(@"seleccione la opción “Buscar” y redacte el nombre de un docente")]
        public void WhenSeleccioneLaOpcionBuscarYRedacteElNombreDeUnDocente()
        {
            //No implementado
        }

        [When(@"ingrese el nombre del curso en el formulario de búsqueda y presione en buscar")]
        public async Task WhenIngreseElNombreDelCursoEnElFormularioDeBusquedaYPresioneEnBuscar()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Cursos.Add(new Curso() { CursoId = 1, Nombre = "Aplicaciones Web", Descripcion = "ez", Grado_academico = "Primaria" });
            context.Cursos.Add(new Curso() { CursoId = 2, Nombre = "Open Source", Descripcion = "ez", Grado_academico = "Secundaria" });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new CursoServiceImpl(context2, mapper);

            var respuesta = await controller.GetById(id);

            //Verificación

            var cursos = respuesta.CursoId;
            Assert.AreEqual(id, cursos);
        }

        [When(@"ingrese el rango de un costo deseado en el formulario de búsqueda y seleccione la opción “Buscar”")]
        public async Task WhenIngreseElRangoDeUnCostoDeseadoEnElFormularioDeBusquedaYSeleccioneLaOpcionBuscar()
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

            //Prueba

            double precio = 50;
            var controller = new TutoriaServiceImpl(context2, mapper);

            var respuesta = await controller.FiltroCostoMaximo(precio, 1, 50);

            //Verificación

            var tutorias = respuesta.Total;
            Assert.AreEqual(1, tutorias);
        }
        
        [When(@"ingrese una cantidad de horas en el formulario de búsqueda y seleccione “Buscar”")]
        public void WhenIngreseUnaCantidadDeHorasEnElFormularioDeBusquedaYSeleccioneBuscar()
        {
            //No implementado
        }

        [Then(@"se mostrara el docente solicitado, donde al seleccionarlo se mostrara una interfaz con sus detalles")]
        public void ThenSeMostraraElDocenteSolicitadoDondeAlSeleccionarloSeMostraraUnaInterfazConSusDetalles()
        {
            //No implementado
        }

        [Then(@"se listaran los docentes que enseñen el curso ingresado")]
        public void ThenSeListaranLosDocentesQueEnsenenElCursoIngresado()
        {
            //No implementado
        }

        [Then(@"se listaran solo los docentes que cobren esa cantidad")]
        public void ThenSeListaranSoloLosDocentesQueCobrenEsaCantidad()
        {
            //No implementado
        }

        [Then(@"se mostraran los docentes que estén enseñando la cantidad de horas deseadas")]
        public void ThenSeMostraranLosDocentesQueEstenEnsenandoLaCantidadDeHorasDeseadas()
        {
            //No implementado
        }
    }
}
