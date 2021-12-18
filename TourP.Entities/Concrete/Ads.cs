using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TourP.Core.Entities;

namespace TourP.Entities.Concrete
{
    public class Ads:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CookingTime { get; set; }
        public int MaxCalory { get; set; }
        public int MinCalory { get; set; }
        public int Difficulty { get; set; }
        [JsonIgnore]
        public Entry Entry { get; set; }
        [JsonIgnore]
        public List<Content> Content { get; set; }
        [JsonIgnore]
        public List<Steps> Steps { get; set; }
    }
}
