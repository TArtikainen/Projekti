using System;
using System.Collections.Generic;
using System.Text;

namespace projekti
{
    class Liittyma
    {
        //Attribuutit
        private string _operaattori;
        private int _liittymanopeus;
        private double _hinta;
        private int puhNro;




        //Konstruktori
        public Liittyma(string operaattori, int liittymanopeus, double hinta)
        {
            _operaattori = operaattori;
            _liittymanopeus = liittymanopeus;
            this._hinta = hinta;


            Random r = new Random();            /* Luodaan kuuden numeron satunnaisluku puhelinnumeroa varten */
            puhNro = r.Next(100000, 999999);

        }

        public Liittyma(string operaattori, int liittymanopeus, double hinta, out bool success) : this(operaattori, liittymanopeus, hinta)
        {
            success = false;
        }



        //Luodaan operaattorille getteri
        public string GetOperaattori()
        {
            return _operaattori;
        }

        //Luodaan datanopeudelle getteri
        public int GetLiittymaNopeus()
        {
            return _liittymanopeus;
        }

        //Luodaan liittyman hinnalle getteri
        public double GetHinta()
        {
            return _hinta;
        }

        public int GetRandomNumber()
        {
            return puhNro;
        }

    }
}
