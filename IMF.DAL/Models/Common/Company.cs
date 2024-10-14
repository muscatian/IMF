using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMF.DAL.Models.Common
{
    public class Company : AuditableBaseEntity
    {
        [Column("CompanyId")]
        public override int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)] 
        public string Address { get; set; }
        [StringLength(500)] 
        public string Description { get; set; }
        [StringLength(200)] 
        public string FocalPerson { get; set; }
        [StringLength(50)] 
        public string EmailAddress { get; set; }
        [StringLength(20)] 
        public string PhoneNo { get; set; }
        [StringLength(20)] 
        public string CRNumber { get; set; }
        [StringLength(100)] 
        public string ImageURL { get; set; }
    }
}
