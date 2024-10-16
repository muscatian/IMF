namespace IMF.Api.DTO.Common
{
    public class CompanyDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string FocalPerson { get; set; }
        public string ImageURL { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }
        public string CRNumber { get; set; }

    }
}
