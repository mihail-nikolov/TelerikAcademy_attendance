using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext_Delegates_Lambda_Linq
{
    public static class SubstringExtension
    {
        public static StringBuilder Substring(this StringBuilder strBld, int index, int len)
        {
            bool indexIssue = index < 0 || index >= strBld.Length;
            bool lenIssue = len <= 0 || len > strBld.Length || len > strBld.Length - index; 
            if (indexIssue || lenIssue)
            {
                throw new IndexOutOfRangeException();
            }
            StringBuilder newBld = new StringBuilder();
            for (int i = index; i <= len + index; i++)
            {
                newBld.Append(strBld[i]);
            }
            return newBld;
        }

        public static void LongestStr(this string[] arr)
        {
            //string newStr = 
            //    from str in arr
            //    where str.Max()
            var longest = arr.Where(s => s.Length == arr.Max(m => m.Length)).First();
            Console.WriteLine(longest);
        }
    }
}
