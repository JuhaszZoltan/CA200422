using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200422
{
    enum Het
    {
        Hetfo = 1,
        Kedd = 2,
        Szerda = 3,
        Csutortok = 4,
        Pentek = 5,
        Szombat = 6,
        Vasarnap = 7,
    }

    class Program
    {
        static Random rnd = new Random();
        static void Main()
        {
            #region enumeration
            ////init
            //var nap = Het.Pentek;
            ////rnd
            //for (int i = 0; i < 100; i++) Console.Write((Het)rnd.Next(1, 8) + " ");
            #endregion
            #region halak

            var halak = new List<Hal>();

            int cRagadozo = 0;
            int maxSulyI = 0;
            int cEgyEgeszEgy = 0;

            for (int i = 0; i < 100; i++)
            {
                halak.Add(new Hal()
                {
                    Suly = rnd.Next(10, 800) / 20F,
                    Ragadozo = rnd.Next(100) < 10,
                    Alfaj = (Alfaj)rnd.Next(8),
                    Eletter = new Eletter(rnd.Next(400), rnd.Next(10, 400)),
                });

                if (halak[i].Ragadozo) cRagadozo++;

                if (halak[maxSulyI].Suly < halak[i].Suly) maxSulyI = i;

                if (halak[i].Eletter.MinMelyseg <= 110 && halak[i].Eletter.MaxMelyseg >= 110)
                    cEgyEgeszEgy++;
            }

            /*
            halak.Add(new Hal()
            {
                Alfaj = 0,
                Ragadozo = false,
                Suly = 35,
                Eletter = new Eletter(350, 400),
            });
            */

            Console.WriteLine($"Ragadozók száma:  {cRagadozo} db\nNövényevők száma: {halak.Count - cRagadozo} db");
            Console.WriteLine($"Legnagyobb hal súlya: {halak[maxSulyI].Suly} Kg");
            Console.WriteLine($"1.1 méteren élő halak száma: {cEgyEgeszEgy} db");


            int dbNE = 0;
            float kgNE = 0;


            for (int i = 0; i < 10000; i++)
            {
                var h1 = halak[rnd.Next(halak.Count)];
                var h2 = halak[rnd.Next(halak.Count)];

                if (h1.Ragadozo != h2.Ragadozo 
                    && h1.Eletter.MaxMelyseg > h2.Eletter.MinMelyseg
                    && h2.Eletter.MaxMelyseg > h1.Eletter.MinMelyseg
                    && rnd.Next(100) < 30)
                {
                    if (!h1.Ragadozo)
                    {
                        kgNE += h1.Suly;
                        halak.Remove(h1);
                        h2.Suly *= rnd.Next(100, 110) / 100F;
                    }
                    else
                    {
                        kgNE += h2.Suly;
                        halak.Remove(h2);
                        h1.Suly *= rnd.Next(100, 110) / 100F;
                    }
                    dbNE++;
                }
            }

            Console.WriteLine("\n\n------------------\n\n");

            Console.WriteLine($"Megevett halak száma: {dbNE} db");
            Console.WriteLine($"Összes megevett hal súlya: {kgNE} Kg");

            Console.WriteLine("\n\n------------------\n\n");

            foreach (var h in halak)
            {
                Console.WriteLine(
                    "{0,-10} {1} {2: 00.00} Kg {3}",
                    h.Alfaj,
                    h.Ragadozo ? "R" : "N",
                    h.Suly,
                    $"[{h.Eletter.MinMelyseg};{h.Eletter.MaxMelyseg}]");
            }

            #endregion
            Console.ReadKey();
        }
    }
}
