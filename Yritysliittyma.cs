using System;
using System.Collections.Generic;
using System.Text;

namespace projekti
{

    class Yritysliittyma : Liittyma                                             //Yrityliittyma perii liittyman
    {

        static int _liittymaID = 0;

        //Konstruktori
        public Yritysliittyma(int puhNro, string operaattori, int liittymanopeus, double hinta) : base(puhNro, operaattori, liittymanopeus, hinta)
        {
            _liittymaID++;
        }

        public Yritysliittyma(int puhNro, string operaattori, int liittymanopeus, double hinta, out bool success) : this(puhNro, operaattori, liittymanopeus, hinta)
        {
            success = false;
        }

        //Getteri yritysliittyman id numerolle
        public int GetLiittymaID()
        {
            return _liittymaID;
        }

    }

}