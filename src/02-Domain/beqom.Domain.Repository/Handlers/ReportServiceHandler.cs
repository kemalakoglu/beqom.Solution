using AutoMapper;
using beqom.Domain.Aggregate.Employee;
using beqom.Domain.Contract.DTO;
using beqom.Domain.Contract.Interface;
using MediatR;

namespace beqom.Domain.Repository.Handlers
{
    public class ReportServiceHandler : IRequestHandler<ReportRequestDto, IEnumerable<ReportResponseDto>>
    {
        private readonly IMapper mapper;
        private readonly IReportRepository reportRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="reportRepository"></param>
        public ReportServiceHandler(IMapper mapper, IReportRepository reportRepository)
        {
            this.mapper = mapper;
            this.reportRepository = reportRepository;
        }

        /// <summary>
        /// Task<IEnumerable<ReportResponseDto>> Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ReportResponseDto>> Handle(ReportRequestDto request, CancellationToken cancellationToken)
        {
            IEnumerable<ReportResponseDto> response = new List<ReportResponseDto>();
            IEnumerable<Report> report = await this.reportRepository.GetReportAsync();
            response = mapper.Map<IEnumerable<ReportResponseDto>>(report);
            return response;
        }
    }
}
