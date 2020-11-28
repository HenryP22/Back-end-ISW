using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TutoFinder.Controllers;
using TutoFinder.Dto;
using TutoFinder.Entity;
using TutoFinder.Service;
using TutoFinder.Service.Impl;

namespace Testing.Testing
{
    [TestClass]
    public class CursoControllerTests : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerTodosLosCursos()
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

            var controller = new CursoServiceImpl(context2, mapper);

            var respuesta = await controller.GetAll(1, 5);

            //Verificación

            var cursos = respuesta.Total;
            Assert.AreEqual(2, cursos);
        }
        [TestMethod]
        public async Task ObtenerCursoPorId()
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
        [TestMethod]
        public async Task CrearCurso()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var cursoCreateDTO = new CursoCreateDto() { Nombre = "Open Source", Descripcion = "ez", Grado_academico = "Secundaria" };

            //Prueba

            var controller = new CursoServiceImpl(context, mapper);

            await controller.Create(cursoCreateDTO);

            //Verificación

            var context2 = ConstruirContext(nombreDB);
            var cantidad = await context2.Cursos.CountAsync();
            Assert.AreEqual(1, cantidad);
        }
        [TestMethod]
        public async Task EditarCursoExistente()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Cursos.Add(new Curso() { CursoId = 1, Nombre = "Aplicaciones Web", Descripcion = "ez", Grado_academico = "Primaria" });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            var cursoUpdateDTO = new CursoUpdateDto() { Nombre = "Open Source", Descripcion = "ez", Grado_academico = "Secundaria" };

            //Prueba

            int id = 1;
            var controller = new CursoServiceImpl(context2, mapper);

            await controller.Update(id, cursoUpdateDTO);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Cursos.AnyAsync(x => x.Nombre == "Open Source");
            Assert.IsTrue(existe);
        }
        [TestMethod]
        public async Task BorrarCurso()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Cursos.Add(new Curso() { CursoId = 1, Nombre = "Aplicaciones Web", Descripcion = "ez", Grado_academico = "Primaria" });
            await context.SaveChangesAsync();

            //Prueba

            var context2 = ConstruirContext(nombreDB);
            var controller = new CursoServiceImpl(context2, mapper);

            await controller.Remove(1);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Cursos.AnyAsync();
            Assert.IsFalse(existe);
        }
        [TestMethod]
        public async Task CursoExiste()
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

            var respuesta = controller.Existencia(id);

            //Verificación

            Assert.IsTrue(respuesta);
        }
        [TestMethod]
        public void CursoNoExiste()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            //Prueba

            int id = 1;
            var controller = new CursoServiceImpl(context, mapper);

            var respuesta = controller.Existencia(id);

            //Verificación

            Assert.IsFalse(respuesta);
        }
    }
}
