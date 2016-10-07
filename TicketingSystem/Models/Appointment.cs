using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public String Email { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public String Time { get; set; }

    }
}