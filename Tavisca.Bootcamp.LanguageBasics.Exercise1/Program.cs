using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            //Break equation into 3 parts
            string[] parts = equation.Split(new char[] { '*', '=' });

            //Itentify the incomplete term
            //Generate the expected value
            string incompleteTerm, expectedTerm;
            if (parts[0].Contains('?'))
            {
                //Check if there exists a whole number to satisfy the equation
                if (int.Parse(parts[2]) % int.Parse(parts[1]) != 0)
                    return -1;

                incompleteTerm = parts[0];
                expectedTerm = (int.Parse(parts[2]) / int.Parse(parts[1])).ToString();
            }
            else if (parts[1].Contains('?'))
            {
                if (int.Parse(parts[2]) % int.Parse(parts[0]) != 0)
                    return -1;

                incompleteTerm = parts[1];
                expectedTerm = (int.Parse(parts[2]) / int.Parse(parts[0])).ToString();
            }
            else
            {
                incompleteTerm = parts[2];
                expectedTerm = (int.Parse(parts[0]) * int.Parse(parts[1])).ToString();
            }

            //Ensuring that there is no leading zero
            if (incompleteTerm.Length != expectedTerm.Length)
                return -1;
            else
            {
                char missingDigit = expectedTerm[incompleteTerm.IndexOf('?')];
                return Convert.ToInt32(missingDigit.ToString());
            }
        }
    }
}
