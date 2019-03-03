using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedHashTable
{
    public class FNVHash : IHashFunction
    {
        private const ulong offsetBasis = 14695981039346656037;
        private const ulong FNVPrime = 1099511628211;

        public ulong Hash(string source)
        {
            ulong hashSum = offsetBasis;

            foreach (ulong characterCode in source)
            {
                hashSum *= FNVPrime;
                hashSum ^= characterCode;
            }

            return hashSum;
        }
    }
}
