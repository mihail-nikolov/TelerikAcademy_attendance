using System.Text.RegularExpressions;

namespace StringsOperationLibrary
{
    public class StringsOperator : IStringsOperator
    {
        public int GetCountFStringContainsSecond(string str1, string str2)
        {
            return  Regex.Matches(str1, str2).Count;
        }
    }
}
