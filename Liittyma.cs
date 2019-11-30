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
        private int _puhNro;




        //Konstruktori
        public Liittyma(int puhNro, string operaattori, int liittymanopeus, double hinta)
        {
            _operaattori = operaattori;
            _liittymanopeus = liittymanopeus;
            this._hinta = hinta;
            _puhNro = puhNro;


            Random r = new Random();            /* Luodaan kuuden numeron satunnaisluku puhelinnumeroa varten */
            _puhNro = r.Next(100000, 999999);

        }

        public Liittyma(int puhNro, string operaattori, int liittymanopeus, double hinta, out bool success) : this(puhNro, operaattori, liittymanopeus, hinta)
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

        //Luodaan liittyman puhelinnumerolle getteri
        public int GetRandomNumber()
        {
            return _puhNro;
        }

    }
}