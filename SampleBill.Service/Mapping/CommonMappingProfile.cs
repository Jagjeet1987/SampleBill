using SampleBill.Entity;
using SampleBill.Repository.ViewModels;
using AutoMapper;

namespace SampleBill.Service.Mapping
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<JVoucher, JVoucherVM>().ReverseMap();
        }
    }
}
