using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder
{
    public enum ResultCode
    {
        SUCCESS, FAILURE
    }

    public class Result
    {
        public string DecodedText { get; set; }
        public ResultCode CodeResult { get; set; }

        public Result(string decodedText, ResultCode codeResult)
        {
            this.DecodedText = decodedText;
            this.CodeResult = codeResult;
        }
    }

}
