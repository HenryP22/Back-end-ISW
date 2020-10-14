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
    public class InformeControllerTests : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerTodosLosInformes()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Informes.Add(new Informe{
                Tutoria = new Tutoria{
                    Alumno = new Alumno {
                        Nombres = "Jose",
                        Apellidos = "Silva",
                        DNI = "72459012",
                        Grado_academico = "grado",
                        Correo = "josesilva@gmail.com",
                        Padre = new Padre{
                            Nombres = "Carlos",
                            Apellidos = "Silva",
                            DNI = "242342",
                            Correo = "CArlogsilva@gamil.com",
                        }
                    },
                    Curso = new Curso {
                        Nombre = "Algebra",
                        Descripcion = "",
                        Grado_academico = ""
                    },
                    Docente = new Docente{
                        Nombres = "Jorge",
                        Apellidos = "Mesa",
                        DNI = "3423112342",
                        Domicilio = "Av. avenida nro1 ",
                        Correo = "josemesa@gmai.com",
                        Disponibilidad = "disponible",
                        Numero_cuenta = "2345324234",
                        Membresia = "membresia",
                    },
                    Costo = 120.0,
                    Descripcion = "",
                    Cantidad_minutos = 120
                },
                Descripcion = "tiene errores",
                Fecha = "20/12/2020"
            });
            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            var controller = new InformeServiceImpl(context2, mapper);

            var respuesta = await controller.GetAll(1, 5);

            //Verificación

            var informes = respuesta.Total;
            Assert.AreEqual(1, informes);
        }
        [TestMethod]
        public async Task ObtenerInformePorId()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Informes.Add(new Informe
            {
                Tutoria = new Tutoria
                {
                    Alumno = new Alumno
                    {
                        Nombres = "Jose",
                        Apellidos = "Silva",
                        DNI = "72459012",
                        Grado_academico = "grado",
                        Correo = "josesilva@gmail.com",
                        Padre = new Padre
                        {
                            Nombres = "Carlos",
                            Apellidos = "Silva",
                            DNI = "242342",
                            Correo = "CArlogsilva@gamil.com",
                        }
                    },
                    Curso = new Curso
                    {
                        Nombre = "Algebra",
                        Descripcion = "",
                        Grado_academico = ""
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
                    Costo = 120.0,
                    Descripcion = "",
                    Cantidad_minutos = 120
                },
                Descripcion = "tiene errores",
                Fecha = "20/12/2020"
            });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);

            //Prueba

            int id = 1;
            var controller = new InformeServiceImpl(context2, mapper);

            var respuesta = await controller.GetById(id);

            //Verificación

            var informeid = respuesta.InformeId;
            Assert.AreEqual(id, informeid);
        }
        [TestMethod]
        public async Task CrearInforme()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();
            context.Tutorias.Add(new Tutoria
            {
                Alumno = new Alumno
                {
                    Nombres = "Jose",
                    Apellidos = "Silva",
                    DNI = "72459012",
                    Grado_academico = "grado",
                    Correo = "josesilva@gmail.com",
                    Padre = new Padre
                    {
                        Nombres = "Carlos",
                        Apellidos = "Silva",
                        DNI = "242342",
                        Correo = "CArlogsilva@gamil.com",
                    }
                },
                Curso = new Curso
                {
                    Nombre = "Algebra",
                    Descripcion = "",
                    Grado_academico = ""
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
                Costo = 120.0,
                Descripcion = "",
                Cantidad_minutos = 120
            });
            context.SaveChanges();

            var informeCreateDTO = new InformeCreateDto() { TutoriaId=1,Descripcion="mensaje",Fecha="12-12-12"};

            //Prueba

            int id = 1;
            var controller = new InformeServiceImpl(context, mapper);

            await controller.Create(informeCreateDTO);

            //Verificación

            var context2 = ConstruirContext(nombreDB);
            var cantidad = await context2.Informes.CountAsync();
            Assert.AreEqual(1, cantidad);
        }
        [TestMethod]
        public async Task EditarInformeExistente()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Informes.Add(new Informe
            {
                Tutoria = new Tutoria
                {
                    Alumno = new Alumno
                    {
                        Nombres = "Jose",
                        Apellidos = "Silva",
                        DNI = "72459012",
                        Grado_academico = "grado",
                        Correo = "josesilva@gmail.com",
                        Padre = new Padre
                        {
                            Nombres = "Carlos",
                            Apellidos = "Silva",
                            DNI = "242342",
                            Correo = "CArlogsilva@gamil.com",
                        }
                    },
                    Curso = new Curso
                    {
                        Nombre = "Algebra",
                        Descripcion = "",
                        Grado_academico = ""
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
                    Costo = 120.0,
                    Descripcion = "",
                    Cantidad_minutos = 120
                },
                Descripcion = "tiene errores",
                Fecha = "20/12/2020"
            });

            context.SaveChanges();

            var context2 = ConstruirContext(nombreDB);

            var informeUpdateDTO = new InformeUpdateDto() { TutoriaId = 1, Descripcion = "mensaje", Fecha = "12-12-12" };

            //Prueba

            int id = 1;
            var controller = new InformeServiceImpl(context2, mapper);

            await controller.Update(id, informeUpdateDTO);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Informes.AnyAsync(x => x.Descripcion == "mensaje");
            Assert.IsTrue(existe);
        }
        [TestMethod]
        public async Task BorrarInforme()
        {
            //Preparación

            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Informes.Add(new Informe
            {
                Tutoria = new Tutoria
                {
                    Alumno = new Alumno
                    {
                        Nombres = "Jose",
                        Apellidos = "Silva",
                        DNI = "72459012",
                        Grado_academico = "grado",
                        Correo = "josesilva@gmail.com",
                        Padre = new Padre
                        {
                            Nombres = "Carlos",
                            Apellidos = "Silva",
                            DNI = "242342",
                            Correo = "CArlogsilva@gamil.com",
                        }
                    },
                    Curso = new Curso
                    {
                        Nombre = "Algebra",
                        Descripcion = "",
                        Grado_academico = ""
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
                    Costo = 120.0,
                    Descripcion = "",
                    Cantidad_minutos = 120
                },
                Descripcion = "tiene errores",
                Fecha = "20/12/2020"
            });
            context.SaveChanges();

            //Prueba

            var context2 = ConstruirContext(nombreDB);
            var controller = new InformeServiceImpl(context2, mapper);

            await controller.Remove(1);

            //Verificación

            var context3 = ConstruirContext(nombreDB);
            var existe = await context3.Informes.AnyAsync();
            Assert.IsFalse(existe);
        }
    }

}
