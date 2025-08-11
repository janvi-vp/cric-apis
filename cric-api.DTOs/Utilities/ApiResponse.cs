using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cric_api.DTOs.Utilities
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }

        private ApiResponse(T data, bool success, string error)
        {
            Data = data;
            Success = success;
            Error = error;
        }

        public static ApiResponse<T> Ok(T data)
        {
            return new ApiResponse<T>(data, true, null);
        }

        public static ApiResponse<T> Fail(string error)
        {
            return new ApiResponse<T>(default, false, error);
        }
    }
}