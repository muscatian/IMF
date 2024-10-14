using AutoMapper.Configuration.Annotations;
using IMF.DAL.Identity;
using System;

namespace IMF.DAL.Models.Common
{
    public abstract class AuditableBaseEntity : BaseEntity
    {
        [Ignore]
        public virtual ApplicationUser Created { get; set; }
        [Ignore]
        public virtual ApplicationUser Modified { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; }
    }
}