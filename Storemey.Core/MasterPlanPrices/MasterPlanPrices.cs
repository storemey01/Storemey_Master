using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Abp.UI;
using System;


namespace Storemey.MasterPlanPrices
{
    [Table("MasterPlanPrices")]
    public class MasterPlanPrices : FullAuditedEntity<Guid>
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

        public MasterPlanPrices()
        {
            IsActive = true;
            IsDeleted = false;
            UpdatedBy = 1;
            UpdatedDate = DateTime.Now;
        }
    }
}
