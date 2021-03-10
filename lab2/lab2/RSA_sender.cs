using System;
using System.Collections.Generic;

namespace lab2
{
    public class RSA_sender
    {
        private Dictionary<char, int> alphabet = new Dictionary<char, int>();
        private (int, int) key;

        public RSA_sender(string _alphabet, (int, int) key)
        {
            this.key = key;
            for (int i = 0; i < _alphabet.Length; i++)
            {
                alphabet[_alphabet[i]] = i;
            }
        }

        /// <summary>
        /// encode sending message
        /// </summary>
        /// <param name="mes">sending message</param>
        /// <returns>encoded message</returns>
        public List<int> Encode(string mes)
        {
            mes = mes.ToUpper();
            List<int> lst = new List<int>();
            for (int i = 0; i < mes.Length; i++)
            {
                int t = 1;
                for (int j = 0; j < key.Item1; j++)
                {
                    t %= key.Item2;
                    t *= (alphabet[mes[i]] % key.Item2);
                }

                t = t % key.Item2;
                //lst.Add((int) Math.Pow(alphabet[mes[i]], key.Item1) % key.Item2);
                lst.Add(t);
            }

            return lst;
        }
    }
}