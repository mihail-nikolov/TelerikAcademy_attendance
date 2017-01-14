namespace _02.TraverseDirectory
{
    using System;
    using System.IO;
    using System.Collections.Specialized;

    class Program
    {
        // Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files matching the mask *.exe.Use the class System.IO.Directory.
        static StringCollection log = new StringCollection();

        static void Main()
        {
            var path = "C:\\WINDOWS";
            WalkDirectoryTree(path);
        }

        static void WalkDirectoryTree(string path)
        {
            string[] subDirs = null;
            string[] files = null;

            // First, process all the files directly under this folder
            try
            {
                files = Directory.GetFiles(path, "*.exe");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                log.Add(e.Message);                
            }

            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);

            }

            if (files != null)
            {
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }

            // Now find all the subdirectories under this directory.
            try
            {
                subDirs = Directory.GetDirectories(path);
                foreach (var subDir in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(subDir);
                }
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                log.Add(e.Message);
            }            

            //Console.WriteLine(string.Join(", ", subDirs));
        }
    }
}
