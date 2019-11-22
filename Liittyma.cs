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
        private string operaattori;
        private int liittymanopeus;
        private double hinta;


        //Konstruktori
        public Liittyma(string operaattori, int liittymanopeus, int v, double hinta)
        {
            _operaattori = operaattori;
            _liittymanopeus = liittymanopeus;
            this._hinta = hinta;

        }

        public Liittyma(string operaattori, int liittymanopeus, double hinta)
        {
            this.operaattori = operaattori;
            this.liittymanopeus = liittymanopeus;
            this.hinta = hinta;
        }

        public string GetOperaattori()
        {
            return _operaattori;
        }

        public int GetLiittymaNopeus()
        {
            return _liittymanopeus;
        }

        public double GetHinta()
        {
            return _hinta;
        }
    }
}
