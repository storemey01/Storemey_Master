using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.UI;
using Storemey.MasterPlanServices.Dto;

namespace Storemey.MasterPlanServices
{
    [AbpAuthorize]
    public class MasterPlanServicesAppService :  IMasterPlanServicesAppService
    {
        private readonly IMasterPlanServicesManager _MasterPlanServicesManager;
        private readonly IRepository<MasterPlanServices, Guid> _MasterPlanServicesRepository;

        public MasterPlanServicesAppService(
            IMasterPlanServicesManager MasterPlanServicesManager, 
            IRepository<MasterPlanServices, Guid> MasterPlanServicesRepository)
        {
            _MasterPlanServicesManager = MasterPlanServicesManager;
            _MasterPlanServicesRepository = MasterPlanServicesRepository;
        }

        public async Task<ListResultDto<GetMasterPlanServicesOutputDto>> ListAll()
        {
            var events = await _MasterPlanServicesManager.ListAll();
            return new ListResultDto<GetMasterPlanServicesOutputDto>(events.MapTo<List<GetMasterPlanServicesOutputDto>>());
        }

        public async Task Create(CreateMasterPlanServicesInputDto input)
        {
            var mapData = input.MapTo<MasterPlanServices>();
            await _MasterPlanServicesManager
                .Create(mapData);
        }

        public async Task Update(UpdateMasterPlanServicesInputDto input)
        {
            var mapData = input.MapTo<MasterPlanServices>();
            await _MasterPlanServicesManager
                .Create(mapData);
        }
        
        public async Task Delete(DeleteMasterPlanServicesInputDto input)
        {
            var mapData = input.MapTo<MasterPlanServices>();
            await _MasterPlanServicesManager
                .Create(mapData);
        }
        
        
        public async Task<GetMasterPlanServicesOutputDto> GetById(GetMasterPlanServicesInputDto input)
        {
            var registration = await _MasterPlanServicesManager.GetByID(input.PlanID);

            var mapData = registration.MapTo<GetMasterPlanServicesOutputDto>();

            return mapData;
        }

        public async Task<ListResultDto<GetMasterPlanServicesOutputDto>> GetAdvanceSearch(AdvanceSearchInputDto input)
        {
            var registration = await _MasterPlanServicesManager.ListAll();

            var filtereddatat = registration.ToList().Skip(input.CurrentPage * input.MaxRecords).Take(input.CurrentPage).ToList();
            //.Result.Skip(input.CurrentPage * input.MaxRecords).Take(input.CurrentPage).ToList()
            var mapData = filtereddatat.MapTo<ListResultDto<GetMasterPlanServicesOutputDto>>();

            return mapData;
        }
    }
}