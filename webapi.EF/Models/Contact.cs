using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapi.EF.Models
{
    public class Contact : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public Guid LocationId { get; set; }
        public byte WorkTypeId { get; set; }
        
        [JsonIgnore]
        [ForeignKey(nameof(WorkTypeId))]
        public virtual EnumWorkType WorkType { get; set; } = null!;
        [JsonIgnore]
        [ForeignKey(nameof(LocationId))]
        public virtual Location Location { get; set; } = null!;
        public Contact() { }
        public Contact(Guid id, string email, string fullName, string mobileNumber, Guid locationId, byte workTypeId)
        {
            Id = id;
            Email = email;
            FullName = fullName;
            MobileNumber = mobileNumber;
            LocationId = locationId;
            WorkTypeId = workTypeId;
        }
    }
}
