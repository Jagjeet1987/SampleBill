using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBill.Entity
{
    public class Transaction:BaseEntity<Guid>
    {
        public Transaction()
        {
            JVoucher = new HashSet<JVoucher>();
        }        
        public int EntityType { get; set; }
        public Guid EntityId { get; set; }
        public virtual ICollection<JVoucher> JVoucher { get; set; }
        public string Description { get; set; }
       
    }
}
