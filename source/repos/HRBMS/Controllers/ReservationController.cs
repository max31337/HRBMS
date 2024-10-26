using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HRBMS.Models; // Ensure this is the correct namespace for your models
using Microsoft.EntityFrameworkCore; // Required for DbContext

public class ReservationController : Controller
{
    private readonly ApplicationDbContext _context;

    // Constructor with dependency injection
    public ReservationController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Fetch reservations for FullCalendar using AJAX
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

        return Json(reservations); // No JsonRequestBehavior in ASP.NET Core
    }

    // Display the reservation form
    public IActionResult Create() // Use IActionResult in ASP.NET Core
    {
        return View();
    }

    // Create a new reservation (POST)
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

    // Dispose the context to release resources (not necessary with DI)
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose(); // This line may not be needed with dependency injection
        }
        base.Dispose(disposing);
    }
}
