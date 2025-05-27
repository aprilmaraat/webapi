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
        public virtual EnumWorkType WorkType { get; set; } = null!; // Fix for CS8618: Initialize with null-forgiving operator

        // Fix for IDE0290: Use primary constructor
        public Contact(Guid id, string email, string fullName, string mobileNumber, string location, byte workTypeId, DateTime createdAt)
        {
            Id = id;
            Email = email;
            FullName = fullName;
            MobileNumber = mobileNumber;
            Location = location;
            WorkTypeId = workTypeId;
            CreatedAt = createdAt;
        }
    }
}
