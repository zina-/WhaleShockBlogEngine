using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                var bytes = rsa.Encrypt(Convert.FromBase64String("8OTC92xYkW7CWPJGhRvqCR0U1CR6L8PhhpRGGxgW4Ts="), false);
                var byteString = Convert.ToBase64String(bytes);

                var dec = rsa.Decrypt(bytes, false);
                var decString = Convert.ToBase64String(dec);
            }
        }
    }
}
