namespace IMF.Api.DTO.Common
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; }
    }
}
