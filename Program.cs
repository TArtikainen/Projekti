
using System;
using System.Collections.Generic;
using Npgsql;

namespace projekti
{
    class Program
    {
        private static int yritysnopeus;
        private static double yrityshinta;
        private static int perusnopeus;
        private static double perushinta;
        private static int prepaidnopeus;
        private static double prepaidhinta;

        static void Main(string[] args)
        {
            
            int response;
            List<Liittyma> liittymalista = new List<Liittyma>();
          
            do

            {
                Console.WriteLine("Tallennusohjelma kännykkäliittymille");
                Console.WriteLine();
                Console.WriteLine("1 - Syötä yritysliittymän tiedot");
                Console.WriteLine("2 - Syötä perusliittymän tiedot");
                Console.WriteLine("3 - Syötä prepaidliittyman tiedot");
                Console.WriteLine("4 - Tulosta syötettyjen yritysliittymien tiedot");
                Console.WriteLine("5 - Tulosta syötettyjen perusliittymien tiedot");
                Console.WriteLine("6 - Tulosta syötettyjen prepaidliittymien tiedot");
                response = int.Parse(Console.ReadLine());


                switch (response)
                {
                    case 1:
                        Console.Write("Syötä yritysliittymän operaattori:");
                        string yritysoperaattori = Console.ReadLine();

                        Console.Write("Syötä liittyman datasiirtonopeus numeroina:");
                                                
                       
                        try
                        {
                            yritysnopeus = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty datasiirtonopeus.\nDatasiirtonopeutta ei tallennettu. ");
                        }

                        

                        Console.Write("Syötä hinta numeroina:");

                        try
                        {
                            yrityshinta = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty hinta.\nHintaa ei tallennettu. ");
                        }

                        

                        Yritysliittyma uusiLiittyma = new Yritysliittyma(yritysoperaattori, yritysnopeus, yrityshinta);

                        Tietokanta.LisaaLiittyma(uusiLiittyma);

                        liittymalista.Add(uusiLiittyma);
                        Console.WriteLine($"Yritysliittymän ID numero on {uusiLiittyma.GetLiittymaID()}. Liittyman operaattori on { uusiLiittyma.GetOperaattori() } liittymanopeudella { uusiLiittyma.GetLiittymaNopeus()} Mbit/s hinnaltaan {uusiLiittyma.GetHinta()} euroa on lisätty.");
                        Console.WriteLine();

                        break;

                    case 2:
                        Console.Write("Syötä perusliittymän operaattori:");
                        string perusoperaattori = Console.ReadLine();
                        Console.Write("Syötä liittyman datasiirtonopeus:");

                        try
                        {
                            perusnopeus = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty datasiirtonopeus.\nDatasiirtonopeutta ei tallennettu. ");
                        }

                        
                        Console.Write("Syötä hinta numeroina:");
                        
                        try
                        {
                            perushinta = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty hinta.\nHintaa ei tallennettu. ");
                        }



                        Perusliittyma uusiLiittyma2 = new Perusliittyma(perusoperaattori, perusnopeus, perushinta);
                        liittymalista.Add(uusiLiittyma2);
                        Console.WriteLine($"Perusliittymä { uusiLiittyma2.GetOperaattori() } liittymanopeudella { uusiLiittyma2.GetLiittymaNopeus()} Mbit/s hinnaltaan {uusiLiittyma2.GetHinta()} euroa on lisätty. Liittymän puhelinnumero on {uusiLiittyma2.GetRandomNumber()} ");
                        Console.WriteLine();

                        break;


                    case 3:
                        Console.Write("Syötä prepaidliittymän operaattori:");
                        string prepaidoperaattori = Console.ReadLine();
                        Console.Write("Syötä liittyman datasiirtonopeus:");

                        try
                        {
                            prepaidnopeus = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty datasiirtonopeus.\nDatasiirtonopeutta ei tallennettu. ");
                        }

                        
                        Console.Write("Syötä hinta numeroina:");

                        try
                        {
                            prepaidhinta = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty hinta.\nHintaa ei tallennettu. ");
                        }

                        

                        Prepaidliittyma uusiLiittyma3 = new Prepaidliittyma(prepaidoperaattori, prepaidnopeus, prepaidhinta);
                        liittymalista.Add(uusiLiittyma3);
                        Console.WriteLine($"Prepaidliittymä { uusiLiittyma3.GetOperaattori() } liittymanopeudella { uusiLiittyma3.GetLiittymaNopeus()} Mbit/s hinnaltaan {uusiLiittyma3.GetHinta()} euroa on lisätty. Liittymä on käytössä 6kk rekisteröinnin jälkeen. Viimeinen voimassaolopäivä on {uusiLiittyma3.GetVoimassaolo} ");
                        Console.WriteLine();

                        break;


                    case 4:

                        foreach (Yritysliittyma item in liittymalista)
                        {
                            Console.WriteLine($" Yritysliittyman {item.GetOperaattori()} liittymanopeus on{item.GetLiittymaNopeus()} Mbit/s on hinnaltaan {item.GetHinta()} euroa. Yritysliittymän ID numero on {item.GetLiittymaID()}");
                            Console.WriteLine();

                        }


                        break;

                    case 5:

                        foreach (Perusliittyma item in liittymalista)
                        {
                            Console.WriteLine($" Perusliittyman {item.GetOperaattori()} liittymanopeus on{item.GetLiittymaNopeus()} Mbit/s on hinnaltaan {item.GetHinta()} euroa. Liitymän puhelinnumero on {item.GetRandomNumber()}");
                            Console.WriteLine();

                        }

                        break;

                    case 6:

                        foreach (Prepaidliittyma item in liittymalista)
                        {
                            Console.WriteLine($" Prepaidliittyman {item.GetOperaattori()} liittymanopeus on{item.GetLiittymaNopeus()} Mbit/s on hinnaltaan {item.GetHinta()} euroa. Liittymän viimeinen voimassaolopäivä on {item.GetVoimassaolo} ");
                            Console.WriteLine();
                            

                        }
                        break;
                }
            }


            while (response > 0);
        }
    }
}
