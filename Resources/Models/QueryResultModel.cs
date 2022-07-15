using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.Models
{
    public class QueryResultModel
    {
        public DataTableCollection? Tables { get; set; }
        public string? Error { get; set; }
    }
}
