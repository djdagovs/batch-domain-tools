using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchDomainTools.WebPanelCommons
{
    public static class xRandom
    {
        #region << GetRandomInt >>

        /// <summary>
        /// Метод возвращает случайное число используюя переданный объект Random
        /// </summary>
        /// <returns></returns>
        public static int GetRandomInt(int lMin, int rMax, Random rand)
        {
            if (lMin > rMax) 
                throw new ArgumentOutOfRangeException("lMin");
            if (lMin == rMax) 
                return lMin;
            if (rand == null) 
                rand = new Random(Guid.NewGuid().GetHashCode());
            if (rMax - lMin == 1)
            {
                if (rand.Next(0, 100) <= 50) 
                    return lMin;
                else
                    return rMax;
            }
            return rand.Next(lMin, rMax);
        }

        public static int GetRandomInt(int lMin, int rMax)
        {
            return GetRandomInt(lMin, rMax, null);
        }

        public static int GetRandomInt(string array, Random rand)
        {
            if (String.IsNullOrEmpty(array)) 
                throw new ArgumentNullException("array");
            if (array.Length == 1) 
                return 0;
            return GetRandomInt(0, array.Length - 1, rand);
        }

        public static int GetRandomInt(StringBuilder array, Random rand)
        {
            if (array == null || array.Length == 0) 
                throw new ArgumentNullException("array");
            if (array.Length == 1) 
                return 0;
            return GetRandomInt(0, array.Length - 1, rand);
        }

        public static int GetRandomInt(string array)
        {
            return GetRandomInt(array, null);
        }

        public static int GetRandomInt(StringBuilder array)
        {
            return GetRandomInt(array, null);
        }

        #endregion
        #region << CrossOrPile >>
        /// <summary>
        /// Орел или решка 
        /// </summary>
        /// <returns></returns>
        public static bool CrossOrPile()
        {
            return GetRandomInt(1, 100, null) <= 50;
        }

        /// <summary>
        /// Орел или решка 
        /// </summary>
        /// <returns></returns>
        public static bool CrossOrPile(Random rand)
        {
            return GetRandomInt(1, 100, rand) <= 50;
        }

        #endregion
        #region << GetRandomDate >>
        /// <summary>
        /// Метод возвращает случайную дату из переданого интервала
        /// </summary>
        /// <returns></returns>
        public static string GetRandomDate(DateTime startDate, DateTime endDate, string format, Random rand)
        {
            if (startDate > endDate) 
                throw new ArgumentOutOfRangeException("StartDT");
            if (startDate == endDate) 
                return startDate.ToString(format);
            if (rand == null) 
                rand = new Random(Guid.NewGuid().GetHashCode());
            TimeSpan newSpan = new TimeSpan(0, rand.Next(0, (int)(endDate - startDate).TotalMinutes), 0);
            return (startDate + newSpan).ToString(format);
        }

        /// <summary>
        /// Метод возвращает случайную дату из переданого интервала
        /// </summary>
        /// <returns></returns>
        public static string GetRandomDate(DateTime startDate, DateTime endDate, string format)
        {
            return GetRandomDate(startDate, endDate, format, null);
        }

        #endregion
        #region << GetRandomChar >>
        public static char GetRandomChar(char begin, char end, Random rand)
        {
            if (begin == end) 
                throw new ArgumentOutOfRangeException("begin");
            if (begin > end)
            {
                return (char)GetRandomInt(end, begin, rand);
            }
            return (char)GetRandomInt(begin, end, rand);
        }

        public static char GetRandomChar(string array, Random rand)
        {
            if (String.IsNullOrEmpty(array)) 
                throw new ArgumentNullException("Array");
            if (array.Length == 1) 
                return array[0];
            return array[GetRandomInt(0, array.Length - 1, rand)];
        }

        public static char GetRandomChar(string array)
        {
            return GetRandomChar(array, null);
        }

        public static char GetRandomChar(StringBuilder array, Random rand)
        {
            if (array == null || array.Length == 0) 
                throw new ArgumentNullException("Array");
            if (array.Length == 1) 
                return array[0];
            return array[GetRandomInt(0, array.Length - 1, rand)];
        }

        public static char GetRandomChar(StringBuilder array)
        {
            return GetRandomChar(array, null);
        }

        public static char GetRandomChar(char begin, char end)
        {
            return GetRandomChar(begin, end, null);
        }

        #endregion
        #region << GetRandomString >>
        /// <summary>
        ///  Метод возвращает случайную строку сформированную из случайных начальных и конечных символов
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string GetRandomString(char begin, char end, int len, Random rand)
        {
            if (len <= 0) throw new ArgumentOutOfRangeException("len");
            StringBuilder outStr = new StringBuilder();
            while (outStr.Length <= len)
            {
                outStr.Append(GetRandomChar(begin, end, rand));
            }
            return outStr.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetRandomString(char begin, char end, int len)
        {
            return GetRandomString(begin, end, len, null);
        }

        /// <summary>
        /// Метод возвращает случайную строку из переданных строк
        /// </summary>
        /// <returns></returns>
        public static string GetRandomString(Random rand, params string[] strs)
        {
            if (strs == null || strs.Length == 0) 
                throw new ArgumentOutOfRangeException("strs");
            if (strs.Length == 1) 
                return strs[0];
            return strs[GetRandomInt(0, strs.Length - 1, rand)];
        }

        /// <summary>
        /// Метод возвращает случайную строку из переданных строк
        /// </summary>
        /// <returns></returns>
        public static string GetRandomString(params string[] strs)
        {
            return GetRandomString(null, strs);
        }

        /// <summary>
        /// Метод возвращает случайную строку из переданного списка строк
        /// </summary>
        /// <returns></returns>
        public static string GetRandomString(List<string> list, Random rand)
        {
            if (list == null || list.Count == 0) 
                throw new ArgumentOutOfRangeException("strs");
            if (list.Count == 1) 
                return list[0];
            return list[GetRandomInt(0, list.Count - 1, rand)];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GetRandomString(List<string> list)
        {
            return GetRandomString(list, null);
        }

        #endregion
    }
}
