using HR_Tech.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace HR_Tech.Data {
    public class DbInitializer {
        public static void Initialize(HRContextDB context) {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Usuarios.Any()) {
                return;   // DB has been seeded
            }

            var usuarios = new Usuarios[]
            {
            new() {Nombre="Luis", Apellido="Sandoval", Departamento="Recursos Humanos", Puesto="Jefe", Usuario="lsandoval", Password="12345"},
            new() {Nombre="Erik", Apellido="Cerecero", Departamento="Recursos Humanos", Puesto="Aprobador", Usuario="ecerecero", Password="12345"},
            new() {Nombre="Axel", Apellido="Mendoza", Departamento="Recursos Humanos", Puesto="Aprobador", Usuario="amendoza", Password="12345"},
            };
            foreach (Usuarios s in usuarios) {
                context.Usuarios.Add(s);
            }
            context.SaveChanges();

            var empleados = new Empleados[]
            {
            new() {Nombre="Enrique", Apellido="Sandoval", Departamento="Produccion", Puesto="Operario", DiasDeVacaciones=12},
            new() {Nombre="Humberto", Apellido="Cerecero", Departamento="Produccion", Puesto="Operario", DiasDeVacaciones=6},
            new() {Nombre="Jackson", Apellido="Mendoza", Departamento="Produccion", Puesto="Operario", DiasDeVacaciones=10},
            };
            foreach (Empleados c in empleados) {
                context.Empleados.Add(c);
            }
            context.SaveChanges();

            var solicitud = new Solicitud[]
            {
            new() {Descripcion="Solicitud de vacaciones", DiasSolicitados=4, IdEmpleado=1, FechaSolicitud=DateTime.Today},
            };
            foreach (Solicitud e in solicitud) {
                context.Solicitud.Add(e);
            }
            context.SaveChanges();
        }
    }
}
