﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapMobileWebApp.DAL.Model
{
    public partial class spS_EMICalculationDataByUserResult
    {
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public long? GroupId { get; set; }
        public long? AccountNo { get; set; }
        public double? Amount { get; set; }
        public double? Interestrate { get; set; }
        public int? Durationinmonth { get; set; }
        public double? installmentamount { get; set; }
        public double? ODInterestAmount { get; set; }
        public int? NoofInstallments { get; set; }
        public double? Balance { get; set; }
        public DateTime? FirstInstallmentDate { get; set; }
        public string InterestType { get; set; }
        public DateTime? DisburseDate { get; set; }
    }
}