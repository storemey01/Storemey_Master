using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Storemey.MasterPlans
{
    public interface IMasterPlansManager : IDomainService
    {
        Task<IEnumerable<MasterPlans>> ListAll();

        Task Create(MasterPlans input);

        Task Update(MasterPlans input);

        Task Delete(MasterPlans input);

        Task <MasterPlans> GetByID(int ID);
        
    }
}