﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CapMobileWebApp.DAL.Model
{
    public partial class Disbursement
    {
        public long DisbursementId { get; set; }
        public long BranchId { get; set; }
        public long AreaId { get; set; }
        public long GroupId { get; set; }
        public long CustomerId { get; set; }
        public string CsrCode { get; set; }
        public string ProductCode { get; set; }
        public string LoanCycleNo { get; set; }
        public double? LoanTypeid { get; set; }
        public int? NoofInstallments { get; set; }
        public string Approval { get; set; }
        public string Upfront { get; set; }
        public string Otp { get; set; }
        public string VerifyOtp { get; set; }
        public DateTime? FirstInstallmentDate { get; set; }
        public long? Createdby { get; set; }
        public DateTime? DisburseDate { get; set; }
    }
}