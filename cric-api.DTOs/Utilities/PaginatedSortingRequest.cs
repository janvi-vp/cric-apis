using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static cric_api.DTOs.Utilities.Enums;

namespace cric_api.DTOs.Utilities
{
    public class PaginatedSortingRequest : IPaginationRequest, ISortingRequest
    {
        public virtual SortDirection SortDirection { get; set; } = SortDirection.ASC;
        public virtual string SortByColumn { get; set; } = "Id";
        public virtual int PageNumber { get; set; } = 1;
        public virtual int PageSize { get; set; } = 20;
    }
}
