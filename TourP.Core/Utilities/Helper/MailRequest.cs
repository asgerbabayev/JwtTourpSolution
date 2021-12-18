using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourP.Core.Utilities.Helper
{
    public class MailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public bool IsHtmlBody { get; set; }
        public string Content { get; set; }
    }
}
