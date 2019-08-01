using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBill.Common
{
    public class ApiResponse<T>
    {
        public int Code { get; set; } = 0;
        public string Message { get; set; } = "No Records Found";
        public T Data { get; set; }
    }
}
