using System;
using System.ComponentModel.DataAnnotations;

namespace SampleBill.Entity.Interfaces
{
    public interface ICommonEntity<T>
    {
        [Key]
        //[AutoIdentity]
        T Id { get; set; }

        long CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        bool IsActive { get; set; }
        long? ModifiedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
