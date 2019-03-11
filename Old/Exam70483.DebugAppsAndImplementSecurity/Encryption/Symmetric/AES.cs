using System;
using System.Security.Cryptography;

namespace Exam70483.DebugAppsAndImplementSecurity.Encryption.Symmetric
{
    public class AES
    {
        private readonly string _key;

        public AES(string key)
        {
            _key = key;
        }

        public RijndaelManaged Cipher()
        {
            var cipher = new RijndaelManaged
            {
                KeySize = 256, // use 128 bit to be AES compliant
                BlockSize = 256, // pad with random data
                Padding = PaddingMode.ISO10126, // use cipher text of previous block
                Mode = CipherMode.CBC
            };

            // do not use:
            // cipher.Padding = PaddingMode.Zeros;
            // cipher.Mode = CipherMode.ECB;

            // one of the central problems of symmetric encryption is that the key
            // must remain secret, so how it is stored and preventing other gaining
            // access is highly important.
            cipher.Key = Convert.FromBase64String(_key);

            return cipher;
        }
    }
}