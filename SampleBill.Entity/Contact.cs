using System;
using System.Collections.Generic;

namespace SampleBill.Entity
{
    public class Contact : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
