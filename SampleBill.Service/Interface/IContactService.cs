using SampleBill.Common;
using SampleBill.Entity;
using SampleBill.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleBill.Service.Interface
{
    public interface IContactService
    {
        Task<ApiResponse<Contact>> SaveContact(ContactVM vm);
    }
}