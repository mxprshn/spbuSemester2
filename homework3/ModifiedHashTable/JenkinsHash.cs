
namespace ModifiedHashTable
{
    public class JenkinsHash : IHashFunction
    {
        public ulong Hash(string source)
        {
            ulong hashSum = 0;

            foreach(ulong characterCode in source)
            {
                hashSum += characterCode;
                hashSum += hashSum << 10;
                hashSum ^= hashSum >> 6;
            }

            hashSum += hashSum << 3;
            hashSum ^= hashSum >> 11;
            hashSum += hashSum << 15;

            return hashSum;
        }
    }
}
