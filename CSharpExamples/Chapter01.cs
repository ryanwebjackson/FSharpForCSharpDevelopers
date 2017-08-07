using System;

namespace CSharpExamples
{
    class Chapter01
    {
        public Chapter01()
        {
            main();
        }

        public static int sum = 0;
        static void main()
        {
            for (int i = 0; i<= 100; i++)
            {
                if (i % 2 != 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine( "The sum of odd numbers from 0 to 100 is {0}", sum );
        }
    }
}
