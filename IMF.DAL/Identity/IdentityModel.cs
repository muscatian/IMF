using IMF.DAL.Models.Common;
using IMF.DAL.Models.HR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMF.DAL.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(50)] 
        public string LastName { get; set; }
        [StringLength(50)]
        public string GroupName { get; set; }
        [StringLength(25)] 
        public string Phone { get; set; }
        [StringLength(500)] 
        public string Address { get; set; }
        public int? CompanyId { get; set; }

        #region ICollections Foreign Key Refernece for Created by and LastModified By
        public ICollection<Company> CompanyCreatedby { get; set; }
        public ICollection<Company> CompanyModifiedby { get; set; }
        public ICollection<Employees> EmployeeCreatedby { get; set; }
        public ICollection<Employees> EmployeeModifiedby { get; set; }
        public ICollection<Documents> DocumentCreatedby { get; set; }
        public ICollection<Documents> DocumentModifiedby { get; set; }
        public ICollection<PayScale> PayScaleCreatedby { get; set; }
        public ICollection<PayScale> PayScaleModifiedby { get; set; }
        public ICollection<Designation> DesignationCreatedby { get; set; }
        public ICollection<Designation> DesignationModifiedby { get; set; }
        public ICollection<Department> DepartmentCreatedby { get; set; }
        public ICollection<Department> DepartmentModifiedby { get; set; }
        public ICollection<JobHistory> JobHistoryCreatedby { get; set; }
        public ICollection<JobHistory> JobHistoryModifiedby { get; set; }

        #endregion
    }
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole() : base()
        {

        }
        public DateTime LastModified { get; set; }
        public bool IsSysAdmin { get; set; }
        [StringLength(300)] 
        public string RoleDescription { get; set; }

    }
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public ApplicationUserRole()
            : base()
        { }

        public ApplicationRole Role { get; set; }

        public bool IsSysAdmin { get { return this.Role.IsSysAdmin; } }
    }
    
}
