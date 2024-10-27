using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HRBMS.Models;  
using Microsoft.EntityFrameworkCore; 
public class ReservationController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReservationController(ApplicationDbContext context)
    {
        _context = context;
    }

    public JsonResult GetReservations()
    {
        var reservations = _context.Reservations.Select(r => new
        {
            id = r.ReservationID,
            title = r.CustomerName,
            start = r.StartDate.ToString("yyyy-MM-ddTHH:mm:ss"),
            end = r.EndDate.ToString("yyyy-MM-ddTHH:mm:ss"),
            confirmed = r.IsConfirmed
        }).ToList();

        return Json(reservations); 
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Reservation reservation)
    {
        if (ModelState.IsValid)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        return View(reservation);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose(); 
        }
        base.Dispose(disposing);
    }
}
