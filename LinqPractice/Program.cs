using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateBalanceUsingAggregate();
            CaluculateProduct();
            CastintoIEnumerable();
            ConvertToDictionary();
            CountDublicateElements();
            Console.ReadKey();
        }
        /// <summary>
        /// using Aggregate to create a running Score balance that subtracts each withdrawal from the initial balance of 100
        /// </summary>
        private static void CalculateBalanceUsingAggregate()
        {
            double startBalance = 100.0;
            int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };
            double result = attemptedWithdrawals.Aggregate(startBalance, (balance, nextWithDrawal) => {
                if (balance > nextWithDrawal)
                {
                    balance = balance - nextWithDrawal;
                }
                return balance;
            });

            Console.WriteLine(result);
        }

        /// <summary>
        /// using Aggregate to get product
        /// </summary>
        private static void CaluculateProduct()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            double product = numbers.Aggregate((x, y) => x * y);
            Console.WriteLine(product);
        }

        /// <summary>
        /// casts a collection to IEnumerable of same type
        /// </summary>
        private static void CastintoIEnumerable()
        {
            string[] names = { "John", "Suzy", "Dave" };
            IEnumerable<string> names1 = names.Cast<string>();
            foreach (string item in names1)
            {
                Console.WriteLine(item);
            }
        }
        /// <summary>
        /// Transform collection into a Dictionary with Key and Value,
        /// Find the odd and even numbers from the array, create a dictionary
        /// </summary>
        private static void ConvertToDictionary()
        {
            int[] numbers = { 1, 2, 3, 4 };
            var res = numbers.ToDictionary(x => x, v => v % 2 == 0);
            foreach (KeyValuePair<int, bool> item in res)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// using groupby get the duplicate numbers, for unique number leave it fetch only duplicate
        /// </summary>
        private static void CountDublicateElements()
        {
            int[] numbers = { 10, 15, 20, 25, 30, 35, 10, 15, 30, 20 };
            var result = numbers.GroupBy(x => x)
                              .Where(z => z.Count() > 1)
                              .Select(y => new
                              {
                                  Num = y.Key,
                                  Times = y.Count()
                              });
            foreach (var item in result)
            {
                Console.WriteLine("{0},{1}", item.Num, item.Times);
            }

        }
    }
}

