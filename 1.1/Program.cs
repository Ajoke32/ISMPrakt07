
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    
    class Program
    {

        static void Main(string[] args)
        {
           
         
            Date startdate = new Date(22,03,2003,13,11);
            Date finishdate = new Date(26,04, 2003, 14, 50);
            Airplane air = new Airplane("NY", "Kyiv", startdate, finishdate);
            PrintAirplane(air);
            air.GetTotalTime(startdate,finishdate);
            air.IsArrivingToday(startdate, finishdate);
            Airplane[] msa = ReadAirplaneArray();
            PrintAirplanes(msa);
            GetAirplaneInfo(msa, out int max, out int min);
            Console.WriteLine($"min={min}");
            Console.WriteLine($"max={max}");
            SortAirplanesByDate(msa);
            SortAirplanesByTotalTime(msa);
        }
        public static Airplane[] ReadAirplaneArray()
        {
            int n;
            Console.Write("count =");
            n = int.Parse(Console.ReadLine());

            Airplane[] mas = new Airplane[n];
            
            for(int i = 0;i<mas.Length;i++)
            {
                Console.WriteLine($"Infomation[{i+1}]");
                Console.Write("StartCity = ");
                string scity = Console.ReadLine();
                Console.Write("FinishCity = ");
                string fcity = Console.ReadLine();
                Console.Write("StartDate:");
                int syear, smounth,sday, shour, sminutes;
                syear = int.Parse(Console.ReadLine());
                smounth = int.Parse(Console.ReadLine());
                sday = int.Parse(Console.ReadLine());
                shour = int.Parse(Console.ReadLine());
                sminutes = int.Parse(Console.ReadLine());
                Date startdate = new Date(sday, smounth, syear, shour, sminutes);
                Console.Write("FinishDate:");
                int fyear, fmounth, fday, fhour, fminutes;
                fyear = int.Parse(Console.ReadLine());
                fmounth = int.Parse(Console.ReadLine());
                fday = int.Parse(Console.ReadLine());
                fhour = int.Parse(Console.ReadLine());
                fminutes = int.Parse(Console.ReadLine());
                Date finishdate = new Date(fday, fmounth, fyear, fhour, fminutes);
                mas[i] = new Airplane(scity, fcity, finishdate, startdate);
                
            }
            
                return mas;
        }
        public static void PrintAirplane(Airplane objec)
        {
            Console.WriteLine($"Start City: {objec.GetStartcity()}\nFinish City: {objec.GetFinishcity()}");
            Console.WriteLine($"Start Date: {objec.GetSDate().GetDay()}.{objec.GetSDate().GetMouth()}.{objec.GetSDate().GetYear()} {objec.GetSDate().GetHour()}:{objec.GetSDate().GetMinutes()}");
            Console.WriteLine($"Finish Date: {objec.GetFDate().GetDay()}.{objec.GetFDate().GetMouth()}.{objec.GetFDate().GetYear()} {objec.GetFDate().GetHour()}:{objec.GetFDate().GetMinutes()}");
        }
        public static void PrintAirplanes(Airplane[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine($"Ticket[{i + 1}]");
                Console.WriteLine($"Start City: {mass[i].GetStartcity()}\nFinish City: {mass[i].GetFinishcity()}");
                Console.WriteLine($"Start Date: {mass[i].GetSDate().GetDay()}.{mass[i].GetSDate().GetMouth()}.{mass[i].GetSDate().GetYear()} {mass[i].GetSDate().GetHour()}:{mass[i].GetSDate().GetMinutes()}");
                Console.WriteLine($"Start Date: {mass[i].GetFDate().GetDay()}.{mass[i].GetFDate().GetMouth()}.{mass[i].GetFDate().GetYear()} {mass[i].GetFDate().GetHour()}:{mass[i].GetFDate().GetMinutes()}");
            }
        }

        public static Airplane GetAirplaneInfo(Airplane[] mass, out int min, out int max)
        {
            int ssum = 0, fsum = 0, tsum = 0;
            max = 0;
            min = 0;
            Airplane m = new Airplane();
            for (int i = 0; i < mass.Length; i++)
            { 
             ssum += (mass[i].GetSDate().GetHour() * 60) + mass[i].GetSDate().GetMinutes();
             fsum += (mass[i].GetFDate().GetHour() * 60) + mass[i].GetFDate().GetMinutes();
             tsum = fsum - ssum;
                if (i == 0)
                {
                    max = tsum;
                    min = tsum;
                }
               if (min < tsum)
               {
                    min = tsum;
               }
               if (tsum < max)
               {
                    max = tsum;
               }
                tsum -= tsum;
                ssum -= ssum;
                fsum -= fsum;
            }

           return m;
        }
        public static Airplane SortAirplanesByDate(Airplane[] mas)
        {
            
            Airplane k = new Airplane();
            double[] minmas = new double[10];
            for (int i = 0; i < mas.Length; i++)
            {
                Date sdate = new Date(mas[i].GetSDate().GetYear(), mas[i].GetSDate().GetMouth(), mas[i].GetSDate().GetDay());
                DateTime centuryBegin = new DateTime(2001, 1, 1);
                DateTime currentDate = new DateTime(sdate.GetYear(), sdate.GetMouth(), sdate.GetDay());
                long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                minmas[i] = elapsedSpan.TotalMinutes;
            }
            for (int i = 0; i < minmas.Length-1; i++)
            {
                Airplane tmp;
                if (minmas[i] < minmas[i + 1])
                {
                    tmp = mas[i];
                    mas[i] = mas[i + 1];
                    mas[i + 1] = tmp;
                }
            }
            return k;
        }
        public static Airplane SortAirplanesByTotalTime(Airplane[] mas)
        {
            Airplane k = new Airplane();


            int ssum = 0, fsum = 0, tsum = 0;

            double[] timemas = new double[10];
            for (int i = 0; i < mas.Length; i++)
            {
                ssum += (mas[i].GetSDate().GetHour() * 60) + mas[i].GetSDate().GetMinutes();
                fsum += (mas[i].GetFDate().GetHour() * 60) + mas[i].GetFDate().GetMinutes();
                tsum = fsum - ssum;
                timemas[i] = tsum;
                
                tsum -= tsum;
                ssum -= ssum;
                fsum -= fsum;
            }
            for (int i = 1; i < timemas.Length; i++)
            {
                Airplane tmp;
               if (timemas[i] > timemas[i - 1])
               {
                    tmp = mas[i];
                    mas[i] = mas[i-1];
                    mas[i - 1] = tmp;
               }
            }


            return k;

        }
    }
}

