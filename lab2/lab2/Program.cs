using System;
using System.Collections.Generic;

namespace lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //init getter, sender and message for sender
            RSA_getter rsaGetter = new RSA_getter(179,53);
            RSA_sender rsaSender = new RSA_sender(rsaGetter.Alphabet, rsaGetter.PublicKey);
            string mes = "Съешь1 ещё2 этих3 мягких4 французских5 булок6 да7 выпей8 же9 чаю0";
            
            //show mes for sending
            Console.WriteLine($"Mes, that will send: {mes}");
            
            //send mes
            List<int> encodedMes = rsaSender.Encode(mes);
            Console.Write("Sending mes: ");
            foreach (var sym in encodedMes)
            {
                Console.Write($"{sym} ");
            }
            Console.WriteLine();
            
            //get mes
            string decodedMes = rsaGetter.Decode(encodedMes);
            Console.WriteLine($"Decoded mes: {decodedMes}");
        }
    }
}