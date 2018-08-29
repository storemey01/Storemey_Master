using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using Storemey.MasterPlans;
using Abp.Application.Services.Dto;

namespace Storemey.MasterPlans
{
    public class MasterPlansManager : IMasterPlansManager
    {
        private readonly IRepository<MasterPlans, Guid> _countryMasterRepository;

        public MasterPlansManager(
            IRepository<MasterPlans, Guid> countryMasterRepository)
        {
            _countryMasterRepository = countryMasterRepository;
        }

        public async Task<IEnumerable<MasterPlans>> ListAll()
        {
            var @MasterPlans = await _countryMasterRepository.GetAllListAsync(x => x.IsDeleted == false);
            return @MasterPlans;
        }

        public async Task Create(MasterPlans input)
        {
            input.IsDeleted = false;
            await _countryMasterRepository.InsertAsync(input);
        }

        public async Task Update(MasterPlans input)
        {
            input.IsDeleted = false;
            await _countryMasterRepository.UpdateAsync(input);
        }

        public async Task Delete(MasterPlans input)
        {
            input.IsDeleted = true;
            await _countryMasterRepository.UpdateAsync(input);
        }

        public async Task<MasterPlans> GetByID(int ID)
        {
            var @MasterPlans = await _countryMasterRepository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.PlanID == ID);

            if (@MasterPlans == null)
            {
                return new MasterPlans();
            }
            return @MasterPlans;
        }
        
    }
}