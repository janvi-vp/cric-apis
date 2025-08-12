using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static cric_api.DTOs.Utilities.Enums;

namespace cric_api.DTOs.Utilities
{
    public class SortingRequest : ISortingRequest
    {
        public virtual SortDirection SortDirection { get; set; } = SortDirection.ASC;
        public virtual string SortByColumn { get; set; } = "Id";
    }
}
