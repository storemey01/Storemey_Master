using System;
using System.ComponentModel.DataAnnotations;

namespace Storemey.MasterPlanPrices.Dto
{
    public class UpdateMasterPlanPricesInputDto
    {
        public virtual int PlanPriceID { get; set; }
        public virtual int PriceID { get; set; }
        public virtual int PlanID { get; set; }
        public virtual int CountryID { get; set; }
        public virtual int Amount { get; set; }

        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual int UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }

    }
}