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

            GetXmlString(rsa, pathToKey);

            using (rsa)
            {
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

        /// <summary>
        /// Gets the text from a local xml file
        /// </summary>
        /// <param name="rsa">RSA object to assign xml text to</param>
        /// <param name="pathToKey">Path to the local xml file</param>
        /// <exception cref="Exception"></exception>
        private void GetXmlString(RSA rsa, string pathToKey)
        {
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
            }
        }
    }
}
