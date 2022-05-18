using MailManager.Data.Entities;
using MailManager.Data.Interfaces;
using MailManager.Data.SQLServer;
using MailManager.WebApi.Jobs;
using MailManager.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Quartz;
using Nelibur.ObjectMapper;
using MailManager.WebApi.Services;

namespace MailManager.WebApi.Controllers
{
    public class MailController : Controller
    {
        private readonly ILogger<MailController> _logger;
        private readonly SQLServer _sqlserver;
        private readonly IScheduler _scheduler;

        public MailController(ILogger<MailController> logger,
                              SQLServer sqlserver,
                              IScheduler scheduler,
                              Mapper mapper)
        {
            _logger = logger;
            _sqlserver = sqlserver;
            _scheduler = scheduler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientDto clientDto)
        {
            if (!ModelState.IsValid) return Content("Введены неверные данные");
            var client = TinyMapper.Map<Client>(clientDto);
            await _sqlserver.Clients.AddAsync(client);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddNotice(NoticeDto noticeDto)
        {
            if (!ModelState.IsValid) return Content("Введены неверные данные");
            var notice = TinyMapper.Map<Notice>(noticeDto);
            await _sqlserver.Notices.AddAsync(notice);
            return RedirectToAction("Index");
        }

        public IActionResult SendMessages()
        {
            var key = new JobKey("MailKey", "MailGroup");
            _scheduler.TriggerJob(key);
            return RedirectToAction("Index");
        }
    }
}