using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using Storemey.MasterCountries;
using Abp.Application.Services.Dto;

namespace Storemey.MasterCountries
{
    public class MasterCountriesManager : IMasterCountriesManager
    {
        private readonly IRepository<MasterCountries, Guid> _countryMasterRepository;

        public MasterCountriesManager(
            IRepository<MasterCountries, Guid> countryMasterRepository)
        {
            _countryMasterRepository = countryMasterRepository;
        }

        public async Task<IEnumerable<MasterCountries>> ListAll()
        {
            var @MasterCountries = await _countryMasterRepository.GetAllListAsync(x => x.IsDeleted == false);
            return @MasterCountries;
        }

        public async Task Create(MasterCountries input)
        {
            input.IsDeleted = false;
            await _countryMasterRepository.InsertAsync(input);
        }

        public async Task Update(MasterCountries input)
        {
            input.IsDeleted = false;
            await _countryMasterRepository.UpdateAsync(input);
        }

        public async Task Delete(MasterCountries input)
        {
            input.IsDeleted = true;
            await _countryMasterRepository.UpdateAsync(input);
        }

        public async Task<MasterCountries> GetByID(int ID)
        {
            var @MasterCountries = await _countryMasterRepository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ID == ID);

            if (@MasterCountries == null)
            {
                return new MasterCountries();
            }
            return @MasterCountries;
        }
        
    }
}