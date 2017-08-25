using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Main
{
    /// <summary>
    /// Набор функций для перевода строки в 16-ричный код и обратно
    /// </summary>
    class HexConverter
    {
        public static string ArrayToHex(byte[] bytes)
        {
            string hexString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                hexString += bytes[i].ToString("X2");
            }
            return hexString;
        }
        public static byte[] HexToArray(string hexString)
        {
            // if odd number of characters, discard last character
            if (hexString.Length % 2 != 0)
            {
                hexString = hexString.Substring(0, hexString.Length - 1);
            }

            int byteLength = hexString.Length / 2;
            byte[] bytes = new byte[byteLength];
            string hex;
            int j = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                hex = new String(new Char[] { hexString[j], hexString[j + 1] });
                bytes[i] = HexToByte(hex);
                j = j + 2;
            }
            return bytes;
        }
        public static byte[] StringToBytes(string text)
        {
            return Encoding.ASCII.GetBytes(text.ToCharArray());
        }
        private static byte HexToByte(string hex)
        {
            if (hex.Length > 2 || hex.Length <= 0)
                throw new ArgumentException("hex must be 1 or 2 characters in length");
            byte newByte = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return newByte;
        }
    }

    /// <summary>
    /// Набор функций для шифрования, вычисления Hash и проверки цифровой подписи
    /// </summary>
    class CryptUtils
    {
        /// <summary>
        /// Получение Hash из строки
        /// </summary>
        /// <param name="text">Исходная строка</param>
        /// <returns>Hash исходной строки в 16-ричном виде</returns>
        public static string GetHash(string text)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(text.ToCharArray());
            return HexConverter.ArrayToHex(sha1.ComputeHash(data, 0, data.Length));
        }

        /// <summary>
        /// Шифрование строки открытым ключем
        /// </summary>
        /// <param name="text">Исходная строка</param>
        /// <param name="publicKey">Открытый ключ для шифрования</param>
        /// <returns>Зашифрованная открытым ключем исходная строка в 16-ричном виде</returns>
        public static string Encrypt(string text, string publicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);

            string temp_str, res_str = "";
            int next = 0;
            int size = rsa.KeySize / 8 - 11;
            int len = text.Length;
            do
            {
                if (next + size >= len)
                    size = len - next;
                temp_str = text.Substring(next, size);
                next += size;
                byte[] bytes_to_encrypt = Encoding.Default.GetBytes(temp_str);
                byte[] encrypted_bytes = rsa.Encrypt(bytes_to_encrypt, false);
                res_str += HexConverter.ArrayToHex(encrypted_bytes);
            }
            while (next < len);
            return res_str;
        }

        public static string Decrypt(string text, string privateKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);

            int size = rsa.KeySize / 8 * 2;
            string temp_str = "", res_str = "";
            int next = 0, len = text.Length;
            do
            {
                if (next + size >= len)
                    size = len - next;
                temp_str = text.Substring(next, size);
                next += size;
                res_str += Encoding.Default.GetString(rsa.Decrypt(HexConverter.HexToArray(temp_str), false));
            } while (next < len);
            return res_str;
        }

        /// <summary>
        /// Подписывает текст закрытым ключем
        /// </summary>
        /// <param name="text">Подписываемый текст</param>
        /// <param name="privateKey">Закрытый ключ</param>
        /// <returns></returns>
        public static string Sign(string text, string privateKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);
            byte[] res = rsa.SignData(HexConverter.StringToBytes(text), new SHA1CryptoServiceProvider());
            return HexConverter.ArrayToHex(res);
        }

        /// <summary>
        /// Проверка подлинности подписи текста
        /// </summary>
        /// <param name="text">Подписанный текст</param>
        /// <param name="sign">Цифровая подпись в 16-ричном виде</param>
        /// <param name="openKey">Открытый ключ для проверки подписи</param>
        /// <returns>True, если подпись подходит</returns>
        public static bool VerifySign(string text, string sign, string publicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            return rsa.VerifyData(HexConverter.StringToBytes(text), new SHA1CryptoServiceProvider(), HexConverter.HexToArray(sign));
        }
    }
}
