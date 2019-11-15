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

        public int GetLiittymaID()
        {
            return _liittymaID;
        }






    }

}
