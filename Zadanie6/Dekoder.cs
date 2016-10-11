using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder
{
    public class Dekoder : IDecoder
    {
        public new static IDecoder GetInstance()
        {
            decoderInstance = new Dekoder();
            return decoderInstance;
        }

        public override Result decode(long value, string alphabet)
        {
            var s = new List<int>();
            var n = 0;
            while (value > 3 && s.Count < 12 && n++ < 12)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if ((value - i) % 29 == 0)
                    {
                        value = (value - i) / 29;
                        s.Insert(0, i);
                        break;
                    }
                }
            }
            var success = value == 3 ?
                ResultCode.SUCCESS :
                ResultCode.FAILURE;
            var text = new String(
                s.Select(i => alphabet[i])
                .ToArray());
            if (success == ResultCode.FAILURE) text = string.Empty;
            return new Result(
                decodedText: text,
                codeResult: success);
        }

        public static long code(string what, string alphabet)
        {
            long value = 3;
            for (int i = 0; i < what.Count(); i++)
            {
                value = value * 29 + alphabet.IndexOf(what[i]);
            }
            return value;
        }
    }
}
