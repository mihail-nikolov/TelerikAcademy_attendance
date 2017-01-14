using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 11. Adding polynomials

    Write a method that adds two polynomials.
    Represent them as arrays of their coefficients.
*/
namespace _11.AddingPolynomials
{
    class AddingPolynomials
    {
        static void PrintPolinomial(int[] a)
        {
            string strForPrint = "";
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    strForPrint += (a[a.Length - i - 1]).ToString() + " = 0";
                    break;
                }
                strForPrint += (a[a.Length - i - 1]).ToString() + "x^" + (i).ToString() + " + ";
            }
            Console.WriteLine(strForPrint);
        }
        static int[] AddPolinomials(int[] a, int[] b)
        {
            if (a.Length < b.Length)
            {
                return AddPolinomials(b, a);
            }
            int diff = a.Length - b.Length;
            int[] c = new int[a.Length];
            Array.Copy(a, c, a.Length);
            for (int i = diff; i < a.Length; i++)
            {
                c[i] += b[i - diff];
            }
            return c;
        }
        static int[] SubstrPolinomials(int[] a, int[] b)
        {
            if (a.Length < b.Length)
            {
                return SubstrPolinomials(b, a);
            }
            int diff = a.Length - b.Length;
            int[] c = new int[a.Length];
            Array.Copy(a, c, a.Length);
            for (int i = diff; i < a.Length; i++)
            {
                c[i] -= b[i - diff];
            }
            return c;
        }
        static int[] MultiplyPol(int[] a, int[] b)
        {
            int[] result = new int[a.Length + b.Length - 1];
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    result[i + j] += a[i] * b[j];
            return result;
        }
        static void Main()
        {
            int[] a = { 5, 3, 4, 3 };
            int[] b = { 1, 2, 3 };
            int[] result = AddPolinomials(a, b);
            PrintPolinomial(a);
            PrintPolinomial(b);
            int[] substrRes = SubstrPolinomials(a, b);
            int[] multRes = MultiplyPol(a, b);
            PrintPolinomial(result);
            PrintPolinomial(substrRes);
            PrintPolinomial(multRes);
        }
    }
}
