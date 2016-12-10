using System.IO;
using System.Security.Cryptography;

namespace Exam70483.DebugAppsAndImplementSecurity.Encryption.Symmetric
{

    // Can use the CryptoStream class to combine multiple encryptions
    public class UsingCryptoStream
    {
        private const string TwoFiveSixBitBase64Key = "lU63r8YTfiUyhEgpjZNqA6cOjww50Rb1/jA9pSTnKPw=";

        public void Main()
        {
            var cipher = new AES(TwoFiveSixBitBase64Key).Cipher();            

            // Create file stream
            var cipherFile = new FileStream(@"C:\", FileMode.Create, FileAccess.Write);

            // Create the base64 transform
            ICryptoTransform base64Transform = new ToBase64Transform();

            // Create the encryption algorithm
            ICryptoTransform cipherTransform = cipher.CreateEncryptor();

            // Create a CryptoStream with base64 above file stream
            CryptoStream firstCryptoStream = new CryptoStream(cipherFile, base64Transform, CryptoStreamMode.Write);

            // Create a CryptoStream with encryption on top of existing chained stream
            CryptoStream secondCryptoStream = new CryptoStream(firstCryptoStream, cipherTransform, CryptoStreamMode.Write);

            // Close the streams
            secondCryptoStream.Close();
            firstCryptoStream.Close();
            cipherFile.Close();
        }
    }
}