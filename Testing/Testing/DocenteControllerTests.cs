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
    public class DocenteControllerTests : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerTodosLosDocentes()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Docentes.Add(new Docente()
            {
                DocenteId = 1,
                Nombres = "Percy Alessandro",
                Apellidos = "Zamora P",
                DNI = "54545454",
                Domicilio = "Av. Pasto 22",
                Correo = "pepi@hotmail.com",
                Disponibilidad = "Disponible",
                Numero_cuenta = "5683218468",
                Membresia = "Premium"
            });
            context.Docentes.Add(new Docente()
            {
                DocenteId = 2,
                Nombres = "Moises Jesus",
                Apellidos = "Jerusalen Santo",
                DNI = "98989894",
                Domicilio = "Av. Virgen 293",
                Correo = "padrenuestro@hotmail.com",
                Disponibilidad = "Disponible",
                Numero_cuenta = "5683218468",
                Membresia = "Premium"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            var controller = new DocenteServiceImpl(context2, mapper);

            var respuesta = await controller.GetAll(1, 5);

            //Verificación

            var docentes = respuesta.Total;
            Assert.AreEqual(2, docentes);
        }
        [TestMethod]
        public async Task ObtenerDocentePorId()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Docentes.Add(new Docente()
            {
                DocenteId = 1,
                Nombres = "Percy Alessandro",
                Apellidos = "Zamora P",
                DNI = "54545454",
                Domicilio = "Av. Pasto 22",
                Correo = "pepi@hotmail.com",
                Disponibilidad = "Disponible",
                Numero_cuenta = "5683218468",
                Membresia = "Premium"
            });
            context.Docentes.Add(new Docente()
            {
                DocenteId = 2,
                Nombres = "Moises Jesus",
                Apellidos = "Jerusalen Santo",
                DNI = "98989894",
                Domicilio = "Av. Virgen 293",
                Correo = "padrenuestro@hotmail.com",
                Disponibilidad = "Disponible",
                Numero_cuenta = "5683218468",
                Membresia = "Premium"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new DocenteServiceImpl(context2, mapper);

            var respuesta = await controller.GetById(id);

            //Verificación

            var docente = respuesta.DocenteId;
            Assert.AreEqual(id, docente);
        }
        [TestMethod]
        public async Task CrearDocente()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var docenteCreateDTO = new DocenteCreateDto()
            {
                Nombres = "Moises Jesus",
                Apellidos = "Jerusalen Santo",
                DNI = "98989894",
                Domicilio = "Av. Virgen 293",
                Correo = "padrenuestro@hotmail.com",
                Disponibilidad = "Disponible",
                Numero_cuenta = "5683218468",
                Membresia = "Premium"
            };

            //Prueba

            var controller = new DocenteServiceImpl(context, mapper);

            await controller.Create(docenteCreateDTO);

            //Verificación

            var context2 = ConstruirContext(nombreDB);
            var cantidad = await context2.Docentes.CountAsync();
            Assert.AreEqual(1, cantidad);
        }
        [TestMethod]
        public async Task EditarDocenteExistente()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Docentes.Add(new Docente()
            {
                DocenteId = 1,
                Nombres = "Percy Alessandro",
                Apellidos = "Zamora P",
                DNI = "54545454",
                Domicilio = "Av. Pasto 22",
                Correo = "pepi@hotmail.com",
                Disponibilidad = "Disponible",
                Numero_cuenta = "5683218468",
                Membresia = "Premium"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            var docenteUpdateDTO = new DocenteUpdateDto()
            {
                Nombres = "Moises Jesus",
                Apellidos = "Jerusalen Santo",
                DNI = "98989894",
                Domicilio = "Av. Virgen 293",
                Correo = "padrenuestro@hotmail.com",
                Disponibilidad = "Disponible",
                Numero_cuenta = "5683218468",
                Membresia = "Premium"
            };

            //Prueba

            int id = 1;
            var controller = new DocenteServiceImpl(context2, mapper);

            await controller.Update(id, docenteUpdateDTO);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Docentes.AnyAsync(x => x.Nombres == "Moises Jesus");
            Assert.IsTrue(existe);
        }
        [TestMethod]
        public async Task BorrarDocente()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Docentes.Add(new Docente()
            {
                DocenteId = 1,
                Nombres = "Percy Alessandro",
                Apellidos = "Zamora P",
                DNI = "54545454",
                Domicilio = "Av. Pasto 22",
                Correo = "pepi@hotmail.com",
                Disponibilidad = "Disponible",
                Numero_cuenta = "5683218468",
                Membresia = "Premium"
            });
            await context.SaveChangesAsync();

            //Prueba

            var context2 = ConstruirContext(nombreDB);
            var controller = new DocenteServiceImpl(context2, mapper);

            await controller.Remove(1);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Docentes.AnyAsync();
            Assert.IsFalse(existe);
        }
        [TestMethod]
        public async Task DocenteExiste()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Docentes.Add(new Docente()
            {
                DocenteId = 1,
                Nombres = "Percy Alessandro",
                Apellidos = "Zamora P",
                DNI = "54545454",
                Domicilio = "Av. Pasto 22",
                Correo = "pepi@hotmail.com",
                Disponibilidad = "Disponible",
                Numero_cuenta = "5683218468",
                Membresia = "Premium"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new DocenteServiceImpl(context2, mapper);

            var respuesta = controller.Existencia(id);

            //Verificación

            Assert.IsTrue(respuesta);
        }
        [TestMethod]
        public void DocenteNoExiste()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            //Prueba

            int id = 1;
            var controller = new DocenteServiceImpl(context, mapper);

            var respuesta = controller.Existencia(id);

            //Verificación

            Assert.IsFalse(respuesta);
        }
    }
}