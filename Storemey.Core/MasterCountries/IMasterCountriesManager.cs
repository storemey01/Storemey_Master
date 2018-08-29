using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Storemey.MasterCountries
{
    public interface IMasterCountriesManager : IDomainService
    {
        Task<IEnumerable<MasterCountries>> ListAll();

        Task Create(MasterCountries input);

        Task Update(MasterCountries input);

        Task Delete(MasterCountries input);

        Task <MasterCountries> GetByID(int ID);
        
    }
}