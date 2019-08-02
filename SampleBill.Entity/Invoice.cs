using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SampleBill.Entity
{
    public class Invoice:BaseEntity<Guid>
    {       
      
        public long Number { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public Decimal? TotalAmount { get; set; }
        public Guid ContactId { get; set; }  
        public virtual Contact Contact { get; set; }
       
    }
}
