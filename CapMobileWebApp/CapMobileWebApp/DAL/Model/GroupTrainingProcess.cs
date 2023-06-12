﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CapMobileWebApp.DAL.Model
{
    public partial class GroupTrainingProcess
    {
        public long GroupTrainingProcessId { get; set; }
        public long SurveyInformationId { get; set; }
        public long AreaId { get; set; }
        public int ProcessId { get; set; }
        public int DaysId { get; set; }
        public byte[] DayPhoto { get; set; }
        public long FieldOfficerId { get; set; }
        public long BranchId { get; set; }
        public DateTime? ProcessDate { get; set; }
        public bool ProcessStatus { get; set; }
        public string Comments { get; set; }
        public int? NoofCustomer { get; set; }

        public virtual Day Days { get; set; }
        public virtual Process Process { get; set; }
    }
}