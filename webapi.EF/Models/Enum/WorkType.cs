using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace webapi.EF.Models
{
    public enum WorkType : byte
    {
        Fulltime = 1,
        Parttime = 2
    }
    public class EnumWorkType
    {
        public byte Id { get; set; } // ← Match the foreign key type
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
