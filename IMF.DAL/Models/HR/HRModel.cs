using IMF.DAL.Models.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMF.DAL.Models.HR
{
    public class Employees : Person
    {
        [Column("EmployeeId")]
        public override int Id { get; set; }
        [StringLength(20)]
        public string EmployeeNumber { get; set; }
        public DateOnly DateOfAppointment { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? CurrentBasic { get; set; }
        public int? LoginId { get; set; }
        [ForeignKey("DesignationId")]
        [ValidateNever]
        public Designation Designation { get; set; }
        public int? DesignationId { get; set; }
        [ForeignKey("PayScaleId")]
        [ValidateNever]
        public PayScale PayScale { get; set; }
        public int? PayScaleId { get; set; }

        [ForeignKey("DepartmentId")]
        [ValidateNever]
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }

    }

    public class Documents : AuditableBaseEntity
    {
        [StringLength(10)]
        public string Category { get; set; }
        [StringLength(50)]
        public string DisplayFileName { get; set; }
        [StringLength(50)]
        public string UniqueFileName { get; set; } 

    }

    public class PayScale : AuditableBaseEntity
    {
        [StringLength(80)]
        public string PayScaleName { get; set; }
        public ICollection<Employees> EmployeeId { get; set; }

    }

    public class Designation : AuditableBaseEntity
    {
        [StringLength(100)]
        public string DesignationName { get; set; }
        public ICollection<Employees> EmployeeId { get; set; }
    }

    public class Department : AuditableBaseEntity
    {
        [StringLength(100)]
        public string DepartmentName { get; set; }
        public ICollection<Employees> EmployeeId { get; set; }
    }

    public class JobHistory : AuditableBaseEntity
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }
    }
}
