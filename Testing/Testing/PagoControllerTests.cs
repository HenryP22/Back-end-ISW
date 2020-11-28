using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutoFinder.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Testing;
using TutoFinder.Entity;
using TutoFinder.Service.Impl;
using TutoFinder.Dto;
using Microsoft.EntityFrameworkCore;

namespace Testing.Testing
{
    [TestClass()]
    public class PagoControllerTests : BasePruebas
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task GetAllTestAsync()
        {

            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Pagos.Add(new Pago()
            {
                PagoId = 1,
                TarjetaId = 1,
                TutoriaId = 1,
                Descripcion = "Pago por tutoria de progra 1",
                CvcTarjeta = "881"
            });

            context.Pagos.Add(new Pago()
            {
                PagoId = 2,
                TarjetaId = 1,
                TutoriaId = 2,
                Descripcion = "Pago por tutoria de algoritmos",
                CvcTarjeta = "881"
            });


            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);


            //Prueba
            //var controller = new AlumnoServiceImpl(context2, mapper);
            var controller = new PagoServiceImpl(context2, mapper);

            var respuesta = await controller.GetAll(1, 5);

            //Verificación
            var Pagos = respuesta.Total;
            Assert.AreEqual(2, Pagos);
        }

        [TestMethod()]
        public async System.Threading.Tasks.Task GetByIdTestAsync()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Pagos.Add(new Pago()
            {
                PagoId = 1,
                TarjetaId = 1,
                TutoriaId = 1,
                Descripcion = "Pago por tutoria de progra 1",
                CvcTarjeta = "881"
            });
            context.Tarjetas.Add(new Tarjeta()
            {
                TarjetaId = 1,
                Numero_tarjeta = "48934993093",
                Nombre_poseedor = "Juanelv",
                Fecha_expiracion = "2020-01-01"
            });

            context.Padres.Add(new Padre()
            {
                PadreId = 1,
                Nombres = "Padre",
                Apellidos = "Apellido del Padre",
                DNI = "932123123",
                Correo = "adasd@glaskdl.com",
                Alumnos = null
            });
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
            context.Cursos.Add(new Curso()
            {
                CursoId = 1,
                Nombre = "Aplicaciones Web",
                Descripcion = "ez",
                Grado_academico = "Primaria"
            });
            context.Docentes.Add(new Docente()
            {
                DocenteId = 1,
                Nombres = "Inocencio",
                Apellidos = "Jirafales",
                DNI = "3913931",
                Domicilio = "Aqui nomas",
                Correo = "mail@mail.com",
                Disponibilidad = "Inmediata",
                Numero_cuenta = "12349543",
                Membresia = "GOLD"
            });

            context.Tutorias.Add(new Tutoria()
            {
                TutoriaId = 1,
                AlumnoId = 1,
                CursoId = 1,
                DocenteId = 1,
                Costo = 20.00,
                Descripcion = "Servicio de tutoria de Open Source",
                Cantidad_minutos = 30
            });


            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new PagoServiceImpl(context2, mapper);

            var respuesta = await controller.GetById(id);

            //Verificación

            var Pagos = respuesta.PagoId;
            Assert.AreEqual(id, Pagos);
        }

        [TestMethod()]
        public async System.Threading.Tasks.Task CreateTestAsync()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();


            var pagoDto = new PagoCreateDto()
            {
                CvcTarjeta = "843",
                Descripcion = "Pago por tutoria",
                TarjetaId = 1,
                TutoriaId = 1
            };

            context.Tarjetas.Add(new Tarjeta()
            {
                TarjetaId = 1,
                Numero_tarjeta = "48934993093",
                Nombre_poseedor = "Juanelv",
                Fecha_expiracion = "2020-01-01"
            });

            context.Padres.Add(new Padre()
            {
                PadreId = 1,
                Nombres = "Padre",
                Apellidos = "Apellido del Padre",
                DNI = "932123123",
                Correo = "adasd@glaskdl.com",
                Alumnos = null
            });

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
            context.Cursos.Add(new Curso()
            {
                CursoId = 1,
                Nombre = "Aplicaciones Web",
                Descripcion = "ez",
                Grado_academico = "Primaria"
            });
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

            context.Tutorias.Add(new Tutoria()
            {
                TutoriaId = 1,
                AlumnoId = 1,
                CursoId = 1,
                DocenteId = 1,
                Costo = 20.00,
                Descripcion = "Servicio de tutoria de Open Source",
                Cantidad_minutos = 30
            });
            //Prueba
            await context.SaveChangesAsync();
            var controller = new PagoServiceImpl(context, mapper);

            await controller.Create(pagoDto);

            //Verificación

            var context2 = ConstruirContext(nombreDB);
            var cantidad = await context2.Pagos.CountAsync();
            Assert.AreEqual(1, cantidad);
        }

        [TestMethod()]
        public async System.Threading.Tasks.Task UpdateTestAsync()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();


            context.Pagos.Add(new Pago()
            {
                PagoId = 1,
                TarjetaId = 1,
                TutoriaId = 1,
                Descripcion = "Pago por tutoria de progra 1",
                CvcTarjeta = "881"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            var cursoUpdateDTO = new CursoUpdateDto() { Nombre = "Open Source", Descripcion = "ez", Grado_academico = "Secundaria" };
            var pagoUpdateDto = new PagoUpdateDto()
            {
                CvcTarjeta = "321"
            };

            //Prueba

            int id = 1;
            var controller = new PagoServiceImpl(context2, mapper);

            await controller.Update(id, pagoUpdateDto);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Pagos.AnyAsync(x => x.CvcTarjeta == "321");
            Assert.IsTrue(existe);
        }

    
    }
}