using System;
using System.IO;

class Program{
    static void Main(string[] args){

        Console.WriteLine("Insert the name of the scene description file: ");
        string arquivoDeCena = Console.ReadLine();

        try
        {
            // open file
            using (StreamReader sr = new StreamReader(arquivoDeCena))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    //TODO: process each file line
                    Console.WriteLine(linha); // write each file line to show the imported file
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"There was an error reading the file: {e.Message}");
        }
    }
}