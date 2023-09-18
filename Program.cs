using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program{
    static void Main(string[] args){

        Console.WriteLine("Insert the name of the scene description file: ");
        string sceneFile = Console.ReadLine();

        try
        {
            // open file
            using (StreamReader sr = new StreamReader(sceneFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    //TODO: process each file line
                    Console.WriteLine(line); // write each file line to show the imported file
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"There was an error reading the file: {e.Message}");
        }
    }
}