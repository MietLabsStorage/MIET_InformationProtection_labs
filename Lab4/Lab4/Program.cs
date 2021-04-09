using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Blowfish blowfish = new Blowfish("There is my key for blowfish");

            string mes = "There is my message for blowfish";
            Console.WriteLine($"Mes: {mes}");

            byte[] mesBytes = Encoding.ASCII.GetBytes(mes);
            Console.Write("Mes by bytes: ");
            foreach (var bytes in mesBytes)
            {
                Console.Write($"{bytes} ");
            }
            Console.WriteLine();

            List<byte> byteList = new List<byte>(0);
            byteList.AddRange(mesBytes);
            List<byte> encoded = blowfish.Encode(byteList);

            Console.Write("Encoded by bytes: ");
            foreach (var bytes in encoded)
            {
                Console.Write($"{bytes} ");
            }
            Console.WriteLine();

            List<byte> decoded = blowfish.Decode(encoded);

            Console.Write("Decoded by bytes: ");
            foreach (var bytes in decoded)
            {
                Console.Write($"{bytes} ");
            }
            Console.WriteLine();

            Console.Write("Decoded mes: ");
            Console.WriteLine(Encoding.ASCII.GetString(decoded.ToArray()));

            Console.ReadKey();
        }
    }
}
