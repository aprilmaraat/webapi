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
        public WorkType Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual Contact Contact { get; set; }
        public EnumWorkType(WorkType id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
