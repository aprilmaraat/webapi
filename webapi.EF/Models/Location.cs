using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace webapi.EF.Models
{
    public class Location : BaseEntity
    {
        public string City { get; set; } = string.Empty; // Initialize with a default value
        public string Country { get; set; } = string.Empty; // Initialize with a default value
        [JsonIgnore]
        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public Location() { }
        public Location(Guid id, string city, string country, DateTime createdAt)
        {
            Id = id;
            City = city;
            Country = country;
        }
    }
}
