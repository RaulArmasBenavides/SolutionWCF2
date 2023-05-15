using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace AppWebMVCRest.Models
{
    public class EmpleadoServiceClient
    {
        private string BASE_URL = "http://localhost:60938/ServicioEmpleado.svc/";

        public List<Empleado> readAll()
        {
            try
            {
                var webclient = new WebClient();
                var json = webclient.DownloadString(BASE_URL+"readall");
                var js=new JavaScriptSerializer();
                return js.Deserialize<List<Empleado>>(json);
            }
            catch (Exception)
            {
                return null; 
            }
        }//

        public Empleado find(string id)
        {
            try
            {
                var webclient = new WebClient();
                var url = string.Format(BASE_URL+"find/{0}",id);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Empleado>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }//

        public bool create(Empleado empleado)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof (Empleado));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem,empleado);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "Application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL+"create","POST",data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }//

        public bool edit(Empleado empleado)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Empleado));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, empleado);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "Application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "edit", "PUT", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }//

        public bool delete(Empleado empleado)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Empleado));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, empleado);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "Application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "delete", "DELETE", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }//

    }
}