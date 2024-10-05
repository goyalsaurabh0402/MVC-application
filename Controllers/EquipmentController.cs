public class EquipmentController : Controller
{
    private static List<EquipmentRequest> _requests = new List<EquipmentRequest>();
    private static int _currentId = 1;

    [HttpGet]
    public IActionResult RequestForm()
    {
        return View(new EquipmentRequest());
    }

    [HttpPost]
    public IActionResult SubmitRequest(EquipmentRequest request)
    {
        if (ModelState.IsValid)
        {
            request.Id = _currentId++;
            _requests.Add(request);
            return RedirectToAction("Confirmation");
        }
        return View("RequestForm", request);
    }

    public IActionResult Confirmation()
    {
        return View("Confirmation", "Your request has been submitted. Someone from IT will be in touch soon.");
    }
}
