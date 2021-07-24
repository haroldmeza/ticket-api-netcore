using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ticket_new.Models
{
    public class Ticket
    {
        public long Id { get; set; }
        [Required]
        public String Usuario { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; }
        public Estatus Estatus { get; set; } = Estatus.abierto;
    }
}
