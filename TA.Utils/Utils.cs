using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.IO;

namespace TA.Utils
{
    public class Utils
    {
        /// <summary>
        /// Изменяет яркость цвета
        /// </summary>
        /// <param name="color">Исходный цвет</param>
        /// <param name="percent">Проценты изменения яркости >0 для увеличения <0 для уменьшения </param>
        /// <returns>Цвет с измененной яркостью</returns>
        public static Color ChangeBrightness(Color color, int percent) 
        {
            if (percent < 0)
            {
                return Color.FromArgb(color.R + color.R * percent / 100,
                                      color.G + color.G * percent / 100,
                                      color.B + color.B * percent / 100);
            }
            else {
                return Color.FromArgb(color.R + (255 - color.R) * percent / 100,
                                      color.G + (255 - color.G) * percent / 100,
                                      color.B + (255 - color.B) * percent / 100);
            }
        }
        /// <summary>
        /// Возвращает число с дробью
        /// </summary>
        /// <param name="points">Количество очков</param>
        /// <returns>Количество очков деленное пополам</returns>
        public static string GetHalfPointsString(int points)
        {
            int half = points / 2;
            if (points % 2 == 1)
            {
                if (points == 1)
                    return "½";
                else
                    return half.ToString() + "½";
            }
            else
            {
                return half.ToString();
            }
        }
        /// <summary>
        /// Возвращает число с дробью
        /// </summary>
        /// <param name="points">Количество очков</param>
        /// <returns>Количество очков с дробью</returns>
        public static string GetPointsString(double points) 
        {
            double A = Math.Truncate(points);
            double B = points - A;
            string sA = A.ToString();
            if (A == 0.0) sA = "";
            if (B == 0.5) return sA + "½";
            if (B == 0.25) return sA + "¼";
            if (B == 0.75) return sA + "¾";
            return points.ToString();
        }

        public static string GetRoundsLabelText(int round) 
        {
            switch (round) 
            {
                case 1:
                    return Localizator.Dictionary.GetString("FINAL");
                case 2:
                    return Localizator.Dictionary.GetString("SEMIFINALS");
                case 3:
                    return Localizator.Dictionary.GetString("QUARTER_FINALS");
                case 4:
                    return Localizator.Dictionary.GetString("EIGHT_FINALS");
                case 5:
                    return Localizator.Dictionary.GetString("16_FINALS");
                case 6:
                    return Localizator.Dictionary.GetString("32_FINALS");
                case 7:
                    return Localizator.Dictionary.GetString("64_FINALS");
            }
            return "";
        }
        public static string GetRoundLabelText(int round)
        {
            switch (round)
            {
                case 1:
                    return Localizator.Dictionary.GetString("FINAL");
                case 2:
                    return Localizator.Dictionary.GetString("SEMIFINAL");
                case 3:
                    return Localizator.Dictionary.GetString("QUARTER_FINAL");
                case 4:
                    return Localizator.Dictionary.GetString("EIGHT_FINAL");
                case 5:
                    return Localizator.Dictionary.GetString("16_FINAL");
                case 6:
                    return Localizator.Dictionary.GetString("32_FINAL");
                case 7:
                    return Localizator.Dictionary.GetString("64_FINAL");
            }
            return "";
        }


        public static DateTime GetLastBuildDate()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            DateTime date = DateTime.MinValue;
            foreach (Assembly assembly in assemblies)
            {
                FileInfo assemblyInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
                if (date < assemblyInfo.LastWriteTime)
                    date = assemblyInfo.LastWriteTime;
            }
            return date;
        }

        public static Guid IsNullGuid(object guid)
        {
            try
            {
                if (guid == null || guid.ToString() == "")
                    return Guid.Empty;
                return new Guid(guid.ToString());
            }
            catch (Exception) 
            {
                return Guid.Empty;
            }
        }
    }
}
