using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SampleBill.Common.Enum;

namespace SampleBill.Entity
{
    public static class Seed
    {
        public static void EnsureSeeded(this AccountingDbContext context)
        {
            Guid BillId;
            Guid ContactId;
            Guid TransactionId;
            decimal TotalAmount = 0;
            if (!context.Contact.Any())
            {
                context.Contact.Add(new Contact { Name = "Jagjeet", TypeId = Convert.ToInt32(ContactType.Customer), IsActive = true, CreatedBy = 1, CreatedOn = DateTime.UtcNow });

                context.SaveChanges();
            }

            ContactId = context.Contact.FirstOrDefault().Id;


            //Ensure we create initial Threat List
            if (!context.Bill.Any(a => a.ContactId == ContactId))
            {
                var bill = new Bill
                {
                    ContactId = ContactId,

                    DueDate = DateTime.Now.AddDays(20),
                    BillDate = DateTime.Now,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedOn = DateTime.UtcNow,
                    Number = 1001,
                    TotalAmount = 500

                };
                context.Bill.Add(bill);
                context.SaveChanges();
                BillId = bill.Id;
                TotalAmount = bill.TotalAmount;
                if (!context.Transaction.Any(a => a.EntityId == BillId && a.EntityType == 2))
                {
                    var trans = new Transaction
                    {
                        Description = "Bill",
                        EntityType = Convert.ToInt32(TransactionType.Bill),
                        EntityId = BillId,
                        IsActive = true,
                        CreatedBy = 1,
                        CreatedOn = DateTime.UtcNow,

                    };
                    context.Transaction.Add(trans);
                    context.SaveChanges();
                    TransactionId = trans.Id;
                    if (!context.JVoucher.Any(a => a.TransactionId == TransactionId))
                    {
                        var JVDebit = new JVoucher
                        {
                            TransactionId = TransactionId,
                            Reference = "JV-Debit",
                            Debit = TotalAmount,
                            Credit = 0,
                            Description = "Debit",
                            IsActive = true,
                            CreatedBy = 1,
                            CreatedOn = DateTime.UtcNow,
                        };
                        context.JVoucher.Add(JVDebit);
                        context.SaveChanges();

                        var JVCredit = new JVoucher
                        {
                            TransactionId = TransactionId,
                            Reference = "JV-Credit",
                            Debit = 0,
                            Credit = TotalAmount,
                            Description = "Credit",
                            IsActive = true,
                            CreatedBy = 1,
                            CreatedOn = DateTime.UtcNow,
                        };
                        context.JVoucher.Add(JVCredit);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
