using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static cric_api.DTOs.Utilities.Enums;

namespace cric_api.DTOs.Utilities
{
    public interface ISortingRequest
    {
        public SortDirection SortDirection { get; set; }
        public string SortByColumn { get; set; }
    }

}
