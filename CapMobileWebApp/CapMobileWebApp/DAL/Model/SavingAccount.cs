﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CapMobileWebApp.DAL.Model
{
    public partial class SavingAccount
    {
        public long SavingId { get; set; }
        public long? SavingaccountNo { get; set; }
        public long? CustomerId { get; set; }
        public double? Amount { get; set; }
        public DateTime? OpenDate { get; set; }
        public double? Balance { get; set; }
        public bool? AccountVerification { get; set; }
    }
}