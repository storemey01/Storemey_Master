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
using Storemey.MasterCountries.Dto;

namespace Storemey.MasterCountries
{
    [AbpAuthorize]
    public class MasterCountriesAppService :  IMasterCountriesAppService
    {
        private readonly IMasterCountriesManager _masterCountriesManager;
        private readonly IRepository<MasterCountries, Guid> _masterCountriesRepository;

        public MasterCountriesAppService(
            IMasterCountriesManager masterCountriesManager, 
            IRepository<MasterCountries, Guid> masterCountriesRepository)
        {
            _masterCountriesManager = masterCountriesManager;
            _masterCountriesRepository = masterCountriesRepository;
        }

        public async Task<ListResultDto<GetMasterCountriesOutputDto>> ListAll()
        {
            var events = await _masterCountriesManager.ListAll();
            return new ListResultDto<GetMasterCountriesOutputDto>(events.MapTo<List<GetMasterCountriesOutputDto>>());
        }

        public async Task Create(CreateMasterCountriesInputDto input)
        {
            var mapData = input.MapTo<MasterCountries>();
            await _masterCountriesManager
                .Create(mapData);
        }

        public async Task Update(UpdateMasterCountriesInputDto input)
        {
            var mapData = input.MapTo<MasterCountries>();
            await _masterCountriesManager
                .Create(mapData);
        }
        
        public async Task Delete(DeleteMasterCountriesInputDto input)
        {
            var mapData = input.MapTo<MasterCountries>();
            await _masterCountriesManager
                .Create(mapData);
        }
        
        
        public async Task<GetMasterCountriesOutputDto> GetById(GetMasterCountriesInputDto input)
        {
            var registration = await _masterCountriesManager.GetByID(input.ID);

            var mapData = registration.MapTo<GetMasterCountriesOutputDto>();

            return mapData;
        }

        public async Task<ListResultDto<GetMasterCountriesOutputDto>> GetAdvanceSearch(AdvanceSearchInputDto input)
        {
            var registration = await _masterCountriesManager.ListAll();

            var filtereddatat = registration.ToList().Skip(input.CurrentPage * input.MaxRecords).Take(input.CurrentPage).ToList();
            //.Result.Skip(input.CurrentPage * input.MaxRecords).Take(input.CurrentPage).ToList()
            var mapData = filtereddatat.MapTo<ListResultDto<GetMasterCountriesOutputDto>>();

            return mapData;
        }
    }
}