﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapMobileWebApp.DAL.Model
{
    public partial class GetDelayedProcessResult
    {
        public int SrNo { get; set; }
        public string ProcessDelayed { get; set; }
        public int? CSR { get; set; }
        public int? FS { get; set; }
        public int? BLC { get; set; }
        public int? BM { get; set; }
    }
}