using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebZazalogic.Models.DAO;
using WebZazalogic.Models.ViewModels;

namespace WebZazalogic.Controllers
{
    public class HomeController : Controller
    {
        AtencionCliente _oAtencionCliente = new AtencionCliente();
        List<AtencionCliente> _oAtencionClientes = new List<AtencionCliente>();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string GetAllAtencionCliente(AtencionCliente atencionCliente)
        {
            DAOAtencionCliente AC = new DAOAtencionCliente();

            _oAtencionClientes = AC.InsertInput(atencionCliente);

            var Json = JsonConvert.SerializeObject(_oAtencionClientes);

            return Json;
        }

        [HttpPost]
        public string PostAtencionClientes(AtencionCliente atencionCliente)
        {
            _oAtencionCliente = new AtencionCliente();

            string resulstring = "Insert Into [zasylogicDB].[dbo].[AtencionClientes] ([Nombre],[Apellidos],[Celular],[Email],[Sexo],[Motivo]) ";
            resulstring += String.Format("Values ({0},{1},{2},{3},{4},{5})",
                                         atencionCliente.Nombre, 
                                         atencionCliente.Apellidos, 
                                         atencionCliente.Celular,
                                         atencionCliente.Email,
                                         atencionCliente.Sexo,
                                         atencionCliente.Motivo);

            DAOAtencionCliente AC = new DAOAtencionCliente();

            var resultbool = AC.ValidationInput(atencionCliente);
            if (!resultbool)
            {
                resulstring = "";
            }

            return resulstring;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}