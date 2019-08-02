using SampleBill.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBill.Repository.ViewModels
{
    public class ContactVM:BaseVM<Guid>
    {
        public ContactVM()
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
