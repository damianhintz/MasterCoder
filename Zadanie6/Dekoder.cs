using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var decodedText = string.Empty;
            var countLetters = 0;
            while (value > 3 && countLetters++ < 12)
            {
                var index = FindLetterIndex(value, alphabet);
                if (index < 0) break; //failure
                value = (value - index) / 29;
                decodedText = alphabet[index] + decodedText; //build text
            }
            if (value == 3) return new Result(decodedText, ResultCode.SUCCESS);
            else return new Result(string.Empty, ResultCode.FAILURE);
        }

        int FindLetterIndex(long value, string alphabet)
        {
            for (int i = 0; i < alphabet.Length; i++)
                if ((value - i) % 29 == 0)
                    return i;
            return -1;
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
