﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapMobileWebApp.DAL.Model
{
    public partial class spl_getContactInfoFromCGroupResult
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string Contactno { get; set; }
        public string ContactPerson { get; set; }
        public int? CurrentNoofMember { get; set; }
        public int? MemberLimitId { get; set; }
        public string PanCardNumber { get; set; }
        public long? BranchId { get; set; }
        public DateTime? groupdate { get; set; }
        public long? CreatedBy { get; set; }
        public long? LastModifiedby { get; set; }
        public string Approval { get; set; }
        public long? AreaId { get; set; }
        public long? ManagerId { get; set; }
        public string CSRApprove { get; set; }
        public DateTime? Mangerdate { get; set; }
        public DateTime? CSRdate { get; set; }
        public long? OriginatorId { get; set; }
        public DateTime? OfficerChangeDate { get; set; }
        public long? OTP { get; set; }
        public long? VerifyOTP { get; set; }
        public string DVEGroupApproval { get; set; }
        public DateTime? DVEGroupApprovalDateTime { get; set; }
        public bool? IsTopupLoan { get; set; }
        public long? ExistingGroupId { get; set; }
        public long? ExistingCenterId { get; set; }
    }
}