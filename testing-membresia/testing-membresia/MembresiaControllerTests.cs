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
    public class MembresiaControllerTests : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerTodasLasMembresias()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Membresias.Add(new Membresia
            {
                Cvc_tarjeta = "123",
                Fecha_expiracion = "12-12-20",
                Tarjeta = new Tarjeta
                {
                    Fecha_expiracion = "12-12-30",
                    Nombre_poseedor = "Juan Alba Silva",
                    Numero_tarjeta = "756567765567"
                },
                Docente = new Docente
                {
                    Nombres = "Jorge",
                    Apellidos = "Mesa",
                    DNI = "3423112342",
                    Domicilio = "Av. avenida nro1 ",
                    Correo = "josemesa@gmai.com",
                    Disponibilidad = "disponible",
                    Numero_cuenta = "2345324234",
                    Membresia = "membresia",
                },
            });


            context.SaveChanges();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            var controller = new MembresiaServiceImpl(context2, mapper);

            var respuesta = await controller.GetAll(1, 5);

            //Verificación

            var membresias = respuesta.Total;
            Assert.AreEqual(1, membresias);
        }
        [TestMethod]
        public async Task ObtenerMembresiaPorId()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Membresias.Add(new Membresia
            {
                Cvc_tarjeta = "123",
                Fecha_expiracion = "12-12-20",
                Tarjeta = new Tarjeta
                {
                    Fecha_expiracion = "12-12-30",
                    Nombre_poseedor = "Juan Alba Silva",
                    Numero_tarjeta = "756567765567"
                },
                Docente = new Docente
                {
                    Nombres = "Jorge",
                    Apellidos = "Mesa",
                    DNI = "3423112342",
                    Domicilio = "Av. avenida nro1 ",
                    Correo = "josemesa@gmai.com",
                    Disponibilidad = "disponible",
                    Numero_cuenta = "2345324234",
                    Membresia = "membresia",
                },
            });

            context.SaveChanges();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new MembresiaServiceImpl(context2, mapper);

            var respuesta = await controller.GetById(id);

            //Verificación

            var membresia = respuesta.MembresiaId;
            Assert.AreEqual(id, membresia);
        }
        [TestMethod]
        public async Task CrearMembresia()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();
            context.Docentes.Add(new Docente
            {
                Nombres = "Jorge",
                Apellidos = "Mesa",
                DNI = "3423112342",
                Domicilio = "Av. avenida nro1 ",
                Correo = "josemesa@gmai.com",
                Disponibilidad = "disponible",
                Numero_cuenta = "2345324234",
                Membresia = "membresia",
            });
            context.Tarjetas.Add(new Tarjeta
            {
                Fecha_expiracion = "12-12-30",
                Nombre_poseedor = "Juan Alba Silva",
                Numero_tarjeta = "756567765567"
            });
            context.SaveChanges();
            var membresiaCreateDTO = new MembresiaCreateDto() {TarjetaId=1,Cvc_tarjeta="123",Fecha_expiracion="20-12-25",DocenteId=1 };

            //Prueba

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

            context.Membresias.Add(new Membresia
            {
                Cvc_tarjeta = "123",
                Fecha_expiracion = "12-12-20",
                Tarjeta = new Tarjeta
                {
                    Fecha_expiracion = "12-12-30",
                    Nombre_poseedor = "Juan Alba Silva",
                    Numero_tarjeta = "756567765567"
                },
                Docente = new Docente
                {
                    Nombres = "Jorge",
                    Apellidos = "Mesa",
                    DNI = "3423112342",
                    Domicilio = "Av. avenida nro1 ",
                    Correo = "josemesa@gmai.com",
                    Disponibilidad = "disponible",
                    Numero_cuenta = "2345324234",
                    Membresia = "membresia",
                },
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            var cursoUpdateDTO = new MembresiaUpdateDto() {Cvc_tarjeta="333",DocenteId=1,Fecha_expiracion="12-12-28",MembresiaId=1,TarjetaId=1};

            //Prueba

            int id = 1;
            var controller = new MembresiaServiceImpl(context2, mapper);

            await controller.Update(id, cursoUpdateDTO);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Membresias.AnyAsync(x => x.Cvc_tarjeta == "333");
            Assert.IsTrue(existe);
        }
        [TestMethod]
        public async Task BorrarMembresia()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Membresias.Add(new Membresia
            {
                Cvc_tarjeta = "123",
                Fecha_expiracion = "12-12-20",
                Tarjeta = new Tarjeta
                {
                    Fecha_expiracion = "12-12-30",
                    Nombre_poseedor = "Juan Alba Silva",
                    Numero_tarjeta = "756567765567"
                },
                Docente = new Docente
                {
                    Nombres = "Jorge",
                    Apellidos = "Mesa",
                    DNI = "3423112342",
                    Domicilio = "Av. avenida nro1 ",
                    Correo = "josemesa@gmai.com",
                    Disponibilidad = "disponible",
                    Numero_cuenta = "2345324234",
                    Membresia = "membresia",
                },
            });
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
    }

}
