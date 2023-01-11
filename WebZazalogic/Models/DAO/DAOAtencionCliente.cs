using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using WebZazalogic.Models.ViewModels;

namespace WebZazalogic.Models.DAO
{
    public class DAOAtencionCliente
    {
        public List<AtencionCliente> ListDummysData()
        {
          

            List<AtencionCliente> Datadummy = new List<AtencionCliente>
            {
                    new AtencionCliente { AtencionClienteId = 1, Nombre = "Livier", Apellidos = "Torres", Celular ="3013720573", Email = "livier.torres@zasylogic.com", Sexo ="Hombre", Motivo="Queja", Fecha_Alta= DateTime.Now.AddDays(2).Date },
                    new AtencionCliente { AtencionClienteId = 2, Nombre = "Liz", Apellidos = "Montalvo", Celular ="3010000005", Email = "liz.montalvo@zasylogic.com", Sexo ="Mujer", Motivo="Reclamacion", Fecha_Alta= DateTime.Now.AddDays(1).Date },
                    new AtencionCliente { AtencionClienteId = 3, Nombre = "Alexandra", Apellidos = "Viuch", Celular = "902 107 496", Email = "alexandra.viuch@zasylogic.com", Sexo ="Mujer", Motivo="Sugerencia", Fecha_Alta= DateTime.Now }
                };


            return Datadummy;

        }

        public bool ValidationInput(AtencionCliente Input)
        {
            var result = true;
            List<AtencionCliente> Datadummy = ListDummysData();

           var dataCheck=  Datadummy.Where(x => x.Celular == Input.Celular)
                     .Where(x => x.Motivo.Contains("Q") || x.Motivo.Contains("R"))
                     .Where(x => x.Fecha_Alta.Date == DateTime.Now.Date).ToList();

            if (dataCheck.Count > 0)
            {
                result = false;
            }



            return result;
        }

        public List<AtencionCliente> InsertInput(AtencionCliente Input)
        {
            
            List<AtencionCliente> Datadummy = ListDummysData();
            Input.Sexo = (Input.Sexo == "M") ? "Hombre" : "Mujer";
           
            switch (Input.Motivo)
            {
                case "I":
                    Input.Motivo = "Incidencia";
                    break;
                case "Q":
                    Input.Motivo = "Queja";
                    break;
                case "R":
                    Input.Motivo = "Reclamación";
                    break;
                default:
                    Input.Motivo = "Sugerencia";
                    break;
            }

            if (Input.Celular != "") 
                Datadummy.Add(Input);

            return Datadummy;
        }

    }
}