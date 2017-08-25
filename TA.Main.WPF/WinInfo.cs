using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace TA.Main
{
    /// <summary>
    /// Набор функций для доступа к системным ресурсам
    /// </summary>
    class WinInfo
    {
        /// <summary>
        /// Возвращает системную информацию Windows Serial Number
        /// </summary>
        /// <returns>Строка с системной информацией</returns>
        public static string GetInfo()
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_OperatingSystem");
                ManagementObjectCollection moc = mos.Get();

                System.Management.ManagementObjectCollection.ManagementObjectEnumerator oe = moc.GetEnumerator();
                StringBuilder res = new StringBuilder();
                foreach (ManagementObject mo in moc)
                {
                    System.Management.PropertyDataCollection.PropertyDataEnumerator
                    de = mo.Properties.GetEnumerator();
                    de.Reset();
                    while (de.MoveNext())
                    {
                        object Value = mo.Properties[de.Current.Name].Value;
                        if (Value == null)
                            Value = "";
                        res.Append(Value);
                    }
                }
                return res.ToString();
            }
            catch (Exception) 
            { 
                // Если выпала ошибка, то эти данные берем из реестра
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
                return key.GetValue("ProductId").ToString();
            }
        }
        /// <summary>
        /// Возвращает дату создания файла pagefile.sys
        /// </summary>
        /// <returns></returns>
        public static DateTime GetPageFileDate()
        {
            DateTime date = DateTime.Now;
            string regKey = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management";
            string[] value = (string[])Registry.GetValue(regKey, "PagingFiles", null);
            string FilePath = "";
            if (value != null && value[0] != null) 
            {
                int index = value[0].IndexOf(' ');
                if (index > 0)
                    FilePath = value[0].Substring(0, index);
                else
                    FilePath = value[0];
            }
                
            if (File.Exists(FilePath))
                date = File.GetLastAccessTime(FilePath);
            return date;
        }
        /// <summary>
        /// Возвращает текущую дату из случайных источников
        /// </summary>
        /// <returns></returns>
        public static DateTime GetCurrentDate() 
        {
            Random rnd = new Random();
            switch (rnd.Next(1)) 
            {
                case 0 :
                    return DateTime.Now;
                case 1:
                    return GetPageFileDate();
            }
            return DateTime.Now;            
        }
    }
}
