using AutoMapper;
using AwqafTest.Models.ViewModels;

namespace AwqafTest.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountLedger, AccountLedgerViewModel>().ReverseMap();
            CreateMap<Account, AccountViewModel>().ReverseMap();
            CreateMap<FiscalYear, FiscalYearViewModel>().ReverseMap();
            CreateMap<Voucher, VoucherViewModel>().ReverseMap();
        }
    }
}