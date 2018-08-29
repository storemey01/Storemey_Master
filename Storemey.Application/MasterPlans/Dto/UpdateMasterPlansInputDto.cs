using System;
using System.ComponentModel.DataAnnotations;

namespace Storemey.MasterPlans.Dto
{
    public class UpdateMasterPlansInputDto
    {
        public virtual int PlanID { get; set; }

        public virtual string PlanName { get; set; }

        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual int UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }


    }
}