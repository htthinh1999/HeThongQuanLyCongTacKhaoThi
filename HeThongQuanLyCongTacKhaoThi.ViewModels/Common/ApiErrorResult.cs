using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Common
{
    public class ApiErrorResult<T>: ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }
        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }
    }
}
