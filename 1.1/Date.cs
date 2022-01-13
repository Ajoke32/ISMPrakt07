using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    public class Date
    {
        protected int Day;
        protected int Mounth;
        protected int Year;
        protected int Hour;
        protected int Minutes;
        public Date()
        {
            Day = 0;
            Mounth = 0;
            Year = 0;
            Hour = 0;
            Minutes = 0;
        }
        public Date(int day, int mounth, int year, int hour,
            int minutes)
        {
            Day = day;
            Mounth = mounth;
            Year = year;
            Hour = hour;
            Minutes = minutes;
        }
        public Date(int day, int mounth, int year)
        {
            Day = day;
            Mounth = mounth;
            Year = year;
            Hour = 0;
            Minutes = 0;
        }
        public Date(Date obj)
        { 
            Day = obj.Day;
            Mounth = obj.Mounth;
            Year = obj.Year;
            Hour = obj.Hour;
            Minutes = obj.Minutes;
        }
        public int GetDay()
        {
            return Day;
        }
        public int GetMouth()
        {
            return Mounth;
        }
        public int GetYear()
        {
            return Year;
        }
        public int GetHour()
        {
            return Hour;
        }
        public int GetMinutes()
        {
            return Minutes;
        }
        public void SetDay(int day)
        {
            if (day > 0 && day <= 31)
            {
                Day = day;
            }
        }
        public void SetMonth(int month)
        {
            if (month > 0 && month <= 12)
            {
                Mounth = month;
            }
        }
        public void SetYear(int year)
        {
            if (year > 0 && year <= 2022)
            {
                Year = year;
            }
        }
        public void SetHour(int hour)
        {
            if(hour>=0&&hour<=23)
             Hour=hour;
        }
        public void Setminutes(int min)
        {
            if (min >= 0 && min <= 60)
                Minutes = min;
        }
    }
}
