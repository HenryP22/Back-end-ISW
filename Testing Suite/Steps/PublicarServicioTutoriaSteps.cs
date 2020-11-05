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
    public class PublicarServicioTutoriaSteps : BasePruebas
    {
        [Given(@"el docente desea registrar la tutoría a brindar")]
        public void GivenElDocenteDeseaRegistrarLaTutoriaABrindar()
        {
            //No implementado
        }

        [When(@"el docente iniciara sesión en la web y se dirigirá a la opción “Registrar Tutoría”")]
        public void WhenElDocenteIniciaraSesionEnLaWebYSeDirigiraALaOpcionRegistrarTutoria()
        {
            //No implementado
        }

        [Then(@"se le mostrará una interfaz donde deberá escoger el nivel académico")]
        public void ThenSeLeMostraraUnaInterfazDondeDeberaEscogerElNivelAcademico()
        {
            //No implementado
        }

        [Then(@"tendrá que ingresar los datos de la tutoría \(Fecha, costo, horas, tema\)")]
        public void ThenTendraQueIngresarLosDatosDeLaTutoriaFechaCostoHorasTema()
        {
            new Tutoria
            {
                TutoriaId = 1,
                AlumnoId = 1,
                DocenteId = 1,
                CursoId = 1,
                Costo = 30.25,
                Descripcion = "Repaso de codigo Api",
                Cantidad_minutos = 3
            };
        }

        [Given(@"el docente desea publicar la tutoría a brindar")]
        public void GivenElDocenteDeseaPublicarLaTutoriaABrindar()
        {
            //No implementado
        }

        [When(@"ya haya ingresado todos los datos de la tutoría, este se dirigirá a la opción “Siguiente”")]
        public void WhenYaHayaIngresadoTodosLosDatosDeLaTutoriaEsteSeDirigiraALaOpcionSiguiente()
        {
            //No implementado
        }

        [Then(@"se le mostrará una interfaz con los datos de la tutoría para que pueda revisar si están correctos")]
        public void ThenSeLeMostraraUnaInterfazConLosDatosDeLaTutoriaParaQuePuedaRevisarSiEstanCorrectos()
        {
            //No implementado
        }

        [Then(@"es así seleccionará la opción “Publicar”")]
        public void ThenEsAsiSeleccionaraLaOpcionPublicar()
        {
            //No implementado
        }

        [Given(@"el docente desea editar información errónea respecto al servicio de tutoría que quiere brindar")]
        public async Task GivenElDocenteDeseaEditarInformacionErroneaRespectoAlServicioDeTutoriaQueQuiereBrindar()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Tutorias.Add(new Tutoria()
            {
                TutoriaId = 1,
                AlumnoId = 1,
                DocenteId = 1,
                CursoId = 1,
                Costo = 30.25,
                Descripcion = "Repaso de codigo Api",
                Cantidad_minutos = 3
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            var TutoriaUpdateDTO = new TutoriaUpdateDto()
            {
                AlumnoId = 1,
                DocenteId = 1,
                CursoId = 1,
                Costo = 30.25,
                Descripcion = "Repaso de Docker",
                Cantidad_minutos = 3
            };

            //Prueba

            int id = 1;
            var controller = new TutoriaServiceImpl(context2, mapper);

            await controller.Update(id, TutoriaUpdateDTO);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Tutorias.AnyAsync(x => x.Descripcion == "Repaso de Docker");
            Assert.IsTrue(existe);
        }

        [When(@"este se diriga a la opción “anterior”")]
        public void WhenEsteSeDirigaALaOpcionAnterior()
        {
            //No implementado
        }

        [Then(@"se le mostrará la interfaz de registro con sus datos anteriores")]
        public void ThenSeLeMostraraLaInterfazDeRegistroConSusDatosAnteriores()
        {
            //No implementado
        }

        [Given(@"el Docente desea eliminar la tutoría publicada en la aplicación web")]
        public async Task GivenElDocenteDeseaEliminarLaTutoriaPublicadaEnLaAplicacionWeb()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Tutorias.Add(new Tutoria()
            {
                TutoriaId = 1,
                AlumnoId = 1,
                DocenteId = 1,
                CursoId = 1,
                Costo = 30.25,
                Descripcion = "Repaso de codigo Api",
                Cantidad_minutos = 3
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new TutoriaServiceImpl(context2, mapper);

            await controller.Remove(id);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Tutorias.AnyAsync();
            Assert.IsFalse(existe);
        }

        [When(@"el docente iniciara sesión en la web y se dirigirá a la opción “Mis tutorías”")]
        public void WhenElDocenteIniciaraSesionEnLaWebYSeDirigiraALaOpcionMisTutorias()
        {
            //No implementado
        }

        [Then(@"se mostrará un interfaz  donde el docente escogerá la tutoría publicada")]
        public async Task ThenSeMostraraUnInterfazDondeElDocenteEscogeraLaTutoriaPublicada()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Tutorias.Add(new Tutoria()
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

            int id = 1;
            var controller = new TutoriaServiceImpl(context2, mapper);

            var respuesta = await controller.GetById(id);

            var Tutorias = respuesta.TutoriaId;
            Assert.AreEqual(id, Tutorias);
        }

        [Then(@"finalmente seleccionará la opción “eliminar”")]
        public void ThenFinalmenteSeleccionaraLaOpcionEliminar()
        {
            //No implementado
        }

    }
}
