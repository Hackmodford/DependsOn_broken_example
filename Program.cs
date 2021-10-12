using System;
using System.Threading;

namespace NPCDemoBug1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var _ = new ViewModelA(new TestService());
            while (true)
            {
                
            }
        }
    }
}