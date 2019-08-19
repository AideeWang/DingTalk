using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DingTalkSync.DTO
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            this.IsSuccess = true;
        }

        public BaseResponse(object Data)
        {
            if (Data == null)
            {
                this.IsSuccess = false;
            }
            else
            {
                this.IsSuccess = true;
                this.Result = Data;
            }
        }
        public BaseResponse(string Message)
        {
            this.Message = Message;
            this.IsSuccess = false;
        }
        
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public string ResultJson {get;set;}
    }
}
