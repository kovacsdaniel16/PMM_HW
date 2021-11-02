using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMM_HW
{
    class Init
    {
        public Init(double max, double min, int db)
        {
            tomb = new double[db];            
            this.max = max;
            this.min = min;
            this.db = db;
            r = new Random();
            binary = new string[db];

        }

        public double[] tomb { get; set; }
        public double max { get; set; }
        public double min { get; set; }
        public int db { get; set; }
        public int binarycode { get; set; }
        public double maximum { get; set; }
        public double minimum { get; set; }
        public double resolution { get; set; }
        public string[] binary { get; set; }
        public string seged { get; set; }

        Random r;

        public void ADC() 
        {
            for (int i = 0; i < db; i++)
            {
                tomb[i] = r.NextDouble() * (max - min) + min;
                Console.Write("A generált érték: "+tomb[i]+"\t");

                if (min < 0) tomb[i] = (tomb[i] / max) * (Math.Pow(2, binarycode) / 2);
                else tomb[i] = (tomb[i] / max) * Math.Pow(2, binarycode);
                Console.Write("A kvantált érték: "+tomb[i]+"\t");

                seged = Convert.ToString(Convert.ToInt32(tomb[i]), 2);
                binary[i] = seged;
                Console.WriteLine("A bináris kód: "+binary[i]);

            }
        }

        public void kiir()
        {
            foreach (double szam in tomb)
            {
                Console.WriteLine(szam);
            }
        }

       /* public void kvantal()
        {
             minimum = max; //minimumkiválasztás tétele
            for (int i = 0; i < db; i++)
            {
                if (tomb[i] < minimum) minimum = tomb[i];
            }

            for (int i = 0; i < db; i++) //az a célom, hogy csak pozitív előjelű számok alkossák a tömböt
            {
                if (minimum >= 0) tomb[i] -= minimum;
                else tomb[i] += minimum * -1;
            }
             maximum = 0; // maximumkiválasztás a felbontás meghatározásához
            for (int i = 0; i < db; i++)
            {
                if (tomb[i] > maximum) maximum = tomb[i];
            }
        }
       */
        public void getResolution() //felbontás
        {
            Console.WriteLine();
            binarycode = int.Parse(Console.ReadLine());
            Console.WriteLine("Az ADC felbontása: 2^"+binarycode+" ("+ Math.Pow(2, binarycode) + ").");
            //return binarycode;
            
        }

        public void getLsb() // LSB legkisebb helyiértékű bit (Least Significant Bit) 
        {
            resolution = (max - min) / (Math.Pow(2, binarycode)-1);
            Console.WriteLine("Egy bit legkisebb helyiértéke: "+resolution/*+"V, ~" +resolution*1000+"mV")*/);
        }

       //kvantálás: generált értéket elosztom a megadható legnagyobb értékkel, és azt megszorzom a megadott felbontás értékével (vagy annak a felével)

      /*  public void getquanted()
        {
            if (min < 0) //ha a generált legkisebb érték kevesebb, mint 0 (azaz negatív szám), akkor a teljes felbontáson a pozitív és negatív tartomány is osztozik
            {
                for (int i = 0; i < db; i++)
                {
                    tomb[i] = (tomb[i] /max)*(Math.Pow(2, binarycode) / 2);
                }
            }
            else
            {
                for (int i = 0; i < db; i++)
                {
                    tomb[i] = (tomb[i] / max) * Math.Pow(2, binarycode);

                }
            }
        }*/

    }
    class Program
    {
       
        
        static void Main(string[] args)
        {

            int db = 0;
            double min;
            double max;

            Console.WriteLine("Kérem adja meg, a tömb elemszámát(Mintavételezések száma)!");
            db = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg a legmagasabb értéket!");
            max = double.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg a legalacsonyabb értéket!");
            min = double.Parse(Console.ReadLine());

            Init i = new Init(max, min, db);
            // Console.WriteLine("A megadott paraméterek alapján generált adatok");
            Console.WriteLine();
            Console.WriteLine("Kérem adja meg az ADC felbontását (bit)!");
            i.getResolution();
            i.getLsb();
            i.ADC();
           // i.kiir();
           
           // i.getquanted();
          //  Console.WriteLine("A kvantált tömb elemei: ");
          //  i.kiir();
           
           




            Console.ReadKey();
        }
    }
}
