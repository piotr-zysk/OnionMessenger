using SimpleHashing.Net;


namespace OnionMessenger.Infrastructure
{
    public class PasswordHash
    {
        public static string Encrypt(string passwordText)
        {
            ISimpleHash simpleHash = new SimpleHash();
            var hashedPassword = simpleHash.Compute(passwordText);
            return hashedPassword;            
        }

        public static bool Valid(string passwordText, string storedHash)
        {
            bool result = false;

            if (storedHash == null) return result;
            
            try
            {
                ISimpleHash simpleHash = new SimpleHash();
                result = simpleHash.Verify(passwordText, storedHash);
            }
            catch
            {
                result = false;
            }

            return result;
            
        }


    }
}