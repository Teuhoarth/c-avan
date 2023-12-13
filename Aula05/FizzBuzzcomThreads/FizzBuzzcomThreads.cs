using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FizzBuzzcomThreadss
{
    public class FizzBuzzcomThreadsa
    {
        static object lockObject = new object();
        static int currentNumber = 1;
        static int maxNumber = 100;
        static void Main()
        {
            Thread fizzThread = new Thread(Fizz);
            Thread buzzThread = new Thread(Buzz);
            Thread fizzBuzzThread = new Thread(FizzBuzz);
            fizzThread.Start();
            buzzThread.Start();
            fizzBuzzThread.Start();
            fizzThread.Join();
            buzzThread.Join();
            fizzBuzzThread.Join();
        }
        static void Fizz()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (currentNumber > maxNumber)
                        break;
                    if (currentNumber % 3 == 0 && currentNumber % 5 != 0)
                    {
                        Console.WriteLine("Fizz" + currentNumber);
                        currentNumber++;
                    }
                }
                Thread.Sleep(10);
            }
        }
        static void Buzz()
        {
            while(true)
            {
                lock(lockObject)
                {
                    if (currentNumber > maxNumber)
                        break;
                    if(currentNumber % 5 == 0 && currentNumber % 3 != 0)
                    {
                        Console.WriteLine("Buzz" + currentNumber);
                        currentNumber++;
                    }
                }
                Thread.Sleep(10);
            }
        }

        static void FizzBuzz()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if(currentNumber > maxNumber)
                        break;
                    if( currentNumber % 5 == 0 && currentNumber % 3 == 0)
                    {
                        Console.WriteLine("FizzBuzz" + currentNumber);
                        currentNumber++;
                    }
                }
                Thread.Sleep(10);
            }
        }
    }
}
