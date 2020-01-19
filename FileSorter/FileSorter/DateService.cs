using System;
using System.IO;

namespace FileSorter
{
    class DateService
    {
        private static readonly DateService instance = new DateService();

        public static DateService GetInstance()
        {
            return instance;
        }

        private DateService() { 
        
        }
        public bool MonthsAgo(int months, string file)
        {
            DateTime lastAccess = Directory.GetLastAccessTime(file);
            DateTime currentDate = DateTime.Now;
            bool calculatedDate;

            calculatedDate = lastAccess < currentDate.AddMonths(months);

            return calculatedDate;
        }

        public bool DaysAgo(int days, string file)
        {
            DateTime lastAccess = Directory.GetLastAccessTime(file);
            DateTime currentDate = DateTime.Now;
            bool calculatedDate;

            calculatedDate = lastAccess < currentDate.AddMonths(days);

            return calculatedDate;
        }

        public bool MAGreaterOrEqual(int months, string file)
        {
            DateTime lastAccess = Directory.GetLastAccessTime(file);
            DateTime currentDate = DateTime.Now;
            bool calculatedDate;

            calculatedDate = lastAccess >= currentDate.AddMonths(months);

            return calculatedDate;
        }

        public bool DAGreaterOrEqual(int days, string file)
        {
            DateTime lastAccess = Directory.GetLastAccessTime(file);
            DateTime currentDate = DateTime.Now;
            bool calculatedDate;

            calculatedDate = lastAccess >= currentDate.AddMonths(days);

            return calculatedDate;
        }
    }
}