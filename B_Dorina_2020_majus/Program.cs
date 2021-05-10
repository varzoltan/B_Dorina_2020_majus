using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//Beolvasááshoz tartalmazza a megfelelő osztályokat, objektumokat

namespace B_Dorina_2020_majus
{
    class Program
    {
        struct Adat
        {
            public string telepules;
            public string ido;
            public string szelirany;
            public int homerseklet;
        }
        static void Main(string[] args)
        {
            //Példányosítjuk
            Adat[] adatok = new Adat[500];
            //Beolvasás
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Downloads\tavirathu13.txt");
            int n = 0;
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] darabol = sor.Split(' ');
                adatok[n].telepules = darabol[0];
                adatok[n].ido = darabol[1];
                adatok[n].szelirany = darabol[2];
                adatok[n].homerseklet = int.Parse(darabol[3]);
                n++;
            }
            olvas.Close();

            //2.feladat
            Console.WriteLine("2.feladat");
            Console.Write("Adja meg egy település kódját! Település: ");
            //A beolvasott értéket letároljuk egy váltózóba
            string varos = Console.ReadLine();
            int index = -1;
            for (int i = 0;i<n;i++)
            {
                if(adatok[i].telepules == varos)
                {
                    index = i;
                }
            }
            Console.WriteLine("Az utolsó mérési adat a megadott településről " + adatok[index].ido.Substring(0,2) + ":" + adatok[index].ido.Substring(2,2) + "-kor érkezett.");

            //3.feladat
            int max = int.MinValue;
            int index1 = -1;
            for (int i = 0;i<n;i++)
            {
                if (max < adatok[i].homerseklet)
                {
                    max = adatok[i].homerseklet;
                    index1 = i;
                }
            }

            int min = int.MaxValue;
            int index2 = -1;
            for (int i = 0; i < n; i++)
            {
                if (min > adatok[i].homerseklet)
                {
                    min = adatok[i].homerseklet;
                    index2 = i;
                }
            }
            Console.WriteLine("3.feladat");
            Console.WriteLine($"A legalacsonyabb hőmérséklet: {adatok[index2].telepules} {adatok[index2].ido.Substring(0, 2)}:{adatok[index2].ido.Substring(2, 2)} {min} fok.");
            Console.WriteLine($"A legmagasabb hőmérséklet: {adatok[index1].telepules} {adatok[index1].ido.Substring(0, 2)}:{adatok[index1].ido.Substring(2, 2)} {max} fok.");

            //4.feladat
            Console.WriteLine("4.feladat");
            for (int i = 0;i<n;i++)
            {
                if(adatok[i].szelirany == "00000")
                {
                    Console.WriteLine($"{adatok[i].telepules} {adatok[i].ido.Substring(0, 2)}:{adatok[i].ido.Substring(2, 2)}");
                }
            }
            Console.ReadKey();
        }
    }
}
