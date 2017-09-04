using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using TA.Utils;
using TA.DB.Manager;

namespace TA.Main
{
    class LicenseManager
    {
        /// <summary>
        /// Открытый ключ разбит на несколько частей
        /// </summary>
        private static string sPublicKeyA = @"<RSAKeyValue><Modulus>pgc1UbrkY3beCTKFDdr/l//0d6qe6dwvG2sGHziVd1sh3+";
        private const string DATEFORMAT = "yyyyMMdd";
#if FEDITION
        public static Guid SoftwareGuid = new Guid("{dbe3f87b-0a24-48dd-beaf-d6a187a00449}");
#endif
#if STANDARD
        public static Guid SoftwareGuid = new Guid("{dbe3f87b-0a24-48dd-beaf-d6a187a00448}");
#endif
/*#if DEBUG
        public static Guid SoftwareGuid = new Guid("{dbe3f87b-0a24-48dd-beaf-d6a187a00449}");
#endif*/


        private static string sPublicKeyC = @"ve0xup2gwHrpMNBEWJCYzwtO56RpKXtsv+DXoGBpLBmLKX/";
        private static string sPublicKeyD = @"ve0xup2gwHjsdLKJlkdjLKJlkjsLJlklkjiKJLKJlkLKlk/";
        private static string sPublicKeyE = @"1rAE8QU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        // использовать ключ A+B+C+E

        /// <summary>
        /// Имя польователя
        /// </summary>
        public static string UserName
        {
            get {
                return DatabaseManager.CurrentDb.GetParamValue(0, "USERNAME");
            }
            set {
                DatabaseManager.CurrentDb.SetParamValue(0, "USERNAME", value);
            }
        }
        /// <summary>
        /// Организация
        /// </summary>
        public static string Organization
        {
            get {
                return DatabaseManager.CurrentDb.GetParamValue(0, "ORGANIZATION");
            }
            set {
                DatabaseManager.CurrentDb.SetParamValue(0, "ORGANIZATION", value);
            }
        }
        /// <summary>
        /// e-mail пользователя для связи
        /// </summary>
        public static string EMail
        {
            get
            {
                return DatabaseManager.CurrentDb.GetParamValue(0, "EMAIL");
            }
            set
            {
                DatabaseManager.CurrentDb.SetParamValue(0, "EMAIL", value);
            }
        }
        /// <summary>
        /// Дата истечения лицензии
        /// </summary>
        public static string LicenseExpireDate
        {
            get
            {
                return DatabaseManager.CurrentDb.GetParamValue(0, "EXP_DATE");
            }
            set
            {
                DatabaseManager.CurrentDb.SetParamValue(0, "EXP_DATE", value);
            }
        }
        public static string LicenseExpireDateFormated
        {
            get {
                string str = LicenseExpireDate;
                if (str != "" && str.Length == 8)
                    return str.Substring(6, 2) + "-" + str.Substring(4, 2) + "-" + str.Substring(0, 4);
                return LicenseExpireDate;
            }
        }
        /// <summary>
        /// Идентификатор экземпляра программы
        /// </summary>
        public static string InstanceGuid
        {
            get
            {
                return DatabaseManager.CurrentDb.GetParamValue(0, "INSTANCE_GUID");
            }
            set
            {
                DatabaseManager.CurrentDb.SetParamValue(0, "INSTANCE_GUID", value);
            }
        }
        /// <summary>
        /// Зашифрованная дата истечения лицензии и дата установки Windows
        /// </summary>
        public static string LicenseExpireDateKey
        {
            get
            {
                return DatabaseManager.CurrentDb.GetParamValue(0, "EXP_DATE_KEY");
            }
            set
            {
                DatabaseManager.CurrentDb.SetParamValue(0, "EXP_DATE_KEY", value);
            }
        }
        /// <summary>
        /// Регистрационный ключ (Дата истечения лицензии, Дата установки Windows, Edition, Software GIUD, UserName, Organization, EMail)
        /// </summary>
        public static string LicenseKey
        {
            get
            {
                string value = "";
                string str = "";
                int i = 1;
                do
                {
                    str = DatabaseManager.CurrentDb.GetParamValue(0, "LIC_KEY" + i.ToString());
                    value = value + str;
                    i++;
                } while (str != "");
                return value;
            }
            set
            {
                int i = 1; const int MAX_LENGHT = 50;
                do{
                    if (value.Length > MAX_LENGHT)
                    {
                        DatabaseManager.CurrentDb.SetParamValue(0, "LIC_KEY" + i.ToString(), value.Substring(0, MAX_LENGHT));
                        value = value.Substring(MAX_LENGHT);
                    }
                    else
                    {
                        DatabaseManager.CurrentDb.SetParamValue(0, "LIC_KEY" + i.ToString(), value);
                        value = "";
                    }
                    i++;
                }while(value.Length > 0);

            }
        }


