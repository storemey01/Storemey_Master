using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Storemey.MasterPlanPrices
{
    public interface IMasterPlanPricesManager : IDomainService
    {
        Task<IEnumerable<MasterPlanPrices>> ListAll();

        Task Create(MasterPlanPrices input);

        Task Update(MasterPlanPrices input);

        Task Delete(MasterPlanPrices input);

        Task <MasterPlanPrices> GetByID(int ID);
        
    }
}