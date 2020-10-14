using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TutoFinder.Dto;
using TutoFinder.Entity;
using TutoFinder.Service.Impl;

namespace Testing.Testing
{
    [TestClass]
    public class AlumnoControllerTests : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerTodosLosCursos()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Alumnos.Add(new Alumno()
            {
                AlumnoId = 1,
                PadreId = 1,
                Nombres = "Lucho",
                Apellidos = "Cardenas",
                DNI = "75863340",
                Correo = "lucho13@gmail.com",
                Grado_academico = "Secundaria"
            });
            context.Alumnos.Add(new Alumno()
            {
                AlumnoId = 2,
                PadreId = 1,
                Nombres = "Carlos",
                Apellidos = "Avila",
                DNI = "16854793",
                Correo = "carlos13@gmail.com",
                Grado_academico = "Primaria"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            var controller = new AlumnoServiceImpl(context2, mapper);

            var respuesta = await controller.GetAll(1, 5);

            //Verificación

            var Alumnos = respuesta.Total;
            Assert.AreEqual(2, Alumnos);
        }
        [TestMethod]
        public async Task ObtenerAlumnoPorId()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Alumnos.Add(new Alumno() { AlumnoId = 1,
                PadreId = 1,
                Nombres = "Lucho",
                Apellidos = "Cardenas",
                DNI = "75863340",
                Correo = "lucho13@gmail.com",
                Grado_academico = "Secundaria"
            });
            context.Padres.Add(new Padre
            {
                PadreId = 1,
                Nombres = " Moises",
                Apellidos = "Cahuana",
                DNI = " 35826791",
                Correo = "Moieses@hotmail.com"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new AlumnoServiceImpl(context2, mapper);

            var respuesta = await controller.GetById(id);

            //Verificación

            var Alumnos = respuesta.AlumnoId;
            Assert.AreEqual(id, Alumnos);
        }
        [TestMethod]
        public async Task CrearAlumno()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var AlumnoCreateDTO = new AlumnoCreateDto() {
                PadreId = 1,
                Nombres = "Carlos",
                Apellidos = "Avila",
                DNI = "16854793",
                Correo = "carlos13@gmail.com",
                Grado_academico = "Primaria"
            };

            //Prueba

            int id = 1;
            var controller = new AlumnoServiceImpl(context, mapper);

            await controller.Create(AlumnoCreateDTO);

            //Verificación

            var context2 = ConstruirContext(nombreDB);
            var cantidad = await context2.Alumnos.CountAsync();
            Assert.AreEqual(1, cantidad);
        }
        [TestMethod]
        public async Task EditarAlumnoExistente()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Alumnos.Add(new Alumno() { AlumnoId = 1,
                PadreId = 1,
                Nombres = "Carlos",
                Apellidos = "Avila",
                DNI = "16854793",
                Correo = "carlos13@gmail.com",
                Grado_academico = "Primaria"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            var AlumnoUpdateDTO = new AlumnoUpdateDto() {
                PadreId = 1,
                Nombres = "Lucho",
                Apellidos = "Cardenas",
                DNI = "75863340",
                Correo = "lucho13@gmail.com",
                Grado_academico = "Secundaria"
            };

            //Prueba

            int id = 1;
            var controller = new AlumnoServiceImpl(context2, mapper);

            await controller.Update(id, AlumnoUpdateDTO);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Alumnos.AnyAsync(x => x.Nombres == "Lucho");
            Assert.IsTrue(existe);
        }
        [TestMethod]
        public async Task BorrarAlumno()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Alumnos.Add(new Alumno() { AlumnoId = 1,
                PadreId = 1,
                Nombres = "Lucho",
                Apellidos = "Cardenas",
                DNI = "75863340",
                Correo = "lucho13@gmail.com",
                Grado_academico = "Secundaria"
            });
            await context.SaveChangesAsync();

            //Prueba

            var context2 = ConstruirContext(nombreDB);
            var controller = new AlumnoServiceImpl(context2, mapper);

            await controller.Remove(1);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Alumnos.AnyAsync();
            Assert.IsFalse(existe);
        }
        [TestMethod]
        public async Task AlumnoExiste()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Alumnos.Add(new Alumno() { AlumnoId = 1,
                PadreId = 1,
                Nombres = "Lucho",
                Apellidos = "Cardenas",
                DNI = "75863340",
                Correo = "lucho13@gmail.com",
                Grado_academico = "Secundaria"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new AlumnoServiceImpl(context2, mapper);

            var respuesta = controller.Existencia(id);

            //Verificación

            Assert.IsTrue(respuesta);
        }
        [TestMethod]
        public async Task AlumnoNoExiste()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            //Prueba

            int id = 1;
            var controller = new AlumnoServiceImpl(context, mapper);

            var respuesta = controller.Existencia(id);

            //Verificación

            Assert.IsFalse(respuesta);
        }
    }
}
