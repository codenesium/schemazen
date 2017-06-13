using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaZen.Library
{
    public class ExecutionResponse
    {
        public Exception Exception { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public ExecutionResponse(bool success, string messsage = "", Exception exception = null)
        {
            this.Success = success;
            this.Message = messsage;
            this.Exception = exception;
        }
    }
}
