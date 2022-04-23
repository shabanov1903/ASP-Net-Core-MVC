using Lesson8.Models;
using Lesson8.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson8.Controllers
{
    public class OfficeController : Controller
    {
        private readonly ILogger<OfficeController> _logger;
        private readonly IData _data;

        public OfficeController(ILogger<OfficeController> logger, IData data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var data = _data.GetOffice(id);
            return View(data);
        }
    }
}