﻿namespace AnisMasterpieces.Web.ViewModels.Categories
{
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;

    public class CategoryIdNameViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
