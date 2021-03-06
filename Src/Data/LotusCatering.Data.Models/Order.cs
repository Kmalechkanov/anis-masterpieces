﻿namespace LotusCatering.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PaymentDate = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public double TotalPrice { get; set; }

        public string AdditionalInformation { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
            = new HashSet<OrderItem>();
    }
}
