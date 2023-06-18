using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SecurityService
    {
        public SecurityService()
        {

        }
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            StringBuilder hashedPassword = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashedPassword.Append(hashBytes[i].ToString("x2"));
            }

            return hashedPassword.ToString();
        }
    }
}
