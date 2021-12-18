using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourP.Core.Entities;

namespace TourP.Entities.DTOs.AdsDTO
{
    public class AdsAddDto:IDto
    {
        public string Title { get; set; }
        public int CookingTime { get; set; }
        public int MaxCalory { get; set; }
        public int MinCalory { get; set; }
        public int Difficulty { get; set; }
    }
}
