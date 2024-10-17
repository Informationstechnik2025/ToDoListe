using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListe
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste<string> liste = new Liste<string>();
            try
            {
                liste.Inhalt(3);
            }
            catch
            {
                Console.WriteLine("Gefangen");
            }

            Liste<string> Todo = new Liste<string>();

            Todo.Anhaengen("Feierabend machen");    // index 0
            Todo.Anhaengen("Nix machen");           // index 1
            Todo.Anhaengen("Coden");                // index 2 
            Todo.Anhaengen("Mathe Lernen");         // index 3
            Todo.Anhaengen("Schlafen");             // index 4


            Console.WriteLine($"Anzahl Elemente: {Todo.AnzahlElemente()}");
            try
            {
                for (int i = 0; i < Todo.AnzahlElemente(); i++)
                {
                    Console.WriteLine($"{i}: {Todo.Inhalt(i)}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Todo.Loeschen(2);

            Console.WriteLine($"Anzahl Elemente: {Todo.AnzahlElemente()}");
            try
            {
                for (int i = 0; i < Todo.AnzahlElemente(); i++)
                {
                    Console.WriteLine($"{i}: {Todo.Inhalt(i)}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}
