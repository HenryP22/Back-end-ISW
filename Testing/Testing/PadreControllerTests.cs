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
    public class PadreControllerTests : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerTodosLosPadres()
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
            context.Padres.Add(new Padre()
            {
                PadreId = 2,
                Nombres = "Henry",
                Apellidos = "Bustos",
                DNI = "75863340",
                Correo = "Moieses@hotmail.com"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            var controller = new PadreServiceImpl(context2, mapper);

            var respuesta = await controller.GetAll(1, 5);

            //Verificación

            var Padres = respuesta.Total;
            Assert.AreEqual(2, Padres);
        }
        [TestMethod]
        public async Task ObtenerPadrePorId()
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

            //Prueba

            int id = 1;
            var controller = new PadreServiceImpl(context2, mapper);

            var respuesta = await controller.GetById(id);

            //Verificación

            var Padres = respuesta.PadreId;
            Assert.AreEqual(id, Padres);
        }
        [TestMethod]
        public async Task CrearPadre()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var PadreCreateDTO = new PadreCreateDto() {
                Nombres = " Moises",
                Apellidos = "Cahuana",
                DNI = " 35826791",
                Correo = "Moieses@hotmail.com"
            };
            
            //Prueba

            var controller = new PadreServiceImpl(context, mapper);

            await controller.Create(PadreCreateDTO);

            //Verificación

            var context2 = ConstruirContext(nombreDB);
            var cantidad = await context2.Padres.CountAsync();
            Assert.AreEqual(1, cantidad);
        }
        [TestMethod]
        public async Task EditarPadreExistente()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Padres.Add(new Padre() { PadreId = 1,
                Nombres = " Moises",
                Apellidos = "Cahuana",
                DNI = " 35826791",
                Correo = "Moieses@hotmail.com"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            var PadreUpdateDTO = new PadreUpdateDto() {
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
        [TestMethod]
        public async Task BorrarPadre()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Padres.Add(new Padre() { PadreId = 1,
                Nombres = "Henry",
                Apellidos = "Bustos",
                DNI = "75863340",
                Correo = "Moieses@hotmail.com"
            });
            await context.SaveChangesAsync();

            //Prueba

            var context2 = ConstruirContext(nombreDB);
            var controller = new PadreServiceImpl(context2, mapper);

            await controller.Remove(1);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Padres.AnyAsync();
            Assert.IsFalse(existe);
        }
        [TestMethod]
        public async Task PadreExiste()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Padres.Add(new Padre() { PadreId = 1,
                Nombres = "Henry",
                Apellidos = "Bustos",
                DNI = "75863340",
                Correo = "Moieses@hotmail.com"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new PadreServiceImpl(context2, mapper);

            var respuesta = controller.Existencia(id);

            //Verificación

            Assert.IsTrue(respuesta);
        }
        [TestMethod]
        public void PadreNoExiste()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            //Prueba

            int id = 1;
            var controller = new PadreServiceImpl(context, mapper);

            var respuesta = controller.Existencia(id);

            //Verificación

            Assert.IsFalse(respuesta);
        }
    }
}
