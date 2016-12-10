using System;
using System.Security.Cryptography;
using System.Text;

namespace Exam70483.DebugAppsAndImplementSecurity.Encryption.Asymmetric
{
    // Asymmetric algorithms are also called "public key" cryptography.
    // Utilizes two complimentary keys (public and private key).
    // Generally 100 to 1,000 times slower than symmetric algorithms.
    // Often use asymmetric to encrypt a "session" symmetric key.

    /*
     *           Receiver's Public Key         Receiver's Private Key
     *                     |                              |
     *                ____\|/_____                   ____\|/_____ 
     *  Plaintext -> [ Encryption ] - Ciphertext -> [ Decryption ] - Plaintext
     *                ------------                   ------------ 
     */

    // In .NET the abstract clas AsymmetricAlgorithm is used.
    // Implementations include:
    // - RSA
    // - DSA (digital signatures only)
    // - ECDiffieHellman

    // Website Encrypting Safely
    // Generate an RSA key pair
    // - Store only the public key on web servers, can share this with anyone as
    //   this is what consumers will use to encrypt data. Data is decrypted with
    //   the private key which is kept safe internally.
    //
    // - Put private key on an internal secured system behind a firewall, store the
    //   private key only where the system needs to decrypt the data.
    //
    // Encrypt / decrypt directly using RSA for small amounts of data.
    //
    // Encrypt / decrypt with a symmetric key for large amounts of data.
    // - Symmetric encryption is much faster than asymmetric.
    // - Generate a new symmetric key on the fly, and use asymmetric and use the
    //   asymmetric to encrypt that key. Then use the symmetric key to encrypt.
    //
    // Create RSA key store with aspnet_regiis
    // - Create key container
    //   aspnet_regiis -pc "KeyContainerName" -exp
    //
    // - Export the public key
    //   aspnet_regiis -px "KeyContainerName" "C:\PublicKey.xml"
    //
    // - Export both public and private keys
    //   aspnet_regiis -px "KeyContainerName" "C:\PublicPrivateKeys.xml" -pri
    //
    // Asymmetric Algorithms Summary
    // - Provide confidentiality
    // - Use a public / private key pair
    // - They are slow
    // - Often used to encrypt a symmetric "session" key
    // - Key distribution can be problematic
    //   - There are potential issues with public key integrity.
    //   - If someone were to post their public key and have consumers use it to
    //     encrypt their data, they are then at risk if an attacker gains access
    //     to where the public key was published and replaces the original key
    //     with their own public key.
    //   - How can you be confident it is the correct public key to be using?
    public class AsymmetricAlgorithms
    {

        // Generate with aspnet_regiis
        private const string RSA_PUBLIC_KEY = "<RSAKeyValue><Modulus>ntyQv52ee2CeOYkMa7wXEBuqfyAlO6iZFHcR9/KEsBbfBhtMFEVoDPpSzV4J96U/+R9x+lyhvnFJ6RvjzpFDiW1/RyiNdKTmNZzXFXW6ruuojieEpF/dKsqI0ZGxelqnjGgWPO6oLh1xt7d9iMAJf70ZstABNXLMCoOAmI0tUOM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        private const string RSA_KEYS =
            "<RSAKeyValue><Modulus>ntyQv52ee2CeOYkMa7wXEBuqfyAlO6iZFHcR9/KEsBbfBhtMFEVoDPpSzV4J96U/+R9x+lyhvnFJ6RvjzpFDiW1/RyiNdKTmNZzXFXW6ruuojieEpF/dKsqI0ZGxelqnjGgWPO6oLh1xt7d9iMAJf70ZstABNXLMCoOAmI0tUOM=</Modulus><Exponent>AQAB</Exponent><P>33NvieAmWdbXzYqFui9TgEin770TF1hvj2MoLTU8jXBe+Rii+Te2spI9x42EI3L684SnydoSVN3iNxL4lOzxwQ==</P><Q>tgCSBE7gLCOVBlUDu31MkvL40CuNp1n47JfR7wJl3I5eBsdXiKmt8TscBSnstB5zp6UagP08nOCHlufMYcIjow==</Q><DP>fAFB+xAL+HuEU6r2P7cX7e9kU2VofOI1NyveFgifTBb6fd6wQwIqP7ts0Zu1oz6iChaqTxjYZ4Sjj9DVZ0B/gQ==</DP><DQ>FBeeBxG6F8VZ11gdUF51zKc8JqcYPUhmfaAJEgy+uAmTgcYR+MlapY3z+vH06rGN7Q0CDwll3p+++D7gxk4LZw==</DQ><InverseQ>1sd200+G1gW1VPl/3d6pli+WasbMBK7mmTZrF5WKAxcgvMd5dhPfP+A/iz/S+jlHQtq0n83Wkearcg+EVVfEjg==</InverseQ><D>QSQtoL0nwuy8BNi7RKQkiuDlWWqbieqZFui6cAM8wJ4oRq9D054gTA4LjRXOHYPgBy4LRT/dvSNkTNe4YrhzSg1fleN2bE52nec2huxw10qM5A6TzXM1fubKR/rugws2lZHkifljzDL6oN5H637SWSgi5Owd4dyyc19r6Hbx/UE=</D></RSAKeyValue>";

        private static RSACryptoServiceProvider CreateCipher()
        {
            // Use existing RSA protected key container.
            // One will be generated if it does not find a match.
            // CspParameters = cryptographic service parameters
            //var cryptoServiceParams = new CspParameters
            //{
            //    KeyContainerName = "RjbRsaKeys",
            //    Flags = CspProviderFlags.UseMachineKeyStore
            //};
            //var cipher = new RSACryptoServiceProvider(cryptoServiceParams);

            // Read from previously exported RSA key set in XML (public & private)
            var cipher = new RSACryptoServiceProvider();
            cipher.FromXmlString(RSA_KEYS);

            return cipher;
        }

        public string Encrypt(string plainText)
        {
            RSACryptoServiceProvider cipher = CreateCipher();
            byte[] data = Encoding.UTF8.GetBytes(plainText);
            byte[] cipherText = cipher.Encrypt(data, false);
            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string cipherText)
        {
            RSACryptoServiceProvider cipher = CreateCipher();
            var decodedCipher = Convert.FromBase64String(cipherText);
            var plainTextBytes = cipher.Decrypt(decodedCipher, false);
            return Encoding.UTF8.GetString(plainTextBytes);
        }
    }
}