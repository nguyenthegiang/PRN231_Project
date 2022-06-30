using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace WebAPI.Helper
{
    public static class Hashing
    {
        public static string Encrypt(string raw)
        {
            using var crypt = SHA256.Create();
            byte[] bytes = crypt.ComputeHash(Encoding.UTF8.GetBytes(raw));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
	}
}
