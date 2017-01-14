//Task 2. Make_Чуек in C#

//Refactor the following examples to produce code with well-named C# identifiers.

class MainClass
{
    enum Gender { Male, Female };
    class Human
    {
        public Gender gender { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }

    //personNumber because I couldn't think of anything more suitable here..
    public void MakeHuman(int personNumber)
    {
        Human newHuman = new Human();
        newHuman.age = personNumber;
        if (personNumber % 2 == 0)
        {
            newHuman.name = "Guy";
            newHuman.gender = Gender.Male;
        }
        else
        {
            newHuman.name = "Chick";
            newHuman.gender = Gender.Female;
        }
    }
}