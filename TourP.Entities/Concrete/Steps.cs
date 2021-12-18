using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TourP.Core.Entities;

namespace TourP.Entities.Concrete
{
    public class Steps:IEntity
    {
        public int Id { get; set; }
        public string StepTitle { get; set; }
        public string StepDescription { get; set; }
        [JsonIgnore]
        public Ads Ads { get; set; }
        public int AdsId { get; set; }
    }
}