        private string Dummy
        {
            get {
                return sPublicKeyD;
            }
        }

        /// <summary>
        /// Возвращает ХЭШ(дата истечения лицензии, SoftwareGuid, Edition, ХЭШ(WinIfno))
        /// </summary>
        /// <param name="licenseExpireDateString">дата истечения лицензии</param>
        /// <returns></returns>
        private static string GetWinInfoHash(string licenseExpireDateString)
        {
            return CryptUtils.GetHash(licenseExpireDateString + SoftwareGuid.ToString() + Corel.EditionManager.EditionString + CryptUtils.GetHash(WinInfo.GetInfo()));
        }
        public static string ToXmlString()
        {
            return String.Format(@"<ActivationKey UserName='{0}' Organization='{1}' EMail='{2}' AppGuid='{3}' Edition='{4}' WinInfo='{5}' ExpireDate='{6}' InstanceGuid='{7}'/>",
                UserName, Organization, EMail, SoftwareGuid.ToString(),
                Corel.EditionManager.EditionString, CryptUtils.GetHash(WinInfo.GetInfo()), LicenseExpireDate, InstanceGuid);
        }

        /*static void ReadInfoFromRegistry()
        {
            Utils.IniFile ini = Settings.IniFile;
            Organization = ini.GetString("Reginfo", "Organization", "");
            UserName = ini.GetString("Reginfo", "UserName", "");
            EMail = ini.GetString("Reginfo", "EMail", "");
            LicenseExpireDate = ini.GetString("Reginfo", "ExpireDate", DateTime.MinValue.ToString(DATEFORMAT));
            LicenseExpireDateKey = ini.GetString("Reginfo", "ExpireDateKey", "");
            LicenseKey = ini.GetString("Reginfo", "LicenseKey", "");
        }*/
        /*
        public static void WriteUserInfoToRegistry()
        {


            Utils.IniFile ini = Settings.IniFile;
            ini.Write("Reginfo", "Organization", Organization);
            ini.Write("Reginfo", "UserName", UserName);
            ini.Write("Reginfo", "EMail", EMail);
        }*/
        /*
        static void WriteLicenseExpireDateToRegistry()
        {
            Utils.IniFile ini = Settings.IniFile;
            ini.Write("Reginfo", "ExpireDate", LicenseExpireDate);
            ini.Write("Reginfo", "ExpireDateKey", LicenseExpireDateKey);
        }*/

