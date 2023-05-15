using ServicioWCFRest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioWCFRest
{

    public class ServicioEmpleado : IServicioEmpleado
    {
        public bool create(Empleado empleado)
        {
            using (NeptunoEntities db = new NeptunoEntities())
            {
                try
                {
                    EmpleadoEntity emp = new EmpleadoEntity();
                    emp.Apellidos = empleado.Apellidos;
                    emp.Nombre = empleado.Nombre;
                    emp.Cargo = empleado.Cargo;
                    emp.Dirección = empleado.Direccion;
                    db.EmpleadoEntity.Add(emp);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception )
                {
                    return false;
                }
            }
        }//

        public bool delete(Empleado empleado)
        {
            using (NeptunoEntities db = new NeptunoEntities())
            {
                try
                {
                    int cod = Convert.ToInt32(empleado.IdEmpleado);
                    EmpleadoEntity emp = db.EmpleadoEntity.Single(em => em.IdEmpleado == cod);
                    db.EmpleadoEntity.Remove(emp);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }//

        public bool edit(Empleado empleado)
        {
            using (NeptunoEntities db = new NeptunoEntities())
            {
                try
                {
                    int cod = Convert.ToInt32(empleado.IdEmpleado);
                    EmpleadoEntity emp = db.EmpleadoEntity.Single(em => em.IdEmpleado == cod);
                    emp.Apellidos = empleado.Apellidos;
                    emp.Nombre = empleado.Nombre;
                    emp.Cargo = empleado.Cargo;
                    emp.Dirección = empleado.Direccion;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }//

        public Empleado find(string id)
        {
            using (NeptunoEntities db = new NeptunoEntities())
            {
                int cod = Convert.ToInt32(id);
                return db.EmpleadoEntity.Where(em => em.IdEmpleado == cod).Select(em => new Empleado
                {
                    IdEmpleado = em.IdEmpleado,
                    Apellidos = em.Apellidos,
                    Nombre = em.Nombre,
                    Cargo = em.Cargo,
                    Direccion = em.Dirección
                }).First();
            }
        }//

        public List<Empleado> readAll()
        {
            using (NeptunoEntities db = new NeptunoEntities())
            {
                return db.EmpleadoEntity.Select(em => new Empleado
                {
                    IdEmpleado = em.IdEmpleado,
                    Apellidos = em.Apellidos,
                    Nombre = em.Nombre,
                    Cargo = em.Cargo,
                    Direccion = em.Dirección
                }).ToList();
            }
        }//

    }
}
