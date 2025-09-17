using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Dlplone.LMS.Domain.Infrastructure.Utils
{
    public class GenHashSalt
    {
        public bool CheckHashSalt(string hash, string salt, string username, string userpassword, string invoicecode)
        {
            bool status = false;


            if (hash != "" && salt != "")
            {
                status = DecodeHashSalt(userpassword, hash, salt);
            }

            return status;
        }

        private bool DecodeHashSalt(string userpassword, string oldhash, string salt)
        {
            string newHS = GenerateHash(userpassword, salt);
            bool x = newHS.Equals(oldhash);
            return x;
        }

        public string CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
