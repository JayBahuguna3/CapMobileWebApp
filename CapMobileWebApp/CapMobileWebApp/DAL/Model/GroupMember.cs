﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CapMobileWebApp.DAL.Model
{
    public partial class GroupMember
    {
        public long GroupMemberId { get; set; }
        public long CustomerId { get; set; }
        public long GroupId { get; set; }
        public long? BranchId { get; set; }
        public bool? IsTopupLoan { get; set; }
    }
}