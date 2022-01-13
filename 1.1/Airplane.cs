using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    public class Airplane
    {


        protected string StartCity;
        protected string FinishCity;
        protected Date StartDate;
        protected Date FinishDate;
        public Airplane()
        {
            StartCity = "Unknown";
            FinishCity = "Unknown";
            StartDate = new Date();
            FinishDate = new Date();
        }
  
        public Airplane(string startcity, string finishcity,
            Date startdate, Date finishdate)
        {
            StartCity = startcity;
            FinishCity = finishcity;
            StartDate = finishdate;
            FinishDate = startdate;
        }
        public Airplane(string finishcity, string startcity)
        {
            StartCity = startcity;
            FinishCity = finishcity;
            StartDate = new Date();
            FinishDate = new Date();
        }
        public Airplane(Airplane obj)
        {
            StartCity = obj.StartCity;
            FinishCity = obj.FinishCity;
            StartDate = obj.StartDate;
            FinishDate = obj.FinishDate;
            
        }
        public string GetStartcity()
        {
            
            return StartCity;
        }
        public string GetFinishcity()
        {
            return FinishCity;
        }
        public Date GetSDate()
        {
            return StartDate;
        }
        public Date GetFDate()
        {
            return FinishDate;
        }
        public void SetSatartcity(string scity)
        {
            if(StartCity.Length>0)
            {
               StartCity = scity;
            }
        }
        public void SetFinishtcity(string fcity)
        {
            if (FinishCity.Length > 0)
            {
                FinishCity = fcity;
            }
        }
        public void SetSdate(Date start)
        {
               
        }
        public void GetTotalTime(Date sdate, Date fdate)
        {
            int ssum=0,fsum=0,tsum=0;
            sdate.GetHour();
            ssum += (sdate.GetHour() * 60) + sdate.GetMinutes();
            fsum += (fdate.GetHour() * 60) + fdate.GetMinutes();
            tsum = fsum - ssum;
            Console.WriteLine($"Total travel time: {tsum} minutes");
        }
        public bool IsArrivingToday(Date sday, Date fday)
        {
          if (sday.GetDay() == fday.GetDay())
            {
                Console.WriteLine("Yes");
                return true;
            }
            Console.WriteLine("No");
            return false;
        }




    }
}
