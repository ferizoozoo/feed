using System.Security.Cryptography;
using System.Text;

namespace feed.Utility
{
    public class Crypto
    {
        public static string GenerateSha256HashOfString(string s)
        {
            byte[] stringBytes = Encoding.ASCII.GetBytes(s);
            HashAlgorithm sha = SHA256.Create();
            return Encoding.ASCII.GetString(sha.ComputeHash(stringBytes));
        }
    }
}