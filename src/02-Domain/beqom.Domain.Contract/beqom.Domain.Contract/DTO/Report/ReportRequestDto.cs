using MediatR;
using System.Collections.Generic;

namespace beqom.Domain.Contract.DTO
{
    public class ReportRequestDto : IRequest<IEnumerable<ReportResponseDto>>
    {
    }
}
