using AutoMapper;
using beqom.Domain.Aggregate.Employee;
using beqom.Domain.Aggregate.Option;
using beqom.Domain.Contract.DTO;
using beqom.Domain.Contract.DTO.Option;

namespace beqom.Presentation.API.Extensions
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Option, OptionResponseDto>();
            CreateMap<Employee, Report>().ForMember(x => x.NewSalary, act => act.Ignore());
            CreateMap<Report, ReportResponseDto>();
        }
    }
}