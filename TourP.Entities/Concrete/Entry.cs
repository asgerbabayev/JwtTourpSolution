using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TourP.Core.Entities;

namespace TourP.Entities.Concrete
{
    public class Entry:IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public int AdsId { get; set; }
        [JsonIgnore]
        public Ads Ads { get; set; }
    }
}
