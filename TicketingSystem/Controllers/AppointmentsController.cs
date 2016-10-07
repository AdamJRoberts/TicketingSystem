using System.Linq;
using System.Web.Mvc;
using TicketingSystem.Models;

using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class AppointmentsController : Controller
    {
        private ApplicationDbContext _dbContext;
        public AppointmentsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Appointments

        public ActionResult Index()
        {
            var appointments = _dbContext.Appointments.ToList();

            return View(appointments);
        }
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Add(Appointment appointment)
        {
            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var appointment = _dbContext.Appointments.SingleOrDefault(v => v.Id == id);

            if (appointment == null)
                return HttpNotFound();

            return View(appointment);
        }
        [HttpPost]
        public ActionResult Update(Appointment appointment)
        {
            var appointmentInDb = _dbContext.Appointments.SingleOrDefault(v => v.Id == appointment.Id);

            if (appointmentInDb == null)
                return HttpNotFound();

            appointmentInDb.Email = appointment.Email;
            appointmentInDb.Date = appointment.Date;
            appointmentInDb.Time = appointment.Time;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var appointment = _dbContext.Appointments.SingleOrDefault(v => v.Id == id);

            if (appointment == null)
                return HttpNotFound();

            return View(appointment);
        }
        [HttpPost]
        public ActionResult DoDelete(int id)
        {
            var appointment = _dbContext.Appointments.SingleOrDefault(v => v.Id == id);
            if (appointment == null)
                return HttpNotFound();
            _dbContext.Appointments.Remove(appointment);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}