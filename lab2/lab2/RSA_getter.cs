using System;
using System.Collections.Generic;

namespace lab2
{
    public class RSA_getter
    {
        //public and private keys
        private int e, d, n;

        /// <summary>
        /// alphabet of this RSA
        /// </summary>
        public string Alphabet => "~АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ 0123456789";
        
        public RSA_getter(int simpleNum1, int simpleNum2)
        {
            n = simpleNum1 * simpleNum2;
            e = GetSimpleNum(EulerNum(simpleNum1, simpleNum2), n);
            d = GetD(EulerNum(simpleNum1, simpleNum2), e);

        }

        public RSA_getter(): this(7, 13){}

        /// <summary>
        /// decode message
        /// </summary>
        /// <param name="encodedMes">encoded message</param>
        /// <returns>decoded message</returns>
        public string Decode(List<int> encodedMes)
        {
            string str = "";
            for (int i = 0; i < encodedMes.Count; i++)
            {
                int t = 1;
                for (int j = 0; j < PrivateKey.Item1; j++)
                {
                    t %= PrivateKey.Item2;
                    t *= (encodedMes[i] % PrivateKey.Item2);

                }

                t = t % PrivateKey.Item2;
                str += Alphabet[t];
                //str += Alphabet[(int)Math.Pow(encodedMes[i], PrivateKey.Item1) % PrivateKey.Item2];
            }

            return str;
        }

        /// <summary>
        /// get public key
        /// </summary>
        public (int, int) PublicKey => (e, n);

        private (int, int) PrivateKey => (d, n); 

        private int EulerNum(int p, int q) => (p - 1) * (q - 1);

        private int GetSimpleNum(int eulerNum, int n)
        {
            int i = 2;
            while (i<n)
            {
                if (eulerNum % i != 0)
                {
                    return i;
                }

                i++;
            }

            return n - 1;
        }

        private int GetD(int eulerNum, int e)
        {
            for (int i = 1; ; i++)
            {
                double d = (i * eulerNum + 1) / (double)e;
                int di = new int();
                bool isInt = int.TryParse(d.ToString(), out di);
                if (isInt)
                {
                    return di;
                }
            }
        }
        
        
    }
}