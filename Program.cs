
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
        private static int puhNro;



        static void Main(string[] args)
        {

            int response;
            //List<Liittyma> liittymalista = new List<Liittyma>();    //Luodaan lista liittymille 

            List<Liittyma> listayritysliittyma = new List<Liittyma>();  //Luodaan lista yritysliittymille 
            listayritysliittyma = Tietokanta.valitseYritysLiittyma();

            List<Liittyma> listaperusliittyma = new List<Liittyma>();   //Luodaan lista perusliittymille 
            listaperusliittyma = Tietokanta.valitsePerusLiittyma();

            List<Liittyma> listaprepaidliittyma = new List<Liittyma>();     //Luodaan lista prepaidliittymille 
            listaprepaidliittyma = Tietokanta.valitsePrepaidLiittyma();


            do                                                              // Do While looppi valikon lohkoille

            {
                Console.WriteLine("Tallennusohjelma kännykkäliittymille");  //Tulostetaan valikko  
                Console.WriteLine();
                Console.WriteLine("1 - Syötä yritysliittymän tiedot");
                Console.WriteLine("2 - Syötä perusliittymän tiedot");
                Console.WriteLine("3 - Syötä prepaidliittyman tiedot");
                Console.WriteLine("4 - Tulosta syötettyjen yritysliittymien tiedot");
                Console.WriteLine("5 - Tulosta syötettyjen perusliittymien tiedot");
                Console.WriteLine("6 - Tulosta syötettyjen prepaidliittymien tiedot");
                response = int.Parse(Console.ReadLine());


                switch (response)                                           //switch case lausekkeet suoritettaviin lohkoihin
                {
                    case 1:
                        Console.Write("Syötä yritysliittymän operaattori:");
                        string yritysoperaattori = Console.ReadLine();

                        Console.Write("Syötä liittyman datasiirtonopeus numeroina:");


                        try                                                 //try catch kokonaisluvun selvittamiseen
                        {
                            yritysnopeus = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty datasiirtonopeus.\nDatasiirtonopeutta ei tallennettu. ");
                        }



                        Console.Write("Syötä hinta numeroina:");

                        try                                                 //try catch kokonaisluvun selvittamiseen
                        {
                            yrityshinta = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty hinta.\nHintaa ei tallennettu. ");
                        }



                        Yritysliittyma uusiLiittyma = new Yritysliittyma(puhNro, yritysoperaattori, yritysnopeus, yrityshinta);

                        Tietokanta.LisaaYritysLiittyma(uusiLiittyma);


                        //liittymalista.Add(uusiLiittyma);
                        Console.WriteLine($"Yritysliittymän ID numero on {uusiLiittyma.GetLiittymaID()}. Liittyman operaattori on { uusiLiittyma.GetOperaattori() } liittymanopeudella { uusiLiittyma.GetLiittymaNopeus()} Mbit/s hinnaltaan {uusiLiittyma.GetHinta()} euroa on lisätty.");
                        Console.WriteLine();

                        break;

                    case 2:
                        Console.Write("Syötä perusliittymän operaattori:");
                        string perusoperaattori = Console.ReadLine();
                        Console.Write("Syötä liittyman datasiirtonopeus:");

                        try                                                         //try catch kokonaisluvun selvittamiseen
                        {
                            perusnopeus = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty datasiirtonopeus.\nDatasiirtonopeutta ei tallennettu. ");
                        }


                        Console.Write("Syötä hinta numeroina:");

                        try                                                         //try catch kokonaisluvun selvittamiseen
                        {
                            perushinta = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty hinta.\nHintaa ei tallennettu. ");
                        }



                        Perusliittyma uusiLiittyma2 = new Perusliittyma(puhNro, perusoperaattori, perusnopeus, perushinta);

                        Tietokanta.LisaaPerusLiittyma(uusiLiittyma2);

                        //liittymalista.Add(uusiLiittyma2);
                        Console.WriteLine($"Perusliittymä { uusiLiittyma2.GetOperaattori() } liittymanopeudella { uusiLiittyma2.GetLiittymaNopeus()} Mbit/s hinnaltaan {uusiLiittyma2.GetHinta()} euroa on lisätty. Liittymän puhelinnumero on {uusiLiittyma2.GetRandomNumber()} ");
                        Console.WriteLine();

                        break;


                    case 3:
                        Console.Write("Syötä prepaidliittymän operaattori:");
                        string prepaidoperaattori = Console.ReadLine();
                        Console.Write("Syötä liittyman datasiirtonopeus:");

                        try                                                         //try catch kokonaisluvun selvittamiseen
                        {
                            prepaidnopeus = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty datasiirtonopeus.\nDatasiirtonopeutta ei tallennettu. ");
                        }


                        Console.Write("Syötä hinta numeroina:");

                        try                                                         //try catch kokonaisluvun selvittamiseen
                        {
                            prepaidhinta = int.Parse(Console.ReadLine());

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Väärin syötetty hinta.\nHintaa ei tallennettu. ");
                        }



                        Prepaidliittyma uusiLiittyma3 = new Prepaidliittyma(puhNro, prepaidoperaattori, prepaidnopeus, prepaidhinta);

                        Tietokanta.LisaaPrepaidLiittyma(uusiLiittyma3);

                        //liittymalista.Add(uusiLiittyma3);
                        Console.WriteLine($"Prepaidliittymä { uusiLiittyma3.GetOperaattori() } liittymanopeudella { uusiLiittyma3.GetLiittymaNopeus()} Mbit/s hinnaltaan {uusiLiittyma3.GetHinta()} euroa on lisätty. Liittymä on käytössä 6kk rekisteröinnin jälkeen. Viimeinen voimassaolopäivä on {uusiLiittyma3.GetVoimassaolo} ");
                        Console.WriteLine();

                        break;


                    case 4:
                        /*
                        foreach (Yritysliittyma item in liittymalista)
                        {
                            Console.WriteLine($" Yritysliittyman {item.GetOperaattori()} liittymanopeus on{item.GetLiittymaNopeus()} Mbit/s on hinnaltaan {item.GetHinta()} euroa. Yritysliittymän ID numero on {item.GetLiittymaID()}");
                            Console.WriteLine();
                        }
                        */

                        //Tulostetaan tietokannasta yritysliittymat
                        foreach (Yritysliittyma Liittyma in listayritysliittyma)
                        {

                            Console.WriteLine($" Yritysliittyman puhelinnumero on {Liittyma.GetRandomNumber()}. Operaattorin {Liittyma.GetOperaattori()} liittymanopeus on {Liittyma.GetLiittymaNopeus()} Mbit/s on hinnaltaan {Liittyma.GetHinta()} euroa");
                            Console.WriteLine();


                        }
                        break;




                    case 5:
                        /*
                        foreach (Perusliittyma item in liittymalista)
                        {
                            Console.WriteLine($" Perusliittyman {item.GetOperaattori()} liittymanopeus on{item.GetLiittymaNopeus()} Mbit/s on hinnaltaan {item.GetHinta()} euroa. Liitymän puhelinnumero on {item.GetRandomNumber()}");
                            Console.WriteLine();
                        }*/

                        //Tulostetaan tietokannasta perusliittymat
                        foreach (Perusliittyma Liittyma in listaperusliittyma)
                        {

                            Console.WriteLine($" Perusliittyman puhelinnumero on {Liittyma.GetRandomNumber()}. Operaattorin {Liittyma.GetOperaattori()} liittymanopeus on {Liittyma.GetLiittymaNopeus()} Mbit/s on hinnaltaan {Liittyma.GetHinta()} euroa");
                            Console.WriteLine();


                        }
                        break;



                    case 6:
                        /* Syötettyjen tietojen tulostus
                        foreach (Prepaidliittyma item in liittymalista)
                        {
                            Console.WriteLine($" Prepaidliittyman {item.GetOperaattori()} liittymanopeus on{item.GetLiittymaNopeus()} Mbit/s on hinnaltaan {item.GetHinta()} euroa. Liittymän viimeinen voimassaolopäivä on {item.GetVoimassaolo} ");
                            Console.WriteLine();
                        }
                        */

                        //Tulostetaan tietokannasta prepaidliittymat
                        foreach (Prepaidliittyma Liittyma in listaprepaidliittyma)
                        {

                            Console.WriteLine($" liittyman puhelinnumero on {Liittyma.GetRandomNumber()}. Operaattorin {Liittyma.GetOperaattori()} liittymanopeus on {Liittyma.GetLiittymaNopeus()} Mbit/s on hinnaltaan {Liittyma.GetHinta()} euroa");
                            Console.WriteLine();


                        }
                        break;
                }
            }


            while (response > 0);
        }
    }
}