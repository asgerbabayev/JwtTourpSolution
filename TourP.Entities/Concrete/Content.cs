using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TourP.Core.Entities;

namespace TourP.Entities.Concrete
{
    public class Content:IEntity
    {
        public int Id { get; set; }
        public string ContentDescription { get; set; }
        [JsonIgnore]
        public Ads Ads { get; set; }
        public int AdsId { get; set; }
    }
}
