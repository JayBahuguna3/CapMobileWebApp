﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CapMobileWebApp.DAL.Model
{
    public partial class Process
    {
        public Process()
        {
            GroupTrainingProcess = new HashSet<GroupTrainingProcess>();
        }

        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public DateTime DateCreated { get; set; }
        public long? Createdby { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<GroupTrainingProcess> GroupTrainingProcess { get; set; }
    }
}