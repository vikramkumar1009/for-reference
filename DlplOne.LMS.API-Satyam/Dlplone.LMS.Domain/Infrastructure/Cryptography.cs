using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace Dlplone.LMS.Domain.Infrastructure
{
    public class Cryptography : ICryptography
    {
        private readonly string securityKey = string.Empty;
        private readonly string cryptoKey = string.Empty;
        public Cryptography(IConfiguration configuration)
        {
            securityKey = configuration["SecurityKey"];
            cryptoKey = configuration["CryptoKey"];
        }
        public string Encrypt(string plainText)
        {
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(plainText);

            var md5 = MD5.Create();
            byte[] securityKeyArray = md5.ComputeHash(Encoding.UTF8.GetBytes(securityKey));
            md5.Clear();
            var tripleDes =  TripleDES.Create();
            tripleDes.Key = securityKeyArray;
            tripleDes.Mode = CipherMode.ECB;
            tripleDes.Padding = PaddingMode.PKCS7;
            var objCrytpoTransform = tripleDes.CreateEncryptor();
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            tripleDes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }
        public string Decrypt(string encryptedText)
        {
            byte[] toEncryptArray = Convert.FromBase64String(encryptedText);
            var md5 =  MD5.Create();
            byte[] securityKeyArray = md5.ComputeHash(Encoding.UTF8.GetBytes(securityKey));
            md5.Clear();
            var tripleDes =  TripleDES.Create();
            tripleDes.Key = securityKeyArray;
            tripleDes.Mode = CipherMode.ECB;
            tripleDes.Padding = PaddingMode.PKCS7;
            var objCrytpoTransform = tripleDes.CreateDecryptor();
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tripleDes.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }


        public  string DecryptStringAES(string cipherText)
        {
            var keybytes = Encoding.UTF8.GetBytes(cryptoKey);
            var iv = Encoding.UTF8.GetBytes(cryptoKey);

            var encrypted = Convert.FromBase64String(cipherText);
            var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
            return decriptedFromJavascript;
        }

        public  string EncryptStringAES(string plainText)
        {
            var keybytes = Encoding.UTF8.GetBytes(cryptoKey);
            var iv = Encoding.UTF8.GetBytes(cryptoKey);

            var encryoFromJavascript = EncryptStringToBytes(plainText, keybytes, iv);
            return Convert.ToBase64String(encryoFromJavascript);
        }

        private  byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            byte[] encrypted;
            // Create a RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
        private  string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                try
                {
                    // Create the streams used for decryption.
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {

                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();

                            }

                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }

            return plaintext;
        }
    }
}
