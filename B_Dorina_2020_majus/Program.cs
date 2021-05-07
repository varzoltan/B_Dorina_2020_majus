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
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Desktop\K_eszter_prog_erettsegi\2020-majus\tavirathu13.txt");
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

            Console.ReadKey();
        }
    }
}
