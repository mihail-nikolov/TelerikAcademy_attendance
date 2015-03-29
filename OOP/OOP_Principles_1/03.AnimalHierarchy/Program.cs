using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 3. Animal hierarchy

    Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
    Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).
*/
namespace _03.AnimalHierarchy
{
    class Program
    {
        static void Main()
        {
            Tomcat tom = new Tomcat("tom", 3);
            tom.MakeSoud();

            Cat[] cats = new Cat[3];
            cats[0] = tom;
            cats[1] = new Kitten("maca", 4);
            cats[1].MakeSoud();
            cats[2] = new Kitten("keta", 5);

            double catsAge = Animal.CalcAverageAge(cats);
            Console.WriteLine("-----------------------");
            Console.WriteLine("catsAge = {0}", catsAge);
            Console.WriteLine("-----------------------");

            Dog pufi = new Dog("pufi", 'M', 3);
            pufi.MakeSoud();

            Dog[] pomqri = new Dog[2];
            pomqri[0] = pufi;
            pomqri[1] = new Dog("sara",'F',  4);

            double dogAge = Animal.CalcAverageAge(pomqri);
            Console.WriteLine("-----------------------");
            Console.WriteLine("dogsAge = {0}", dogAge);
            Console.WriteLine("-----------------------");

            Frog jabka = new Frog("jabka", 'F', 3);
            jabka.MakeSoud();

            Frog[] frogs = new Frog[2];
            frogs[0] = jabka;
            frogs[1] = new Frog("jabok", 'M', 4);

            double frogAge = Animal.CalcAverageAge(frogs);
            Console.WriteLine("-----------------------");
            Console.WriteLine("frogsAge = {0}", frogAge);
            Console.WriteLine("-----------------------");
        }
    }
}
