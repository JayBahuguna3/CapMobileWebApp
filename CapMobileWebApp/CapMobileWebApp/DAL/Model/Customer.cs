﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CapMobileWebApp.DAL.Model
{
    public partial class Customer
    {
        public Customer()
        {
            CashFlowBusiness = new HashSet<CashFlowBusiness>();
            CashFlowSalary = new HashSet<CashFlowSalary>();
            Guarantor = new HashSet<Guarantor>();
            Nominee = new HashSet<Nominee>();
            SecurityAnswers = new HashSet<SecurityAnswers>();
        }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime AccountDate { get; set; }
        public string ResAddress { get; set; }
        public string OffAddress { get; set; }
        public string TelPhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string PhotoIdentityNumber { get; set; }
        public string PanCardNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Age { get; set; }
        public long ActiveBy { get; set; }
        public string City { get; set; }
        public string Mstate { get; set; }
        public string EmailId { get; set; }
        public int Pincode { get; set; }
        public byte[] Photoid { get; set; }
        public byte[] Mphoto { get; set; }
        public string Idtype { get; set; }
        public bool? Memactive { get; set; }
        public long? GroupId { get; set; }
        public long? BranchId { get; set; }
        public long? LastModifiedBy { get; set; }
        public string Approval { get; set; }
        public long? ManagerId { get; set; }
        public string Csrapprove { get; set; }
        public double? Prpoposedloanamount { get; set; }
        public string ManagerRemark { get; set; }
        public string Csrremark { get; set; }
        public DateTime? Mangerdate { get; set; }
        public DateTime? Csrdate { get; set; }
        public long? LoanTypeid { get; set; }
        public string LoanCycleNo { get; set; }
        public string MartialStatus { get; set; }
        public string SpouseName { get; set; }
        public DateTime? SpouseDob { get; set; }
        public string NomineeName { get; set; }
        public string NomineeAge { get; set; }
        public string NomineeRelation { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string Gender { get; set; }
        public string ApplicantFather { get; set; }
        public string FamilyDetails { get; set; }
        public string FamilyRelation { get; set; }
        public string Rationcardno { get; set; }
        public string VoterIdcardno { get; set; }
        public string Uidno { get; set; }
        public string LoanPurpose { get; set; }
        public byte[] Idproof1 { get; set; }
        public byte[] Idproof2 { get; set; }
        public long? OriginatorId { get; set; }
        public DateTime? OfficerChangeDate { get; set; }
        public byte[] CustomerSign { get; set; }
        public string FamilyDetails2 { get; set; }
        public string FamilyRelation2 { get; set; }
        public string FamilyDetails3 { get; set; }
        public string FamilyRelation3 { get; set; }
        public string FamilyDetails4 { get; set; }
        public string FamilyRelation4 { get; set; }
        public byte[] TebusinessActivity { get; set; }
        public byte[] VebusinessActivity { get; set; }
        public string ApplicantName { get; set; }
        public bool ActivityConfirmation { get; set; }
        public bool CreditHistory { get; set; }
        public bool VerificationOfDocs { get; set; }
        public string DvecustomerApproval { get; set; }
        public DateTime? DvecustomerApprovalDateTime { get; set; }
        public string ExActiveCustId { get; set; }
        public long? ExActiveLoanAc { get; set; }
        public bool? IsReLoan { get; set; }
        public bool? IsExistingLoanClose { get; set; }
        public bool? IsTopupLoan { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerAadharAddress { get; set; }
        public string CustomerCurrentAddress { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerTaluka { get; set; }
        public string CustomerVillage { get; set; }
        public decimal? CustomerLat { get; set; }
        public decimal? CustomerLong { get; set; }
        public DateTime? CustomerLoanApplicationDate { get; set; }
        public string CustomerDrivingLicNo { get; set; }
        public string CustomerEducation { get; set; }
        public string CustomerCategory { get; set; }
        public string CustomerLoanType { get; set; }
        public string NomineeAadharCard { get; set; }
        public string NomineePanCard { get; set; }
        public string NomineeMobileNo { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorAddress { get; set; }
        public string GuarantorGender { get; set; }
        public string GuarantorMobileNo { get; set; }
        public DateTime? GuarantorDob { get; set; }
        public byte[] GuarantorPhoto { get; set; }
        public string GuarantorCompanyName { get; set; }
        public decimal? GuarantorSalary { get; set; }
        public long? CreatedBy { get; set; }

        public virtual UserInfo CreatedByNavigation { get; set; }
        public virtual ICollection<CashFlowBusiness> CashFlowBusiness { get; set; }
        public virtual ICollection<CashFlowSalary> CashFlowSalary { get; set; }
        public virtual ICollection<Guarantor> Guarantor { get; set; }
        public virtual ICollection<Nominee> Nominee { get; set; }
        public virtual ICollection<SecurityAnswers> SecurityAnswers { get; set; }
    }
}