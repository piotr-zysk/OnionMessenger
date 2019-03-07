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
            ISimpleHash simpleHash = new SimpleHash();
            return simpleHash.Verify(passwordText, storedHash);            
        }


    }
}