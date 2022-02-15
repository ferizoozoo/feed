using System.Security.Cryptography;
using System.Text;

namespace feed.Utility
{
    public class Crypto
    {
        public static string GenerateSha256HashOfString(string s)
        {
            byte[] stringBytes = Encoding.UTF8.GetBytes(s);
            HashAlgorithm sha = SHA256.Create();
            byte[] hashedData = sha.ComputeHash(stringBytes);
            
            var sBuilder = new StringBuilder();

            for (int i = 0; i < hashedData.Length; i++)
            {
                sBuilder.Append(hashedData[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}