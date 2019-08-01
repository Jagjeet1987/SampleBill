using SampleBill.Repository.Interfaces;
using System;

namespace SampleBill.Repository.ViewModels
{
    public class BaseVM<T> : IViewModel<T>
    {
        public T Id { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
