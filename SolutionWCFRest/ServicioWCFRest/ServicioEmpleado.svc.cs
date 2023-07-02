using GraphQL;
using GraphQL.Types;
using ServicioWCFRest.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioWCFRest
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
    ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ServicioEmpleado : IServicioEmpleado , IGraphQLService
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public ServicioEmpleado()
        {
            //_schema = schema;
            //_documentExecuter = new DocumentExecuter();
        }

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
                    db.Empleados.Add(emp);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception )
                {
                    return false;
                }
            }
        }

        public bool delete(Empleado empleado)
        {
            using (NeptunoEntities db = new NeptunoEntities())
            {
                try
                {
                    int cod = Convert.ToInt32(empleado.IdEmpleado);
                    EmpleadoEntity emp = db.Empleados.Single(em => em.IdEmpleado == cod);
                    db.Empleados.Remove(emp);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool edit(Empleado empleado)
        {
            using (NeptunoEntities db = new NeptunoEntities())
            {
                try
                {
                    int cod = Convert.ToInt32(empleado.IdEmpleado);
                    EmpleadoEntity emp = db.Empleados.Single(em => em.IdEmpleado == cod);
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
        }

        public Empleado find(string id)
        {
            using (NeptunoEntities db = new NeptunoEntities())
            {
                int cod = Convert.ToInt32(id);
                return db.Empleados.Where(em => em.IdEmpleado == cod).Select(em => new Empleado
                {
                    IdEmpleado = em.IdEmpleado,
                    Apellidos = em.Apellidos,
                    Nombre = em.Nombre,
                    Cargo = em.Cargo,
                    Direccion = em.Dirección
                }).First();
            }
        }

        public List<Empleado> readAll()
        {
            using (NeptunoEntities db = new NeptunoEntities())
            {
                return db.Empleados.Select(em => new Empleado
                {
                    IdEmpleado = em.IdEmpleado,
                    Apellidos = em.Apellidos,
                    Nombre = em.Nombre,
                    Cargo = em.Cargo,
                    Direccion = em.Dirección
                }).ToList();
            }
        }
        public Message ExecuteGraphQL(Message request)
        {
            return null;
        }
    }
}
