using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Storemey.MasterPlanServices
{
    public interface IMasterPlanServicesManager : IDomainService
    {
        Task<IEnumerable<MasterPlanServices>> ListAll();

        Task Create(MasterPlanServices input);

        Task Update(MasterPlanServices input);

        Task Delete(MasterPlanServices input);

        Task <MasterPlanServices> GetByID(int ID);
        
    }
}