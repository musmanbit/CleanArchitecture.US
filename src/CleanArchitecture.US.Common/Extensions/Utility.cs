using System.Text.RegularExpressions;

namespace CleanArchitecture.US.Common.Extensions
{
    public static class Extension
    {
        /// <summary>
        /// Validate JSON Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool IsValidJWT(this string token)
        {
            // Create a Regex  
            Regex rg = new Regex(@"^[A-Za-z0-9-_=]+\.[A-Za-z0-9-_=]+\.?[A-Za-z0-9-_.+/=]*$");

            if (!rg.IsMatch(token))
                return false;

            return true;
        }
      
    }
}
