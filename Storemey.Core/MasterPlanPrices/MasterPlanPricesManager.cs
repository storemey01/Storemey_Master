using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using Storemey.MasterPlanPrices;
using Abp.Application.Services.Dto;

namespace Storemey.MasterPlanPrices
{
    public class MasterPlanPricesManager : IMasterPlanPricesManager
    {
        private readonly IRepository<MasterPlanPrices, Guid> _countryMasterRepository;

        public MasterPlanPricesManager(
            IRepository<MasterPlanPrices, Guid> countryMasterRepository)
        {
            _countryMasterRepository = countryMasterRepository;
        }

        public async Task<IEnumerable<MasterPlanPrices>> ListAll()
        {
            var @MasterPlanPrices = await _countryMasterRepository.GetAllListAsync(x => x.IsDeleted == false);
            return @MasterPlanPrices;
        }

        public async Task Create(MasterPlanPrices input)
        {
            input.IsDeleted = false;
            await _countryMasterRepository.InsertAsync(input);
        }

        public async Task Update(MasterPlanPrices input)
        {
            input.IsDeleted = false;
            await _countryMasterRepository.UpdateAsync(input);
        }

        public async Task Delete(MasterPlanPrices input)
        {
            input.IsDeleted = true;
            await _countryMasterRepository.UpdateAsync(input);
        }

        public async Task<MasterPlanPrices> GetByID(int ID)
        {
            var @MasterPlanPrices = await _countryMasterRepository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.CountryID == ID);

            if (@MasterPlanPrices == null)
            {
                return new MasterPlanPrices();
            }
            return @MasterPlanPrices;
        }
        
    }
}