using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsaSender
{
    internal class EncryptionService
    {
        Stopwatch sw = new();
        RsaEncryptor rsaEncryptor = new();
        ByteArrayToBase64Converter bytesToBase64 = new();

        /// <summary>
        /// Initiates the call to the RsaEncryptor with a stopwatch to determine time spent on the péncryption process
        /// </summary>
        /// <param name="input">User input to be encrypted</param>
        /// <param name="pathToKey">Path to the xml file containing the public key</param>
        /// <returns>String array containing the cipher info</returns>
        public string[] StartEncryptionProcess(string input, string pathToKey) 
        {
            string[] cipherInfo = new string[2];
            sw.Start();
            cipherInfo[0] = bytesToBase64.GetByteArrayAsBase64(rsaEncryptor.RsaEncrypt(input, pathToKey));
            sw.Stop();
            cipherInfo[1] = sw.Elapsed.ToString();
            return cipherInfo;
        }
    }
}
