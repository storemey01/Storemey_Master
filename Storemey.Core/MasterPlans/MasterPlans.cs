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


namespace Storemey.MasterPlans
{
    [Table("MasterPlans")]
    public class MasterPlans : FullAuditedEntity<Guid>
    {
        public virtual int PlanID { get; set; }
        
        public virtual string PlanName { get; set; }
       
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual int UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        
        public MasterPlans()
        {
            IsActive = true;
            IsDeleted = false;
            UpdatedBy = 1;
            UpdatedDate = DateTime.Now;
        }
    }
}
