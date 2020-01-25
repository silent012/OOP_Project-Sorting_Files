using System;
using System.IO;

namespace FileSorter
{
    public sealed class DateService
    {
        /// <summary>
        /// Singleton class. Main class for operations on dates.
        /// </summary>
        private static readonly DateService instance = new DateService();
        private DateTime currentDate = DateTime.Now;
        private bool calculatedDate;

        public static DateService GetInstance()
        {
            return instance;
        }

        private DateService()
        {

        }
        /// <summary>
        /// MonthsAgo checks if last access time of given file is less than given months.
        /// </summary>
        /// <param name="months"></param>
        /// <param name="file"></param>
        /// <returns>True or false.</returns>
        public bool MonthsAgo(int months, string file)
        {
            DateTime lastAccess = Directory.GetLastAccessTime(file);

            calculatedDate = lastAccess < currentDate.AddMonths(months);

            return calculatedDate;
        }
        /// <summary>
        /// DaysAgo checks if last access time of given file is less than given days.
        /// </summary>
        /// <param name="days"></param>
        /// <param name="file"></param>
        /// <returns>True or false.</returns>
        public bool DaysAgo(int days, string file)
        {
            DateTime lastAccess = Directory.GetLastAccessTime(file);

            calculatedDate = lastAccess < currentDate.AddMonths(days);

            return calculatedDate;
        }
        /// <summary>
        /// Secondary method to support MonthsAgo. Checks if last access time of given file is greater or equal given months.
        /// </summary>
        /// <param name="months"></param>
        /// <param name="file"></param>
        /// <returns>True or false.</returns>
        public bool MAGreaterOrEqual(int months, string file)
        {
            DateTime lastAccess = Directory.GetLastAccessTime(file);

            calculatedDate = lastAccess >= currentDate.AddMonths(months);

            return calculatedDate;
        }
        /// <summary>
        /// Secondary method to support DaysAgo. Checks if last access time of given file is greater or equal given days.
        /// </summary>
        /// <param name="days"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool DAGreaterOrEqual(int days, string file)
        {
            DateTime lastAccess = Directory.GetLastAccessTime(file);

            calculatedDate = lastAccess >= currentDate.AddMonths(days);

            return calculatedDate;
        }
    }
}