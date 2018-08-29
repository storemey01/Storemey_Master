using System;
using System.ComponentModel.DataAnnotations;

namespace Storemey.MasterPlanServices.Dto
{
    public class DeleteMasterPlanServicesInputDto
    {
        public virtual int ServicePlanID { get; set; }

        public virtual int PlanID { get; set; }

        public virtual string ServiceName { get; set; }

        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual int UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }


    }
}