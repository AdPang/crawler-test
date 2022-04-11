using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Parameter
{
    public class RequestParameter
    {
        public int total { get; set; }
        public int _page { get; set; }
        public int _limit { get; set; }
        public string? UniversityId { get; set; }
        public string? MajorId { get; set; }
        public string? ApplyRate { get; set; }
    }
}
