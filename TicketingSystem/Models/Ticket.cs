using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public String Email { get; set; }
        public String Subject { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Queued = 1,
        Open,
        Resolved
    }
}