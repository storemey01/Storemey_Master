using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Storemey.MasterPlans.Dto;

namespace Storemey.MasterPlans
{
    public interface IMasterPlansAppService : IApplicationService
    {
        Task<ListResultDto<GetMasterPlansOutputDto>> ListAll();
        
        Task Create(CreateMasterPlansInputDto input);

        Task Update(UpdateMasterPlansInputDto input);

        Task Delete(DeleteMasterPlansInputDto input);

        Task<GetMasterPlansOutputDto> GetById(GetMasterPlansInputDto input);

        Task<ListResultDto<GetMasterPlansOutputDto>> GetAdvanceSearch(AdvanceSearchInputDto input);
    }
}
