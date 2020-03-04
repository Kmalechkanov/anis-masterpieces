﻿namespace AnisMasterpieces.Web.Controllers
{
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.ViewModels.Category;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Helpers;

    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly ITabService tabService;

        public CategoryController(ICategoryService categoryService, ITabService tabService)
        {
            this.categoryService = categoryService;
            this.tabService = tabService;
        }

        public IActionResult Index()
        {
            var categories = new CategoryCollectionOfIdAndNameViewModel()
            {
                Categories = categoryService.GetAll().ToArray()
            };

            return this.View(categories);
        }

        public IActionResult Specific(string id)
        {
            if (!categoryService.IsValidId(id))
            {
                return this.Redirect("/");
            }

            var tabs = new CategoryNameAndTabNameViewModel() {
                Id = id,
                Name = categoryService.GetNameById(id),
                Tabs = tabService.GetAllNamesByCategoryId(id).ToArray()
            };

            return this.View(tabs);
        }
    }
}