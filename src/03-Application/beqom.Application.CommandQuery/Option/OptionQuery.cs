﻿using beqom.Domain.Contract.DTO.Option;
using System.Threading.Tasks;

namespace beqom.Application.CommandQuery
{
    public partial class ApplicationService
    {
        #region Option Aggregate
        /// <summary>
        /// GetOptionAsync
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<OptionResponseDto> GetOptionAsync(OptionRequestDto request)
        {
            return await this.mediator.Send(request);
        }
        #endregion
    }
}
