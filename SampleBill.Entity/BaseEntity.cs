using SampleBill.Common;
using SampleBill.Entity.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleBill.Entity
{
    public abstract class BaseEntity<T> : ICommonEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = CommonClass.Common.GetCurrentDateTime;

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
