using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Domain.Services.Communication
{
    public abstract class BaseResponse
    {
        public bool success { get; set; }
        public string message { get; set; }

        public BaseResponse(bool Success, string Message)
        {
            this.success = Success;
            this.message = Message;
        }
    }
}