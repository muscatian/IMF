using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMF.DAL.Models.Common
{
    public class Person : AuditableBaseEntity
    {
        [StringLength(10)] 
        public string Title { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        [StringLength(1)]
        public string Gender { get; set; }
        public int? Nationality { get; set; }
        [StringLength(20)]
        public string PassportNo { get; set; }
        public DateOnly PassportValidUntil { get; set; }
        [StringLength(20)]
        public string IDCardNo { get; set; }
        public DateOnly IDCardNoValidUntil { get; set; }
        [StringLength(100)]
        public string ImageURL { get; set; }
    }
}
