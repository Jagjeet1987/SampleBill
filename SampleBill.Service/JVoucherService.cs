using AutoMapper;
using Microsoft.Extensions.Configuration;
using SampleBill.Common;
using SampleBill.Entity;
using SampleBill.Repository.Interfaces;
using SampleBill.Repository.ViewModels;
using SampleBill.Service.Interface;
using System;
using System.Threading.Tasks;

namespace SampleBill.Service
{
    public class JVoucherService : IJVoucherService
    {
        private IConfiguration _config;
        private readonly IRepository<JVoucher> _repository;
        private readonly IMapper _mapper;

        public JVoucherService(IRepository<JVoucher> repository, IMapper mapper, IConfiguration config)
        {
            _repository = repository;
            _mapper = mapper;
            _config = config;
        }

        public Task<ApiResponse<JVoucher>> SaveVoucher(JVoucherVM vm)
        {
            throw new NotImplementedException();
        }
    }
}
