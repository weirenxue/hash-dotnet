using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> hashes = new List<string>()
            {
                "md5",
            };
            Console.WriteLine(FileMD5(args[0]));
        }
        public static string FileMD5(string path)
        {
            if (!File.Exists(path))
            {
                return "";
            }
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
