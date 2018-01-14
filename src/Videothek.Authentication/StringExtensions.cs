using System.Security;

namespace Videothek.Authentication
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a Secure string from the source string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static SecureString ToSecureString(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;
            else
            {
                SecureString result = new SecureString();
                foreach (char c in source)
                    result.AppendChar(c);
                return result;
            }
        }
    }
}
