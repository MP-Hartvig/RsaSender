using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace RsaSender
{
    internal class RsaEncryptor
    {
        /// <summary>
        /// Initiates the encryption process
        /// </summary>
        /// <param name="input">User input to be encrypted</param>
        /// <param name="pathToKey">Path to the xml file with the public key</param>
        /// <returns>The encrypted text as a byte array</returns>
        /// <exception cref="Exception"></exception>
        public byte[] RsaEncrypt(string input, string pathToKey)
        {
            RSA rsa = RSA.Create(4096);

            using (rsa)
            {
                try
                {
                    rsa.FromXmlString(File.ReadAllText(pathToKey));
                }
                catch (Exception e)
                {
                    throw new Exception("Getting public key from xml failed with the following message: " + e.Message);
                }

                try
                {
                    return rsa.Encrypt(Encoding.UTF8.GetBytes(input), RSAEncryptionPadding.Pkcs1);
                }
                catch (Exception e)
                {
                    throw new Exception("Encryption failed with the following message: " + e.Message);
                }                
            }
        }
    }
}
