using SampleBill.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBill.Repository.ViewModels
{
    public class JVoucherVM:BaseVM<Guid>
    {
        public string Description { get; set; }
        public string Reference { get; set; }
        public DateTime PostingDate { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public Guid TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
