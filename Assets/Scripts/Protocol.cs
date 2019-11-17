using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FUMBBL
{
    public class Protocol
    {
        public bool Compression { get; }

        public Protocol(bool compression)
        {
            this.Compression = compression;
        }

        public string Test(String s)
        {
            return LZString.compressToUTF16(s);
        }

        public string Compress(string data)
        {
            if (Compression)
            {
                return LZString.compressToUTF16(data);
            }

            return data;
        }

        public string Decompress(string data)
        {
            if (Compression)
            {
                return LZString.decompressFromUTF16(data);
            }
            return data;

        }


        /**
         * LZString Java Implementation by diogoduailibe. source
         * https://github.com/diogoduailibe/lzstring4j
         * 
         * Based on JavaScript lz-string by pieroxy source
         * http://pieroxy.net/blog/pages/lz-string/index.html
         */
        class LZString
        {
            public static String compress(String uncompressed)
            {

                if (uncompressed == null)
                    return "";
                int value;
                Dictionary<string, int> context_dictionary = new Dictionary<string, int>();
                HashSet<string> context_dictionaryToCreate = new HashSet<string>();
                string context_c = "";
                string context_wc = "";
                string context_w = "";
                double context_enlargeIn = 2d; // Compensate for the first entry which
                                               // should not count
                int context_dictSize = 3;
                int context_numBits = 2;
                String context_data_string = "";
                int context_data_val = 0;
                int context_data_position = 0;

                for (int ii = 0; ii < uncompressed.Length; ii += 1)
                {
                    context_c = "" + (uncompressed[ii]);
                    if (!context_dictionary.ContainsKey(context_c))
                    {
                        context_dictionary[context_c] = context_dictSize++;
                        context_dictionaryToCreate.Add(context_c);
                    }

                    context_wc = context_w + context_c;

                    if (context_dictionary.ContainsKey(context_wc))
                    {
                        context_w = context_wc;
                    }
                    else
                    {
                        if (context_dictionaryToCreate.Contains(context_w))
                        {

                            if (((int)context_w[0]) < 256)
                            {
                                for (int i = 0; i < context_numBits; i++)
                                {
                                    context_data_val = (context_data_val << 1);
                                    if (context_data_position == 15)
                                    {
                                        context_data_position = 0;
                                        context_data_string += (char)context_data_val;
                                        context_data_val = 0;
                                    }
                                    else
                                    {
                                        context_data_position++;
                                    }
                                }
                                value = (int)context_w[0];
                                for (int i = 0; i < 8; i++)
                                {
                                    context_data_val = (context_data_val << 1) | (value & 1);
                                    if (context_data_position == 15)
                                    {
                                        context_data_position = 0;
                                        context_data_string += (char)context_data_val;
                                        context_data_val = 0;
                                    }
                                    else
                                    {
                                        context_data_position++;
                                    }
                                    value = value >> 1;
                                }
                            }
                            else
                            {
                                value = 1;
                                for (int i = 0; i < context_numBits; i++)
                                {
                                    context_data_val = (context_data_val << 1) | value;
                                    if (context_data_position == 15)
                                    {
                                        context_data_position = 0;
                                        context_data_string += (char)context_data_val;
                                        context_data_val = 0;
                                    }
                                    else
                                    {
                                        context_data_position++;
                                    }
                                    value = 0;
                                }
                                value = (int)context_w[0];
                                for (int i = 0; i < 16; i++)
                                {
                                    context_data_val = (context_data_val << 1) | (value & 1);
                                    if (context_data_position == 15)
                                    {
                                        context_data_position = 0;
                                        context_data_string += (char)context_data_val;
                                        context_data_val = 0;
                                    }
                                    else
                                    {
                                        context_data_position++;
                                    }
                                    value = value >> 1;
                                }
                            }
                            context_enlargeIn--;
                            if (((int)context_enlargeIn) == 0)
                            {
                                context_enlargeIn = Math.Pow(2, context_numBits);
                                context_numBits++;
                            }
                            context_dictionaryToCreate.Remove(context_w);
                        }
                        else
                        {
                            value = context_dictionary[context_w];
                            for (int i = 0; i < context_numBits; i++)
                            {
                                context_data_val = (context_data_val << 1) | (value & 1);
                                if (context_data_position == 15)
                                {
                                    context_data_position = 0;
                                    context_data_string += (char)context_data_val;
                                    context_data_val = 0;
                                }
                                else
                                {
                                    context_data_position++;
                                }
                                value = value >> 1;
                            }

                        }
                        context_enlargeIn--;
                        if (((int)context_enlargeIn) == 0)
                        {
                            context_enlargeIn = Math.Pow(2, context_numBits);
                            context_numBits++;
                        }
                        // Add wc to the dictionary.
                        context_dictionary[context_wc] = context_dictSize++;
                        context_w = context_c;
                    }
                }

                // Output the code for w.
                if (!"".Equals(context_w))
                {
                    if (context_dictionaryToCreate.Contains(context_w))
                    {
                        if (((int)context_w[0]) < 256)
                        {
                            for (int i = 0; i < context_numBits; i++)
                            {
                                context_data_val = (context_data_val << 1);
                                if (context_data_position == 15)
                                {
                                    context_data_position = 0;
                                    context_data_string += (char)context_data_val;
                                    context_data_val = 0;
                                }
                                else
                                {
                                    context_data_position++;
                                }
                            }
                            value = (int)context_w[0];
                            for (int i = 0; i < 8; i++)
                            {
                                context_data_val = (context_data_val << 1) | (value & 1);
                                if (context_data_position == 15)
                                {
                                    context_data_position = 0;
                                    context_data_string += (char)context_data_val;
                                    context_data_val = 0;
                                }
                                else
                                {
                                    context_data_position++;
                                }
                                value = value >> 1;
                            }
                        }
                        else
                        {
                            value = 1;
                            for (int i = 0; i < context_numBits; i++)
                            {
                                context_data_val = (context_data_val << 1) | value;
                                if (context_data_position == 15)
                                {
                                    context_data_position = 0;
                                    context_data_string += (char)context_data_val;
                                    context_data_val = 0;
                                }
                                else
                                {
                                    context_data_position++;
                                }
                                value = 0;
                            }
                            value = (int)context_w[0];
                            for (int i = 0; i < 16; i++)
                            {
                                context_data_val = (context_data_val << 1) | (value & 1);
                                if (context_data_position == 15)
                                {
                                    context_data_position = 0;
                                    context_data_string += (char)context_data_val;
                                    context_data_val = 0;
                                }
                                else
                                {
                                    context_data_position++;
                                }
                                value = value >> 1;
                            }
                        }
                        context_enlargeIn--;
                        if ((int)context_enlargeIn == 0)
                        {
                            context_enlargeIn = Math.Pow(2, context_numBits);
                            context_numBits++;
                        }
                        context_dictionaryToCreate.Remove(context_w);
                    }
                    else
                    {
                        value = context_dictionary[context_w];
                        for (int i = 0; i < context_numBits; i++)
                        {
                            context_data_val = (context_data_val << 1) | (value & 1);
                            if (context_data_position == 15)
                            {
                                context_data_position = 0;
                                context_data_string += (char)context_data_val;
                                context_data_val = 0;
                            }
                            else
                            {
                                context_data_position++;
                            }
                            value = value >> 1;
                        }

                    }
                    context_enlargeIn--;
                    if ((int)context_enlargeIn == 0)
                    {
                        context_enlargeIn = Math.Pow(2, context_numBits);
                        context_numBits++;
                    }
                }

                // Mark the end of the stream
                value = 2;
                for (int i = 0; i < context_numBits; i++)
                {
                    context_data_val = (context_data_val << 1) | (value & 1);
                    if (context_data_position == 15)
                    {
                        context_data_position = 0;
                        context_data_string += (char)context_data_val;
                        context_data_val = 0;
                    }
                    else
                    {
                        context_data_position++;
                    }
                    value = value >> 1;
                }

                // Flush the last char
                while (true)
                {
                    context_data_val = (context_data_val << 1);
                    if (context_data_position == 15)
                    {
                        context_data_string += (char)context_data_val;
                        break;
                    }
                    else
                        context_data_position++;
                }
                return context_data_string;
            }

            public static String decompress(String compressed)
            {

                if (compressed == null)
                    return "";
                if (compressed == "")
                    return null;
                List<String> dictionary = new List<string>(200);
                double enlargeIn = 4;
                int dictSize = 4;
                int numBits = 3;
                String entry = "";
                StringBuilder result;
                String w;
                int bits;
                int resb;
                double maxpower;
                int power;
                String c = "";
                int d;
                Data data = Data.getInstance();
                data.data = compressed;
                data.val = (int)compressed[0];
                data.position = 32768;
                data.index = 1;

                for (int i = 0; i < 3; i += 1)
                {
                    dictionary.Insert(i, "");
                }

                bits = 0;
                maxpower = Math.Pow(2, 2);
                power = 1;
                while (power != (int)maxpower)
                {
                    resb = data.val & data.position;
                    data.position >>= 1;
                    if (data.position == 0)
                    {
                        data.position = 32768;
                        data.val = (int)data.data[data.index++];
                    }
                    bits |= (resb > 0 ? 1 : 0) * power;
                    power <<= 1;
                }

                switch (bits)
                {
                    case 0:
                        bits = 0;
                        maxpower = Math.Pow(2, 8);
                        power = 1;
                        while (power != (int)maxpower)
                        {
                            resb = data.val & data.position;
                            data.position >>= 1;
                            if (data.position == 0)
                            {
                                data.position = 32768;
                                data.val = (int)data.data[data.index++];
                            }
                            bits |= (resb > 0 ? 1 : 0) * power;
                            power <<= 1;
                        }
                        c += (char)bits;
                        break;
                    case 1:
                        bits = 0;
                        maxpower = Math.Pow(2, 16);
                        power = 1;
                        while (power != (int)maxpower)
                        {
                            resb = data.val & data.position;
                            data.position >>= 1;
                            if (data.position == 0)
                            {
                                data.position = 32768;
                                data.val = (int)data.data[data.index++];
                            }
                            bits |= (resb > 0 ? 1 : 0) * power;
                            power <<= 1;
                        }
                        c += (char)bits;
                        break;
                    case 2:
                        return "";

                }

                dictionary.Insert(3, c);
                w = c;
                result = new StringBuilder(200);
                result.Append(c);

                // w = result = c;

                while (true)
                {
                    if (data.index > data.data.Length)
                    {
                        return "";
                    }

                    bits = 0;
                    maxpower = Math.Pow(2, numBits);
                    power = 1;
                    while (power != (int)maxpower)
                    {
                        resb = data.val & data.position;
                        data.position >>= 1;
                        if (data.position == 0)
                        {
                            data.position = 32768;
                            data.val = (int)data.data[data.index++];
                        }
                        bits |= (resb > 0 ? 1 : 0) * power;
                        power <<= 1;
                    }

                    switch (d = bits)
                    {
                        case 0:
                            bits = 0;
                            maxpower = Math.Pow(2, 8);
                            power = 1;
                            while (power != (int)maxpower)
                            {
                                resb = data.val & data.position;
                                data.position >>= 1;
                                if (data.position == 0)
                                {
                                    data.position = 32768;
                                    data.val = (int)data.data[data.index++];
                                }
                                bits |= (resb > 0 ? 1 : 0) * power;
                                power <<= 1;
                            }

                            String temp = "";
                            temp += (char)bits;
                            dictionary.Insert(dictSize++, temp);

                            d = dictSize - 1;

                            enlargeIn--;

                            break;
                        case 1:
                            bits = 0;
                            maxpower = Math.Pow(2, 16);
                            power = 1;
                            while (power != (int)maxpower)
                            {
                                resb = data.val & data.position;
                                data.position >>= 1;
                                if (data.position == 0)
                                {
                                    data.position = 32768;
                                    data.val = (int)data.data[data.index++];
                                }
                                bits |= (resb > 0 ? 1 : 0) * power;
                                power <<= 1;
                            }

                            temp = "";
                            temp += (char)bits;

                            dictionary.Insert(dictSize++, temp);

                            d = dictSize - 1;

                            enlargeIn--;

                            break;
                        case 2:
                            return result.ToString();
                    }

                    if ((int)enlargeIn == 0)
                    {
                        enlargeIn = Math.Pow(2, numBits);
                        numBits++;
                    }

                    if (d < dictionary.Count && dictionary[d] != null)
                    {
                        entry = dictionary[d];
                    }
                    else
                    {
                        if (d == dictSize)
                        {
                            entry = w + w[0];
                        }
                        else
                        {
                            return null;
                        }
                    }

                    result.Append(entry);

                    // Add w+entry[0] to the dictionary.
                    dictionary.Insert(dictSize++, w + entry[0]);
                    enlargeIn--;

                    w = entry;

                    if ((int)enlargeIn == 0)
                    {
                        enlargeIn = Math.Pow(2, numBits);
                        numBits++;
                    }

                }
            }

            public static String compressToUTF16(String input)
            {
                if (input == null)
                    return "";
                String output = "";
                int c;
                int current = 0;
                int status = 0;

                input = LZString.compress(input);

                for (int i = 0; i < input.Length; i++)
                {
                    c = (int)input[i];
                    switch (status++)
                    {
                        case 0:
                            output += (char)((c >> 1) + 32);
                            current = (c & 1) << 14;
                            break;
                        case 1:
                            output += (char)((current + (c >> 2)) + 32);
                            current = (c & 3) << 13;
                            break;
                        case 2:
                            output += (char)((current + (c >> 3)) + 32);
                            current = (c & 7) << 12;
                            break;
                        case 3:
                            output += (char)((current + (c >> 4)) + 32);
                            current = (c & 15) << 11;
                            break;
                        case 4:
                            output += (char)((current + (c >> 5)) + 32);
                            current = (c & 31) << 10;
                            break;
                        case 5:
                            output += (char)((current + (c >> 6)) + 32);
                            current = (c & 63) << 9;
                            break;
                        case 6:
                            output += (char)((current + (c >> 7)) + 32);
                            current = (c & 127) << 8;
                            break;
                        case 7:
                            output += (char)((current + (c >> 8)) + 32);
                            current = (c & 255) << 7;
                            break;
                        case 8:
                            output += (char)((current + (c >> 9)) + 32);
                            current = (c & 511) << 6;
                            break;
                        case 9:
                            output += (char)((current + (c >> 10)) + 32);
                            current = (c & 1023) << 5;
                            break;
                        case 10:
                            output += (char)((current + (c >> 11)) + 32);
                            current = (c & 2047) << 4;
                            break;
                        case 11:
                            output += (char)((current + (c >> 12)) + 32);
                            current = (c & 4095) << 3;
                            break;
                        case 12:
                            output += (char)((current + (c >> 13)) + 32);
                            current = (c & 8191) << 2;
                            break;
                        case 13:
                            output += (char)((current + (c >> 14)) + 32);
                            current = (c & 16383) << 1;
                            break;
                        case 14:
                            output += (char)((current + (c >> 15)) + 32);
                            output += (char)((c & 32767) + 32);

                            status = 0;
                            break;
                    }
                }

                output += (char)(current + 32);

                return output;
            }

            public static String decompressFromUTF16(String input)
            {
                if (input == null)
                    return "";
                StringBuilder output = new StringBuilder(200);
                int current = 0, c, status = 0, i = 0;

                while (i < input.Length)
                {
                    c = (((int)input[i]) - 32);

                    switch (status++)
                    {
                        case 0:
                            current = c << 1;
                            break;
                        case 1:
                            output.Append((char)(current | (c >> 14)));
                            current = (c & 16383) << 2;
                            break;
                        case 2:
                            output.Append((char)(current | (c >> 13)));
                            current = (c & 8191) << 3;
                            break;
                        case 3:
                            output.Append((char)(current | (c >> 12)));
                            current = (c & 4095) << 4;
                            break;
                        case 4:
                            output.Append((char)(current | (c >> 11)));
                            current = (c & 2047) << 5;
                            break;
                        case 5:
                            output.Append((char)(current | (c >> 10)));
                            current = (c & 1023) << 6;
                            break;
                        case 6:
                            output.Append((char)(current | (c >> 9)));
                            current = (c & 511) << 7;
                            break;
                        case 7:
                            output.Append((char)(current | (c >> 8)));
                            current = (c & 255) << 8;
                            break;
                        case 8:
                            output.Append((char)(current | (c >> 7)));
                            current = (c & 127) << 9;
                            break;
                        case 9:
                            output.Append((char)(current | (c >> 6)));
                            current = (c & 63) << 10;
                            break;
                        case 10:
                            output.Append((char)(current | (c >> 5)));
                            current = (c & 31) << 11;
                            break;
                        case 11:
                            output.Append((char)(current | (c >> 4)));
                            current = (c & 15) << 12;
                            break;
                        case 12:
                            output.Append((char)(current | (c >> 3)));
                            current = (c & 7) << 13;
                            break;
                        case 13:
                            output.Append((char)(current | (c >> 2)));
                            current = (c & 3) << 14;
                            break;
                        case 14:
                            output.Append((char)(current | (c >> 1)));
                            current = (c & 1) << 15;
                            break;
                        case 15:
                            output.Append((char)(current | c));

                            status = 0;
                            break;
                    }

                    i++;
                }

                return LZString.decompress(output.ToString());
                // return output;

            }
        }

        class Data
        {
            public int val;
            public string data;
            public int position;
            public int index;

            public static Data getInstance()
            {
                return new Data();
            }

        }

    }
}
