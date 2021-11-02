using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMM_HW
{
    class Init //értékadás+számítások
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
        public double resolution { get; set; }
        public string[] binary { get; set; }
        public string seged { get; set; }

        Random r;

        public void ADC() 
        {
            for (int i = 0; i < db; i++)
            {
                tomb[i] = r.NextDouble() * (max - min) + min; //pszeudorandom szám generálás
                Console.Write("A generált érték: "+tomb[i]+"\t");

                if (min < 0) tomb[i] = (tomb[i] / max) * (Math.Pow(2, binarycode) / 2); //kvantált érték
                else tomb[i] = (tomb[i] / max) * Math.Pow(2, binarycode);
                Console.Write("A kvantált érték: "+tomb[i]+"\t");

                seged = Convert.ToString(Convert.ToInt32(tomb[i]), 2); //bináris kód
                binary[i] = seged;
                Console.WriteLine("A bináris kód: "+binary[i]);

            }
        }


       
        public void getResolution() //felbontás
        {
            Console.WriteLine();
            binarycode = int.Parse(Console.ReadLine());
            Console.WriteLine("Az ADC felbontása: 2^"+binarycode+" ("+ Math.Pow(2, binarycode) + ").");
            
        }

        public void getLsb() // LSB legkisebb helyiértékű bit (Least Significant Bit) 
        {
            resolution = (max - min) / (Math.Pow(2, binarycode)-1);
            Console.WriteLine("Egy bit legkisebb helyiértéke: "+resolution);
        }

       
    }
    class Program
    {
       
        
        static void Main(string[] args)
        {

            int db = 0;
            double min;
            double max;

            //Adatok felvétele
            Console.WriteLine("Kérem adja meg, a tömb elemszámát(Mintavételezések száma)!");
            db = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg a legmagasabb értéket!");
            max = double.Parse(Console.ReadLine());
            Console.WriteLine("Kérem adja meg a legalacsonyabb értéket!");
            min = double.Parse(Console.ReadLine());

            Init i = new Init(max, min, db);
            Console.WriteLine();
            Console.WriteLine("Kérem adja meg az ADC felbontását (bit)!");
            i.getResolution();
            i.getLsb();

            //ADC metódus meghívása
            i.ADC();
           
           

            Console.ReadKey();
        }
    }
}
