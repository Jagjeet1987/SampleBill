using AutoMapper;
using Microsoft.Extensions.Configuration;
using SampleBill.Common;
using SampleBill.Entity;
using SampleBill.Repository.Interfaces;
using SampleBill.Repository.ViewModels;
using SampleBill.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleBill.Service
{
    public class ContactService : IContactService
    {
        private IConfiguration _config;
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public ContactService(IRepository<Contact> repository, IMapper mapper, IConfiguration config)
        {
            _repository = repository;
            _mapper = mapper;
            _config = config;
        }

        public Task<ApiResponse<Contact>> SaveContact(ContactVM vm)
        {
            throw new NotImplementedException();
        }
    }
}
