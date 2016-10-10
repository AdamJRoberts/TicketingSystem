using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using TicketingSystem.Models;

public class TicketsController : Controller
{
    private ApplicationDbContext _dbContext;

    public TicketsController()
    {
        _dbContext = new ApplicationDbContext();
    }

    // GET: Tickets
    public async Task<ActionResult> Index(string stringName)
    {
        var user = User.Identity.GetUserName();
        if (user.Equals(""))
        {
            return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Account/Login", action = "Home" })
            );
        }
        var tickets = from m in _dbContext.Tickets
                      select m;
        if (!string.IsNullOrEmpty(stringName))
        {
            tickets = tickets.Where(s => s.Email.Contains(stringName));
        }
        return View(await tickets.ToListAsync());
    }
    public ActionResult New()
    {
        return View();
    }
    public ActionResult Add(Ticket ticket)
    {
        _dbContext.Tickets.Add(ticket);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
        var ticket = _dbContext.Tickets.SingleOrDefault(v => v.Id == id);

        if (ticket == null)
            return HttpNotFound();

        return View(ticket);
    }
    [HttpPost]
    public ActionResult Update(Ticket ticket)
    {
        var ticketInDb = _dbContext.Tickets.SingleOrDefault(v => v.Id == ticket.Id);

        if (ticketInDb == null)
            return HttpNotFound();

        ticketInDb.Email = ticket.Email;
        ticketInDb.Date = ticket.Date;
        ticketInDb.Subject = ticket.Subject;
        ticketInDb.Status = ticket.Status;
        ticketInDb.Description = ticket.Description;
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
        var ticket = _dbContext.Tickets.SingleOrDefault(v => v.Id == id);

        if (ticket == null)
            return HttpNotFound();

        return View(ticket);
    }
    [HttpPost]
    public ActionResult DoDelete(int id)
    {
        var ticket = _dbContext.Tickets.SingleOrDefault(v => v.Id == id);
        if (ticket == null)
            return HttpNotFound();
        _dbContext.Tickets.Remove(ticket);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}