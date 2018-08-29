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


namespace Storemey.MasterCountries
{
    [Table("MasterCountries")]
    public class MasterCountries : FullAuditedEntity<Guid>
    {
        public virtual int ID { get; set; }
        
        public virtual string Name { get; set; }
        
        public virtual string Code { get; set; }
        public virtual string Dail_Code { get; set; }
        public virtual string Currency_Name { get; set; }
        public virtual string Curreny_Symbol { get; set; }
        public virtual string Current_Code { get;set; }
        public virtual string Flagimage { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual int UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        
        public MasterCountries()
        {
            IsActive = true;
            IsDeleted = false;
            UpdatedBy = 1;
            UpdatedDate = DateTime.Now;
        }
    }
}
