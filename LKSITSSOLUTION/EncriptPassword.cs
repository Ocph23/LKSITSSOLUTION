using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LKSITSSOLUTION
{
    public class EncriptPassword
    {
        public static string CreatePasswordHash(string pwd)
        {
            var inputByte = Encoding.UTF8.GetBytes(pwd);
            StringBuilder stringBuilder = new StringBuilder();
            using (var sha = new SHA256Managed())
            {
                var byteHash = sha.ComputeHash(inputByte);

                foreach (var item in byteHash)
                {
                    stringBuilder.Append($"{item:x2}");
                }
            }
            return stringBuilder.ToString();
        }

    }
}
