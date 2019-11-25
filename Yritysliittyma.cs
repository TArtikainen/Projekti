using System;
using System.Collections.Generic;
using System.Text;

namespace projekti
{

    class Yritysliittyma : Liittyma
    {
        
        static int _liittymaID=0;


        public Yritysliittyma(string operaattori, int liittymanopeus, double hinta) : base(operaattori, liittymanopeus, hinta)
        {
            _liittymaID++;

           
        }

        public Yritysliittyma(string operaattori, int liittymanopeus, double hinta, out bool success) : this( operaattori, liittymanopeus, hinta)
        {
            success = false;
        }

        public int GetLiittymaID()
        {
            return _liittymaID;
        }






    }

}
