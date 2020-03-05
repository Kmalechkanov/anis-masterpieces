﻿namespace AnisMasterpieces.Web.Areas.Administration.Controllers
{
    using AnisMasterpieces.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administration")]
    public class TestController : BaseController
    {
        public TestController()
        {
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}