using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebZazalogic.Models.ViewModels
{
    public class AtencionCliente
    {
        public int AtencionClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Motivo { get; set; }

        public DateTime Fecha_Alta { get; set; }
    }
}