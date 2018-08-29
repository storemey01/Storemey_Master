using System;
using System.ComponentModel.DataAnnotations;

namespace Storemey.MasterCountries.Dto
{
    public class GetMasterCountriesInputDto
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string Dail_Code { get; set; }
        public virtual string Currency_Name { get; set; }
        public virtual string Curreny_Symbol { get; set; }
        public virtual string Current_Code { get; set; }
        public virtual string Flagimage { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual int UpdatedBy { get; set; }
        public virtual DateTime UpdatedDate { get; set; }

    }
}