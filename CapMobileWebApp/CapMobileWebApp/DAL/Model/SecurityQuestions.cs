﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CapMobileWebApp.DAL.Model
{
    public partial class SecurityQuestions
    {
        public SecurityQuestions()
        {
            SecurityAnswers = new HashSet<SecurityAnswers>();
        }

        public long QuestionId { get; set; }
        public string Question { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<SecurityAnswers> SecurityAnswers { get; set; }
    }
}