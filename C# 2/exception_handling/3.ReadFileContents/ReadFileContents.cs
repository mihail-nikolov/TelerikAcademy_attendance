using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*Problem 3. Read file contents

    Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
    Find in MSDN how to use System.IO.File.ReadAllText(…).
    Be sure to catch all possible exceptions and print user-friendly error messages.
*/
namespace _3.ReadFileContents
{
    class ReadFileContents
    {
        static void Main()
        {
            string fileFullPath = Console.ReadLine(); //@"C:\WINDOWS3\win2.ini";
            // picture C:\Users\mnikolov\Pictures\Untitled.jpg
            // txt D:\Telerik Academy\Homeworks\C# 2\Bla.txt
            try
            {
                string text = System.IO.File.ReadAllText(fileFullPath);
                Console.WriteLine(text);
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The given path is too long!");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive cannot be found or does not exist!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The directory cannot be found or does not exist!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file cannot be found or does not exist!");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("The program cannot load the file!");
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("The file is not in the valid format!");
            }
        }
    }
}
