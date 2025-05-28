namespace webapi.DTOs
{
    public class ContactDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;

        public Guid? LocationId { get; set; }
        public byte? WorkTypeId { get; set; }
    }
}
