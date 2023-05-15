using AppWebMVCRest.Models;
using AppWebMVCRest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebMVCRest.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            EmpleadoServiceClient esc = new EmpleadoServiceClient();
            ViewBag.listEmpleados = esc.readAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("create");
        }

        [HttpPost]
        public ActionResult Create(EmpleadoViewModel evm)
        {
            EmpleadoServiceClient esc = new EmpleadoServiceClient();
            esc.create(evm.Empleado);
            return RedirectToAction("index");
        }

        public ActionResult Delete(string id)
        {
            EmpleadoServiceClient esc = new EmpleadoServiceClient();
            esc.delete(esc.find(id));
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            EmpleadoServiceClient esc = new EmpleadoServiceClient();
            EmpleadoViewModel evm = new EmpleadoViewModel();
            evm.Empleado = esc.find(id);
            return View("Edit", evm);
        }

        [HttpPost]
        public ActionResult Edit(EmpleadoViewModel evm)
        {
            EmpleadoServiceClient esc = new EmpleadoServiceClient();
            esc.edit(evm.Empleado);
            return RedirectToAction("index");
        }
    }
}