using System;
using System.Security.Cryptography;
using System.Text;

namespace Exam70483.DebugAppsAndImplementSecurity.Encryption.Symmetric
{
    // Symmetic algorithms uses the same secret key for both encryption / decryption
    // The primary attack against them is a brute force key search
    // Key distribution and storage is difficult
    // Advanced Encryption Standard (AES) is a US government standard since 2001
    // and is supported by many encryption libraries, platforms, languages.
    // AES uses the Rijndael algorithm, with 128 bit block size

    // Other common symmetric algorithms include,
    // the following are all based on the abstract class, SymmetricAlgorithm:
    // Rijndael/AES
    // Triple DES
    // DES
    // RC2

    // .NET symmetric algorithms are "block ciphers".
    // This means that the algorithm takes the plain text data and encrypts
    // it in fix sized blocks, in AES's case, 128 bit blocks.
    // 256 is the highest key size for Rijndael. Use highest available.
    // However use 128bit to be AES compliant.
    // i.e. - the algorithm is applied to each block.
    // If the length of the plain text data does not divide evenly by the block size 
    // blocks laying at the bit boundary must be padded to the correct size. 

    // There are various means of block padding:
    // Zeros - fill the block out with 0's.
    // PKCS7 - the number of bits remaining is used to fill out the remaining spots.
    // ISO10126 (recommended) - uses random data

    // In general, the more random data you can add the better for security,
    // rather than have something like zeros that are a set number.

    // Block ciphers also have modes:
    // ECB - take each block and encrypt it independantly of the others
    // CBC (recommended) - uses value of previous block as input to algorithm
    //                   - IV (Initialization Vector)
    //                   - With CBC because there is no previous block for the
    //                   - first block to be encrypted with, you supply random
    //                   - data to seed it with, the Initialization Vector.
    //                   - This does not need to be secret, but should be different
    //                   - for every set of data. Never reuse an IV.
    //                   - Send both cipher text and IV to decrypt.
    public class SymmetricAlgorithms
    {
        private const string TwoFiveSixBitBase64Key = "lU63r8YTfiUyhEgpjZNqA6cOjww50Rb1/jA9pSTnKPw=";

        public EncryptionResult Encrypt(string plainText)
        {
            var cipher = new AES(TwoFiveSixBitBase64Key).Cipher();

            // RijndaelManaged class will create a random IV
            var ivEncoded = Convert.ToBase64String(cipher.IV);

            // create the encryptor, convert to bytes and encrypt
            var cryptTransform = cipher.CreateEncryptor();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var cipherTextBytes = cryptTransform.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
            var cipherEncoded = Convert.ToBase64String(cipherTextBytes);

            return new EncryptionResult(cipherEncoded, ivEncoded);
        }

        public string Decrypt(string cipherText, string initializationVector)
        {
            // must use same settings as original cipher
            var cipher = new AES(TwoFiveSixBitBase64Key).Cipher();

            cipher.IV = Convert.FromBase64String(initializationVector);
            var crypTransform = cipher.CreateDecryptor();
            var cipherTextBytes = Convert.FromBase64String(cipherText);
            var plainTextBytes = crypTransform.TransformFinalBlock(cipherTextBytes, 0, cipherTextBytes.Length);

            return Encoding.UTF8.GetString(plainTextBytes);
        }

        private string GenerateKey()
        {
            var rng = new RNGCryptoServiceProvider();
            var keyBytes = new byte[32]; // size for 256 bit key, 32 * 8 = 256bits
            rng.GetBytes(keyBytes);
            return Convert.ToBase64String(keyBytes);
        }
    }

    public struct EncryptionResult
    {
        public readonly string CipherText;
        public readonly string IV;

        public EncryptionResult(string cipherText, string iv)
        {
            CipherText = cipherText;
            IV = iv;
        }
    }
}