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
using Storemey.MasterPlans.Dto;

namespace Storemey.MasterPlans
{
    [AbpAuthorize]
    public class MasterPlansAppService :  IMasterPlansAppService
    {
        private readonly IMasterPlansManager _MasterPlansManager;
        private readonly IRepository<MasterPlans, Guid> _MasterPlansRepository;

        public MasterPlansAppService(
            IMasterPlansManager MasterPlansManager, 
            IRepository<MasterPlans, Guid> MasterPlansRepository)
        {
            _MasterPlansManager = MasterPlansManager;
            _MasterPlansRepository = MasterPlansRepository;
        }

        public async Task<ListResultDto<GetMasterPlansOutputDto>> ListAll()
        {
            var events = await _MasterPlansManager.ListAll();
            return new ListResultDto<GetMasterPlansOutputDto>(events.MapTo<List<GetMasterPlansOutputDto>>());
        }

        public async Task Create(CreateMasterPlansInputDto input)
        {
            var mapData = input.MapTo<MasterPlans>();
            await _MasterPlansManager
                .Create(mapData);
        }

        public async Task Update(UpdateMasterPlansInputDto input)
        {
            var mapData = input.MapTo<MasterPlans>();
            await _MasterPlansManager
                .Create(mapData);
        }
        
        public async Task Delete(DeleteMasterPlansInputDto input)
        {
            var mapData = input.MapTo<MasterPlans>();
            await _MasterPlansManager
                .Create(mapData);
        }
        
        
        public async Task<GetMasterPlansOutputDto> GetById(GetMasterPlansInputDto input)
        {
            var registration = await _MasterPlansManager.GetByID(input.PlanID);

            var mapData = registration.MapTo<GetMasterPlansOutputDto>();

            return mapData;
        }

        public async Task<ListResultDto<GetMasterPlansOutputDto>> GetAdvanceSearch(AdvanceSearchInputDto input)
        {
            var registration = await _MasterPlansManager.ListAll();

            var filtereddatat = registration.ToList().Skip(input.CurrentPage * input.MaxRecords).Take(input.CurrentPage).ToList();
            //.Result.Skip(input.CurrentPage * input.MaxRecords).Take(input.CurrentPage).ToList()
            var mapData = filtereddatat.MapTo<ListResultDto<GetMasterPlansOutputDto>>();

            return mapData;
        }
    }
}