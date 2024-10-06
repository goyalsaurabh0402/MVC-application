using Microsoft.AspNetCore.Mvc;
using MVC_application.Models;

namespace MVC_application.Controllers
{
    public class EquipmentController : Controller
    {
        private static List<EquipmentRequest> _requests = new List<EquipmentRequest>();
        private static int _currentId = 1;

        // Displays the request form
        [HttpGet]
        public IActionResult RequestForm()
        {
            return View(new EquipmentRequest());
        }

        // Processes the submitted form
        [HttpPost]
        public IActionResult SubmitRequest(EquipmentRequest request)
        {
            if (ModelState.IsValid)
            {
                request.Id = _currentId++;
                _requests.Add(request);
                return RedirectToAction("Confirmation");
            }
            return View("RequestForm", request); // Redisplay the form with validation errors
        }

        // Confirmation page after successful submission
        public IActionResult Confirmation()
        {
            return View(); // This will render the Confirmation.cshtml view
        }
        public IActionResult AllEquipment()
{
    var equipmentList = new List<Equipment>
    {
        new Equipment { Id = 1, Type = "Laptop", Description = "Dell XPS 13", Available = true },
        new Equipment { Id = 2, Type = "Phone", Description = "iPhone 12", Available = false },
        new Equipment { Id = 3, Type = "Tablet", Description = "iPad Pro", Available = true }
    };

    return View(equipmentList);
}
    public IActionResult AvailableEquipment()
{
    var equipmentList = new List<Equipment>
    {
        new Equipment { Id = 1, Type = "Laptop", Description = "Dell XPS 13", Available = true },
        new Equipment { Id = 3, Type = "Tablet", Description = "iPad Pro", Available = true }
    };

    // Filter only available equipment
    var availableEquipment = equipmentList.Where(e => e.Available).ToList();

    return View(availableEquipment);
}

    }
}
