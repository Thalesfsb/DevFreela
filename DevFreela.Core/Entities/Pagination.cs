using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class Pagination
    {
        public Pagination(string search, int size, int page)
        {
            Search = search;
            Size = size;
            Page = page;
        }

        public string? Search { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
    }
}
