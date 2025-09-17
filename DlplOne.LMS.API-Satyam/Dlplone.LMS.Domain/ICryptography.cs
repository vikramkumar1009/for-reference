namespace Dlplone.LMS.Domain
{
    public interface ICryptography
    {
        string Encrypt(string plainText);
        string Decrypt(string encryptedText);
        string DecryptStringAES(string cipherText);
        string EncryptStringAES(string plainText);
    }
}
