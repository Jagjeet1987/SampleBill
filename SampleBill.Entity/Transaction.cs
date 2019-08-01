using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBill.Entity
{
    public class Transaction:BaseEntity<Guid>
    {
        public string Description { get; set; }
        public int VoucherType { get; set; }
        public Guid JVoucherId { get; set; }
        public ICollection<JVoucher> JVouchers { get; set; }
    }
}