        public static bool CheckRegistration()
        {
            TA.Corel.EditionManager.IsTrial = true; // будем считать, что это trial-версия
            if (LicenseExpireDate == "")//DateTime.MinValue.ToString(DATEFORMAT))
            { // Дата окончания срока лицензии не установлена, значит это первый запуск программы
                if (!TA.DB.Manager.DatabaseManager.CurrentDb.IsDatabaseEmpty)
                {
                    // Если БД не пустая, заначит это не первый запуск программы
                    // Просим пользователя зарегистрироваться
                    // Если пользователь откажется регистрироваться, программа завершится
                    ShowRegistrationWindow(true);
                }
                else
                {
                    TA.Corel.EditionManager.IsTrial = true; // будем считать, что это trial-версия
                    // Устанавливаем дату окончания trial-периода
                    // сохраняем информацию в файл или БД
                    LicenseExpireDate = WinInfo.GetPageFileDate().AddMonths(1).ToString(DATEFORMAT);
                    InstanceGuid = Guid.NewGuid().ToString();
                    // Формируем строку, подписывающую дату окончания срока действия
                    // во избежаниие ручного изменения
                    LicenseExpireDateKey = GetWinInfoHash(LicenseExpireDate + InstanceGuid);
                    //WriteLicenseExpireDateToRegistry();
                    WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("TRIAL_DATE"," ") + LicenseExpireDateFormated);
                }
            }
            else
            { // Дата окончания срока действия лицензии уже установлена, значит это не первый запуск
                if (LicenseKey != "")
                { // Уже есть лицензия
                    if (CryptUtils.VerifySign(GetWinInfoHash(LicenseExpireDate + InstanceGuid), LicenseKey, sPublicKeyA + ImportPlayers.sPublicKeyB + sPublicKeyC + sPublicKeyE))
                    { // Это правильная лицензия

                        if (LicenseExpireDate.CompareTo(WinInfo.GetCurrentDate().AddMonths(1).ToString(DATEFORMAT)) > 0)
                        {
                            TA.Corel.EditionManager.IsTrial = false;
                            return true; // До окончания срока действия лицензии осталось больше 30 дней
                        }

                        if (LicenseExpireDate.CompareTo(WinInfo.GetCurrentDate().ToString(DATEFORMAT)) < 0)
                        {
                            TA.Corel.EditionManager.IsTrial = true;
                            ShowRegistrationWindow(true); // Срок действия лицензии закончился, предлагаем продлить. Если нет, то завершаем приложение
                        }
                        else
                        {
                            TA.Corel.EditionManager.IsTrial = false;
                            ShowRegistrationWindow(false); // Срок действия лицензии скоро закончится, предлагаем продлить. Если нет, то продолжаем выполнение программы
                        }
                    }
                    else
                    { // Целостность лицензии нарушена
                        TA.Corel.EditionManager.IsTrial = true;
                        ShowRegistrationWindow(true); // предлагаем Продлить. Если нет, то завершаем приложение
                        //TA.Corel.EditionManager.IsTrial = true; // будем считать, что это trial-версия
                        //WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("ACTIVATION_KEY_CORRUPTED"));
                        //throw new Exception(Localizator.Dictionary.GetString("ACTIVATION_KEY_CORRUPTED"));
                    }
                }
                else
                { // Лицензии еще нет, значит это trial-период
                    TA.Corel.EditionManager.IsTrial = true;
                    if (GetWinInfoHash(LicenseExpireDate + InstanceGuid) == LicenseExpireDateKey)
                    { // Успешно пройдена проверка подписи под датой окончания срока действия лицензии
                        if (LicenseExpireDate.CompareTo(WinInfo.GetCurrentDate().ToString(DATEFORMAT)) < 0)
                        {   // Срок действия trial_лицензии закончился
                            // просим зарегистрироваться, иначе завершаем приложение
                            ShowRegistrationWindow(true);
                        }
                        else
                        {
                            // Срок действия trial-лицензии еще не вышел
                            if(LicenseExpireDate.CompareTo(WinInfo.GetCurrentDate().AddDays(20).ToString(DATEFORMAT)) > 0)
                                ShowRegistrationWindow(false);
                        }
                    }
                    else
                    { // Подпись под датой окончания лицензии нарушена
                      // просим зарегистрироваться, иначе завершаем приложение
                        ShowRegistrationWindow(true);
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Отображает окно регистрации программы
        /// </summary>
        /// <param name="closeIfFail">Если пользователь не захотел регистрироваться, то программа завершается</param>
        private static void ShowRegistrationWindow(bool closeIfFail)
        {
            bool result = false;
            string message = String.Format(Localizator.Dictionary.GetString("LICENSE_RENEW"), LicenseExpireDate);
            if (closeIfFail)
                message = Localizator.Dictionary.GetString("LICENSE_EXPIRE_RENEW");
            if (WindowSkin.MessageBox.Show(message, Localizator.Dictionary.GetString("LICENSE_DATE"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                result = fRegistationInfo.ShowRegistration();
                if (result)
                    TA.Corel.EditionManager.IsTrial = false;
            }
            if (closeIfFail && !result)
            {
                WindowSkin.MessageBox.Show(Localizator.Dictionary.GetString("LICENSE_EXPIRED"));
                throw new Exception(Localizator.Dictionary.GetString("LIC_EXPIRED"));
                //Thread.CurrentThread.Abort();
            }
        }

        static LicenseManager()
        {
            //ReadInfoFromRegistry();
        }

        public static bool AddRegistrationKey(string regKey)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(regKey);
            string date = doc.DocumentElement.Attributes["expireDate"].Value;
            string sign = doc.DocumentElement.Attributes["sign"].Value;
            if (CryptUtils.VerifySign(GetWinInfoHash(date + InstanceGuid), sign, sPublicKeyA + ImportPlayers.sPublicKeyB + sPublicKeyC + sPublicKeyE))
            {
                LicenseExpireDate = date;
                LicenseExpireDateKey = GetWinInfoHash(date + InstanceGuid);
                LicenseKey = sign;
                /*Utils.IniFile ini = Settings.IniFile;
                ini.Write("Reginfo", "ExpireDate", LicenseExpireDate);
                ini.Write("Reginfo", "ExpireDateKey", LicenseExpireDateKey);
                ini.Write("Reginfo", "LicenseKey", LicenseKey);*/
                return true;
            }
            return false;
        }
        internal static string GetActivationKey()
        {
            string xml_data = ToXmlString();
            return CryptUtils.Encrypt(ToXmlString(), sPublicKeyA + ImportPlayers.sPublicKeyB + sPublicKeyC + sPublicKeyE);
        }
        internal static bool ConfirmLicenseDate()
        {
            if (CryptUtils.VerifySign(GetWinInfoHash(LicenseExpireDate + InstanceGuid), LicenseKey, sPublicKeyA + ImportPlayers.sPublicKeyB + sPublicKeyC + sPublicKeyE))
            {
                if (LicenseExpireDate.CompareTo(WinInfo.GetCurrentDate().ToString(DATEFORMAT)) > 0)
                    return true;
            }
            return false;
        }
    }
}
