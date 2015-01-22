using System;


namespace company_info
{
    class companyInfo
    {
        static void Main()
        {
            Console.Write("enter company name:");
            string compName = Console.ReadLine();
            Console.Write("enter company address:");
            string compAddr = Console.ReadLine();
            Console.Write("enter company phone:");
            string compNum = Console.ReadLine();
            Console.Write("enter company FAX:");
            string compFax = Console.ReadLine();
            Console.Write("enter company site:");
            string compWeb = Console.ReadLine();
            Console.Write("enter manager FName:");
            string fName = Console.ReadLine();
            Console.Write("enter manager LName:");
            string lName = Console.ReadLine();
            Console.Write("enter manager Age:");
            string mAge = Console.ReadLine();
            Console.Write("enter manager phone:");
            string manPhone = Console.ReadLine();

            Console.WriteLine("company name: {0}", compName);
            Console.WriteLine("company address: {0}", compAddr);
            Console.WriteLine("company FAX: {0}", compFax);
            Console.WriteLine("company website: {0}", compWeb);
            Console.WriteLine("manager first name: {0}", fName);
            Console.WriteLine("manager last name: {0}", lName);
            Console.WriteLine("manager age: {0}", mAge);
            Console.WriteLine("manager phone: {0}", manPhone);



        }
    }
}
