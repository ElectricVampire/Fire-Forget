using EventSenderAPI;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (var i in Enumerable.Range(1, 1000))
            {
                Task.Factory.StartNew(() => PostEventToAnotherWebAPI(i), TaskCreationOptions.LongRunning);
            }
            Console.WriteLine("All Events Executed");
            Console.ReadLine();
        }
        private static void PostEventToAnotherWebAPI(int id)
        {
            CustomWebAPIClient client = new CustomWebAPIClient();
            client.CallWebAPIAsync(id);
        }
    }
}
