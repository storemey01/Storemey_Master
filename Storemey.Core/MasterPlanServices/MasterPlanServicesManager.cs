using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using Storemey.MasterPlanServices;
using Abp.Application.Services.Dto;

namespace Storemey.MasterPlanServices
{
    public class MasterPlanServicesManager : IMasterPlanServicesManager
    {
        private readonly IRepository<MasterPlanServices, Guid> _countryMasterRepository;

        public MasterPlanServicesManager(
            IRepository<MasterPlanServices, Guid> countryMasterRepository)
        {
            _countryMasterRepository = countryMasterRepository;
        }

        public async Task<IEnumerable<MasterPlanServices>> ListAll()
        {
            var @MasterPlanServices = await _countryMasterRepository.GetAllListAsync(x => x.IsDeleted == false);
            return @MasterPlanServices;
        }

        public async Task Create(MasterPlanServices input)
        {
            input.IsDeleted = false;
            await _countryMasterRepository.InsertAsync(input);
        }

        public async Task Update(MasterPlanServices input)
        {
            input.IsDeleted = false;
            await _countryMasterRepository.UpdateAsync(input);
        }

        public async Task Delete(MasterPlanServices input)
        {
            input.IsDeleted = true;
            await _countryMasterRepository.UpdateAsync(input);
        }

        public async Task<MasterPlanServices> GetByID(int ID)
        {
            var @MasterPlanServices = await _countryMasterRepository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.PlanID == ID);

            if (@MasterPlanServices == null)
            {
                return new MasterPlanServices();
            }
            return @MasterPlanServices;
        }
        
    }
}