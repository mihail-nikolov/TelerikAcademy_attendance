//Task 1. class_123 in C#

//    Refactor the following examples to produce code with well-named C# identifiers.

class Converter
{
    const int max_count = 6;
    class VariableToStringConverter
    {
        void ShowConvertedToString(bool variable)
        {
            string variableAsString = variable.ToString();
            Console.WriteLine(variableAsString);
        }
    }
    public static void InputMethod()
    {
        Converter.VariableToStringConverter newConvertor =
          new Converter.VariableToStringConverter();
        newConvertor.ShowConvertedToString(true);
    }
}
