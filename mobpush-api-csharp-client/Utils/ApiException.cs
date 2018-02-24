using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobpush.api.client
{
    [Serializable]
    public class ApiException : ApplicationException
    {
        /**
	     * status: HTTP状态码
	     */
        public int status { get; set; }

        /**
         * errorMessage: 错误信息
         */
        public string errorMessage { get; set; }

        /**
         * errorCode: 错误状态码
         */
        public int errorCode { get; set; }

        public ApiException() { }

        public ApiException(int status, int errorCode, String errorMessage)  : base(errorMessage)
        { 
            this.status = status;
            this.errorCode = errorCode;
            this.errorMessage = errorMessage;
        }

    }
}
