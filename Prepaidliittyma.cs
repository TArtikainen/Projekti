using System;

namespace projekti
{
    class Prepaidliittyma : Liittyma
    {
        
        private DateTime _voimassaoloaika;


        // konstruktori
        public Prepaidliittyma(string operaattori, int liittymanopeus, double hinta) : base(operaattori, liittymanopeus, hinta)
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
