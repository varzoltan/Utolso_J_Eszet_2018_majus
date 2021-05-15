using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Utolso_J_Eszet_2018_majus
{
    class Program
    {
        struct Adat
        {
            public int ora;
            public int perc;
            public int azonosito;
            public string beki;
            public int bentlevok;
        }
        static void Main(string[] args)
        {
            Adat[] adatok = new Adat[1000];
            StreamReader beolvas = new StreamReader(@"C:\Users\Rendszergazda\Downloads\ajto.txt");
            int n = 0;
            int bentlevo = 0;
            while (!beolvas.EndOfStream)
            {
                string sor = beolvas.ReadLine();
                string[] db = sor.Split(' ');
                adatok[n].ora = int.Parse(db[0]);
                adatok[n].perc = int.Parse(db[1]);
                adatok[n].azonosito = int.Parse(db[2]);
                adatok[n].beki = db[3];
                if (db[3] == "be")
                {
                    bentlevo++;
                }
                else
                {
                    bentlevo--;
                }
                adatok[n].bentlevok = bentlevo;
                n++;
            }

            beolvas.Close();

            //2.feladat:
            for (int i = 0; i<n ; i++)
            {
                if (adatok[i].beki == "be")
                {
                    Console.WriteLine($"2. feladat:\nAz első belépő: {adatok[i].azonosito}");
                    break;
                }
            }

            for (int i = n-1;i>=0; i--)
            {
                if (adatok[i].beki == "ki")
                {
                    Console.WriteLine($"Az utolsó kilépő: {adatok[i].azonosito}");
                    break;
                }
            }

            //3. feladat:
            StreamWriter ir = new StreamWriter(@"C:\Users\Rendszergazda\Downloads\athaladas.txt");
            int szamlalo = 0;
            for (int i = 1; i<=100; i++)
            {
                for (int k = 0; k<n; k++)
                {
                    if (adatok[k].azonosito == i)
                    {
                        szamlalo++;
                    }
                }
                if (szamlalo != 0)
                {
                    ir.WriteLine($"{i} {szamlalo}");
                }
                szamlalo = 0;
            }
            ir.Close();

            //4.feladat
            int szamlalo1 = 0;
            Console.Write("4.feladat:\nA társalgóban voltak: ");
            for (int i = 1; i <= 100; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (adatok[k].azonosito == i)
                    {
                        szamlalo1++;
                    }
                }
                if (szamlalo1 != 0 && szamlalo1 % 2 != 0)
                {
                    Console.Write(i+" ");
                }
                szamlalo1 = 0;
            }
            Console.ReadKey();
        }
    }
}
