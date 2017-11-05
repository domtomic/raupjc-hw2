using System;
using System.Threading.Tasks;

namespace Assignment6and7
{
    public class Class1
    {
        // Task 6
        private static async Task<int> Factorial(int n)
        {
            int fact = 1;

            await Task.Run(() =>
            {
                for (int i = 1; i <= n; i++)
                    fact *= i;
            });

            return fact;
        }

        private static async Task<int> DigitSum(int n)
        {
            int sum = 0;

            await Task.Run(() =>
            {
                while (n > 0)
                {
                    sum += n % 10;
                    n /= 10;
                }
            });

            return sum;
        }

        public static async Task<int> FactorialDigitSum(int n)
        {
            int fact = await Factorial(n);
            int sum = await DigitSum(fact);

            return sum;
        }

        // Task 7
        private static async Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            int n1 = await IKnowWhoKnowsThis(10);
            int n2 = await IKnowWhoKnowsThis(5);
            return n1 + n2;
        }
        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSum(n);
        }

        //// Ignore this part.
        //static void Main(string[] args)
        //{
        //    // Main method is the only method that
        //    // can ’t be marked with async.
        //    // What we are doing here is just a way for us to simulate
        //    // async - friendly environment you usually have with
        //    // other .NET application types (like web apps, win apps etc.)
        //    // Ignore main method, you can just focus on LetsSayUserClickedAButtonOnGuiMethod() as a
        //    // first method in the call hierarchy.
        //    var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
        //    Console.Read();
        //}
    }
}
