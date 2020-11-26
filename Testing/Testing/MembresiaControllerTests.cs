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
    public class MembresiaControllerTests : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerTodosLosMembresias()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Membresias.Add(new Membresia() { MembresiaId = 1, Cvc_tarjeta = "956", Fecha_expiracion = "22-05", TarjetaId = 1, DocenteId = 1 });
            context.Membresias.Add(new Membresia() { MembresiaId = 2, Cvc_tarjeta = "789", Fecha_expiracion = "22-07", TarjetaId = 2, DocenteId = 2 });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            var controller = new MembresiaServiceImpl(context2, mapper);

            var respuesta = await controller.GetAll(1, 5);

            //Verificación

            var membresias = respuesta.Total;
            Assert.AreEqual(2, membresias);
        }
        [TestMethod]
        public async Task ObtenerMembresiaPorId()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Membresias.Add(new Membresia() { MembresiaId = 1, Cvc_tarjeta = "956", Fecha_expiracion = "22-05", TarjetaId = 1, DocenteId = 1 });
            context.Membresias.Add(new Membresia() { MembresiaId = 2, Cvc_tarjeta = "789", Fecha_expiracion = "22-07", TarjetaId = 2, DocenteId = 2 });
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
                Membresia = "Activa"
            });
            context.Tarjetas.Add(new Tarjeta()
            {
                TarjetaId = 1,
                Fecha_expiracion = "20/02/2025",
                Nombre_poseedor = " Henry Papi",
                Numero_tarjeta = "255.255.255.0"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new MembresiaServiceImpl(context2, mapper);



            var respuesta = await controller.GetById(id);

            //Verificación

            var membresias = respuesta.MembresiaId;
            Assert.AreEqual(id, membresias);
        }
        [TestMethod]
        public async Task CrearMembresia()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var membresiaCreateDTO = new MembresiaCreateDto() { Cvc_tarjeta = "956", Fecha_expiracion = "22-05", TarjetaId = 1, DocenteId = 1 };
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
                Membresia = "Activa"
            });
            //Prueba
            await context.SaveChangesAsync();
            int id = 1;
            var controller = new MembresiaServiceImpl(context, mapper);

            await controller.Create(membresiaCreateDTO);

            //Verificación

            var context2 = ConstruirContext(nombreDB);
            var cantidad = await context2.Membresias.CountAsync();
            Assert.AreEqual(1, cantidad);
        }
        [TestMethod]
        public async Task EditarMembresiaExistente()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Membresias.Add(new Membresia() { MembresiaId = 1, Cvc_tarjeta = "956", Fecha_expiracion = "22-05", TarjetaId = 1, DocenteId = 1 });


            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            var membresiaUpdateDTO = new MembresiaUpdateDto() { MembresiaId = 1, Cvc_tarjeta = "499", Fecha_expiracion = "18-05", TarjetaId = 1, DocenteId = 1 };

            //Prueba

            int id = 1;
            var controller = new MembresiaServiceImpl(context2, mapper);

            await controller.Update(id, membresiaUpdateDTO);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Membresias.AnyAsync(x => x.Cvc_tarjeta == "499");
            Assert.IsTrue(existe);
        }
        [TestMethod]
        public async Task BorrarMembresia()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Membresias.Add(new Membresia() { MembresiaId = 1, Cvc_tarjeta = "956", Fecha_expiracion = "22-05", TarjetaId = 1, DocenteId = 1 });
            await context.SaveChangesAsync();

            //Prueba

            var context2 = ConstruirContext(nombreDB);
            var controller = new MembresiaServiceImpl(context2, mapper);

            await controller.Remove(1);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Membresias.AnyAsync();
            Assert.IsFalse(existe);
        }
        [TestMethod]
        public async Task MembresiaExiste()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Membresias.Add(new Membresia() { MembresiaId = 1, Cvc_tarjeta = "956", Fecha_expiracion = "22-05", TarjetaId = 1, DocenteId = 1 });
            context.Membresias.Add(new Membresia() { MembresiaId = 2, Cvc_tarjeta = "789", Fecha_expiracion = "22-07", TarjetaId = 2, DocenteId = 2 });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new MembresiaServiceImpl(context2, mapper);

            var respuesta = controller.Existencia(id);

            //Verificación

            Assert.IsTrue(respuesta);
        }
        [TestMethod]
        public async Task MembresiaNoExiste()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            //Prueba

            int id = 1;
            var controller = new MembresiaServiceImpl(context, mapper);

            var respuesta = controller.Existencia(id);

            //Verificación

            Assert.IsFalse(respuesta);
        }
    }
}
