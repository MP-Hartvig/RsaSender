using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RsaSender
{
    internal class ByteArrayToBase64Converter
    {
        /// <summary>
        /// Converts a byte array to a base 64 string with exception handling
        /// </summary>
        /// <param name="bytes">Byte array to convert</param>
        /// <returns>A base64 string</returns>
        /// <exception cref="Exception"></exception>
        public string GetByteArrayAsBase64(byte[] bytes)
        {
            try
            {
                return Convert.ToBase64String(bytes);
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Convert to base64 from byte array failed with the following message: " + e.Message);
            }
        }
    }
}
