using Exam70483.DebugAppsAndImplementSecurity.Encryption.Symmetric;
using NUnit.Framework;

namespace Exam70483.DebugAppsAndImplementSecurity.Tests
{
    [TestFixture]
    public class SymmetricEncryptionTests
    {
        private const string PlainText = "hello, world";
        private const string CipherText = "d+WYBMwnTe/EyNrGokXqBt78VZRWU+mU7GSoOIeOvfk=";
        private const string IV = "OwImsyt2yV6ySw6xp8iMaO6COjGRtjSv7F5AZFNGRkM=";

        [Test]
        public void DecryptShouldReturnOriginalPlainText()
        {
            var aesEncryption = new SymmetricAlgorithms();
            var decrypted = aesEncryption.Decrypt(CipherText, IV);
            Assert.That(PlainText, Is.EqualTo(decrypted));
        }
    }
}