﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InterviewTest.Models;

namespace InterviewTest.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FakeDb _db;

        // To prevent you having to deal with an actual database we'll just be using a Dependency Injected fake database.
        public HomeController(ILogger<HomeController> logger, FakeDb db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Results(int currentPage=1)
        {
            var pageLimit = 10;
            var contacts = _db.Contacts.Skip(pageLimit * (currentPage - 1)).Take(pageLimit);

            return View(contacts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
