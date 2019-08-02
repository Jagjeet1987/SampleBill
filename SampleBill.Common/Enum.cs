using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBill.Common
{
    public class Enum
    {
        public enum SessionKeys
        {
            UserId,
            User,
            RoleId,
        }
        public enum JsonNames
        {
            NewsResult,
            CategoryResult,
            SubscriptionResult,
            DiscussionResult,
        }
       
        public enum UserRole
        {
            Admin = 1,
            User = 2
        }
        public enum RoleId
        {
            Admin = 1,
            Member = 2
        }

        public enum TransactionType
        {
            Invoice=1,
            Bill=2
        }
        public enum ContactType
        {
            Customer=1,
            Vendor=2
        }
    }
}
