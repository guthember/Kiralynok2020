using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiralynok2020
{
    class Program
    {
        class Tabla
        {
            private char[,] T;
            private char UresCella;
            private int UresOszlopokSzama;
            private int UresSorokSzama;

            public Tabla(char ch) 
            {
                T = new char[8, 8];
                UresCella = ch;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        T[i, j] = UresCella;
                    }
                }
            }

            public void Elhelyez(int N)
            {
                // 1. Véletlen helyérték létrehozása
                //    - Random osztály értékkészlet:[0,7]
                //    - véletlen sor, oszlop kell
                //    - elhelyezzük a "K"-t csak akkor 
                //              HA!!!! üres -> "#"

                Random vel = new Random();
                
                for (int i = 0; i < N; i++)
                {
                    bool igaz = true;
                    while (igaz)
                    {
                        int sor = vel.Next(0, 8);
                        int oszlop = vel.Next(0, 8);
                        if (T[sor, oszlop] == '#')
                        {
                            T[sor, oszlop] = 'K';
                            igaz = false;
                        }
                    }
                }

            }

            public void FajbaIr() { }
            public void Megjelenit()
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write($"{T[i,j]} ");
                    }
                    Console.WriteLine();
                }
            }
            public bool UresOszlop(int oszlop)
            {
                int i = 0;

                while (i < 8 && T[i, oszlop] != 'K')
                {
                    i++;
                }

                if (i < 8)
                {
                    return false;
                }
                else
                {
                    return true;
                }


            }
            public bool UresSor(int sor)
            {
                int i = 0;

                while (i < 8 && T[sor, i] != 'K')
                {
                    i++;
                }

                if (i < 8)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Királynők feladat");

            Tabla t = new Tabla('#');

            Console.WriteLine("Üres tábla:");
            t.Megjelenit();
            t.Elhelyez(8);
            Console.WriteLine();
            t.Megjelenit();

            Console.Write("Melyik sor: ");
            int sor = int.Parse(Console.ReadLine());

            if (t.UresSor(sor))
            {
                Console.WriteLine("A megadott sor üres.");
            }
            else
            {
                Console.WriteLine("A megadott sor nem üres.");
            }


            Console.ReadKey();
        }
    }
}
