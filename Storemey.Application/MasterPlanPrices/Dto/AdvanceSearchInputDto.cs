﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Storemey.MasterPlanPrices.Dto
{
    public class AdvanceSearchInputDto
    {
        public virtual string SearchText { get; set; }
        public virtual int CurrentPage { get; set; }
        public virtual int MaxRecords { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        
    }
}