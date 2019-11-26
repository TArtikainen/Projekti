using System;

namespace projekti
{
    class Prepaidliittyma : Yritysliittyma
    {
        
        private DateTime _voimassaoloaika;


        // konstruktori
        public Prepaidliittyma(int puhNro, string operaattori, int liittymanopeus, double hinta) : base(puhNro, operaattori, liittymanopeus, hinta)
        {
            _voimassaoloaika = DateTime.Today.AddDays(180);

        }

        public DateTime GetVoimassaolo

            // Luodaan property prepaidliittymän viimeiselle voimassaolopäivämäärälle
        {
            get{

            return _voimassaoloaika;
            }

            set {

                


                DateTime today = DateTime.Today;
                DateTime _voimassaoloaika = today.AddDays(180); 

                

            }
            
        }

        
    }
}
