using System;
using System.Collections.Generic;
using System.Text;

namespace projekti
{
    class Perusliittyma : Liittyma

        
    {
        private int puhNro;
        
        /* Konstruktori */
        public Perusliittyma(string operaattori, int liittymanopeus, double hinta) : base(operaattori, liittymanopeus, hinta)
        {

            Random r = new Random();            /* Luodaan kuuden numeron satunnaisluku puhelinnumeroa varten */
            puhNro = r.Next(100000, 999999);
            
        }

        public int GetRandomNumber()
        {
            return puhNro;
        }


        
        
       
        
    }
}
