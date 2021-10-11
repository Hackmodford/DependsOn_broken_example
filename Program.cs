using System;

namespace NPCDemoBug1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Program Started");
            var _ = new ViewModelA(new TestService());
            while (true)
            {
                
            }
        }
    }
}