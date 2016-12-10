using System;
using System.Security.Cryptography;
using System.Text;
using NUnit.Framework;

namespace Exam70483.DebugAppsAndImplementSecurity.Tests
{
    [TestFixture]
    public class HashingTests
    {
        private const string PlainText = "hello, world";
        private const string Key = "9+hPJGap6X1oRUDP/M0jBWHeiESfzJOq8LsL4350FSY=";

        [Test]
        public void SHA512HashShouldMatchPlainTextWhenHashed()
        {
            const string expected = "8710339DCB6814D0D9D2290EF422285C9322B7163951F9A0CA8F883D3305286F44139AA374848E4174F5AADA663027E4548637B6D19894AEC4FB6C46A139FBF9";

            var hashService = new SHA512Managed();
            var hash = hashService.ComputeHash(Encoding.UTF8.GetBytes(PlainText));
            var actual = BitConverter.ToString(hash).Replace("-", "");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SaltedPasswordShouldMatchPlainText()
        {
            const string salt = "f9HtphbVSk0=";
            const string expected =
                "8f5mXkKozPQUkDMHFcGm/wlaxby/NMKKNFOl1amw0zNfy9WOYffaGEF5c4m71BYswE07SgLfV4ZOy8gnpxKXnw==";
            var actual = ComputeHash(PlainText, salt, Key);
            Assert.That(actual, Is.EqualTo(expected));
        }

        private static string ComputeHash(string plainText, string salt, string key)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var saltBytes = Encoding.UTF8.GetBytes(salt);
            var keyBytes = Encoding.UTF8.GetBytes(key);

            var keyBytesSize = plainTextBytes.Length + saltBytes.Length + keyBytes.Length;
            var resultingKeyBytes = new byte[keyBytesSize];
            plainTextBytes.CopyTo(resultingKeyBytes, 0);
            saltBytes.CopyTo(resultingKeyBytes, plainTextBytes.Length);
            keyBytes.CopyTo(resultingKeyBytes, plainTextBytes.Length + saltBytes.Length);

            var hashingService = new SHA512Managed();
            var hash = hashingService.ComputeHash(resultingKeyBytes);
            var encodedHash = Convert.ToBase64String(hash);

            return encodedHash;
        }

        private string GetSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var salt = new byte[8];
            rng.GetBytes(salt);
            var encodedSalt = Convert.ToBase64String(salt);
            return encodedSalt;
        }
    }
}