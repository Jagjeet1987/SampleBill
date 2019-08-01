using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SampleBill.Entity
{
    public class JVoucher:BaseEntity<Guid>
    {
        [ForeignKey("Transaction")]
        public Guid TransactionId { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public DateTime PostingDate { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
    }
}
