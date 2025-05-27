using System.Text.Json.Serialization;

namespace webapi.EF.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public byte WorkTypeId { get; set; }
        [JsonIgnore]
        public virtual EnumWorkType WorkType { get; set; }
        public Contact(Guid id, string email, string fullName, string mobileNumber, string location, WorkType workType, DateTime createdAt)
        {
            Id = id;
            Email = email;
            FullName = fullName;
            MobileNumber = mobileNumber;
            Location = location;
            WorkTypeId = (byte)workType; // Explicit cast added to fix CS0266
            CreatedAt = createdAt;
        }
    }
}
