﻿namespace AnisMasterpieces.Data.Models
{
    using AnisMasterpieces.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Category : IAuditInfo, IDeletableEntity
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]

        [MaxLength(150)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
