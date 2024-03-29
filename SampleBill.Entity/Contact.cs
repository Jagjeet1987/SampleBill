﻿using System;
using System.Collections.Generic;

namespace SampleBill.Entity
{
    public class Contact : BaseEntity<Guid>
    {
        public Contact()
        {
            Bill = new HashSet<Bill>();
            Invoice = new HashSet<Invoice>();
        }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<Bill> Bill { get; set; }
    }
}
