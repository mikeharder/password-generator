using System.Security.Cryptography;

namespace PasswordGenerator
{
    internal class Program
    {
        private const string _lowercase = "abcdefghijklmnopqrstuvwxyz";
        private const string _uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string _numbers = "0123456789";
        
        // https://en.wikipedia.org/wiki/List_of_Special_Characters_for_Passwords
        private const string _symbols = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        
        private const string _all = _lowercase + _uppercase + _numbers + _symbols;
            
        static void Main(int length = 16, int minSymbols = 2)
        {
            char[] password = new char[length];
            while (password.Count(c => _symbols.Contains(c)) < minSymbols)
            {
                for (var i=0; i < length; i++)
                {
                    password[i] = _all[RandomNumberGenerator.GetInt32(0, _all.Length)];
                }
            }
            Console.WriteLine(new string(password));
        }
    }
}