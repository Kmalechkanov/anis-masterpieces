﻿namespace AnisMasterpieces.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.Controllers;
    using AnisMasterpieces.Web.ViewModels.Items;
    using AnisMasterpieces.Web.ViewModels.Tabs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class ItemsController : BaseController
    {
        private readonly IItemService itemService;
        private readonly ITabService tabService;

        public ItemsController(IItemService itemService, ITabService tabService)
        {
            this.itemService = itemService;
            this.tabService = tabService;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return this.View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Add(string id)
        {
            var tabs = this.tabService.GetAll<TabIdNameViewModel>();
            var viewModel = new ItemAddInputModel
            {
                TabId = id,
                Tabs = tabs,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Add(ItemAddInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var tabs = this.tabService.GetAll<TabIdNameViewModel>();
                input.Tabs = tabs;
                return this.View(input);
            }

            var itemId = await this.itemService.AddAsync(input.Name, input.ImageUrl, input.Price, input.TabId, input.Description);
            return this.RedirectToAction("Id", "Items", new { area = string.Empty, Id = itemId });
        }
    }
}