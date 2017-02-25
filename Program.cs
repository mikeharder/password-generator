using CommandLine;
using System;
using System.Web.Security;

namespace PasswordGenerator
{
    class Program
    {
        private class Options
        {
            [Option('l', "length", Default = 16)]
            public int Length { get; set; }

            [Option('n', "nonAlphaNumeric", Default = 2)]
            public int NonAlphaNumeric { get; set; }
        }

        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<Options>(args).MapResult(
                options => Run(options),
                _ => 1
            );
        }

        private static int Run(Options options)
        {
            Console.WriteLine(Membership.GeneratePassword(options.Length, options.NonAlphaNumeric));
            return 0;
        }
    }
}
