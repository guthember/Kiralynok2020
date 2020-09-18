using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
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

                Random vel = new Random(Guid.NewGuid().GetHashCode());
                
                for (int i = 0; i < N; i++)
                {
                    bool igaz = true;
                    while (igaz)
                    {
                        int sor = vel.Next(0, 8);
                        int oszlop = vel.Next(0, 8);
                        if (T[sor, oszlop] == UresCella)
                        {
                            T[sor, oszlop] = 'K';
                            igaz = false;
                        }
                    }
                }

            }

            public void FajbaIr(StreamWriter fajl) {
                //fajl.WriteLine("ez egy szöveg");
                for (int i = 0; i < 8; i++)
                {
                    string sor = "";
                    for (int j = 0; j < 8; j++)
                    {
                        sor += T[i, j];
                    }
                    fajl.WriteLine(sor);
                }
            }
            
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
            Tabla[] tablak = new Tabla[64];

            




            Console.WriteLine("Üres tábla:");
            t.Megjelenit();
            t.Elhelyez(8);
            Console.WriteLine();
            t.Megjelenit();

            Console.WriteLine("8. feladat: Az üres oszlopok és sorok száma:");

            int uresSor = 0;
            int uresOszlop = 0;

            for (int i = 0; i < 8; i++)
            {
                if (t.UresOszlop(i))
                {
                    uresOszlop++;
                }

                if (t.UresSor(i))
                {
                    uresSor++;
                }
            }
            Console.WriteLine("Oszlopok: {0}",uresOszlop);
            Console.WriteLine("Sorok: {0}", uresSor);

            
            StreamWriter ki = new StreamWriter("adatok.txt");

            for (int i = 0; i < 64; i++)
            {
                tablak[i] = new Tabla('*');
            }

            for (int i = 0; i < 64; i++)
            {
                tablak[i].Elhelyez(i + 1);
                tablak[i].FajbaIr(ki);
                ki.WriteLine();
            }
         
            ki.Close();


            Console.ReadKey();
        }
    }
}
