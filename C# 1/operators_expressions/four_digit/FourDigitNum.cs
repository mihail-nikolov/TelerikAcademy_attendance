using System;

namespace four_digit
{
    class FourDigitNum
    {
        static void Main()
        {
            int number = 2011;
            string numStr = number.ToString();
            string digitOne = numStr[0].ToString();
            string digitTwo = numStr[1].ToString();
            string digiThree = numStr[2].ToString();
            string digitFour = numStr[3].ToString();

            int sum = int.Parse(digitOne) + int.Parse(digitTwo) + int.Parse(digiThree) + int.Parse(digitFour);

            string reversed = digitFour + digiThree + digitTwo + digitOne;

            string lastDigInFront = digitFour + digitTwo + digiThree + digitOne;

            string secondThirdExch = digitOne + digiThree + digitTwo + digitFour;

            Console.WriteLine("the number: {0}", number);
            Console.WriteLine("the SUM: {0}", sum);
            Console.WriteLine("reversed {0}:", reversed);
            Console.WriteLine("lastDigInFront {0}:", lastDigInFront);
            Console.WriteLine("secondThirdExch {0}:", secondThirdExch);

        }

    }
}
