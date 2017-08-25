using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Utils
{
    public class NameComparer 
    {
        public static string GetNameSearchKey(string name) { 

            //Второй вариант — пожалуй, лучший.
            //Заменяет ЙО, ЙЕ и др.; неплохо оптимизирован.
            const string alf = "ОЕАИУЭЮЯПСТРКЛМНБВГДЖЗЙФХЦЧШЩЁЫ"; 
            const string cns1 = "БЗДВГ";
            const string cns2 = "ПСТФК";
            const string cns3 = "ПСТКБВГДЖЗФХЦЧШЩ";
            const string ch = "ОЮЕЭЯЁЫ";
            const string ct = "АУИИАИА";
            
            char c;
            string s = "";
            //Переводим в верхний регистр, оставляем только
            //символы из alf и копируем в S:
            name = name.ToUpper();
            for(int i = 0; i < name.Length;i++)
            {
                c = name[i];
                if(alf.Contains(c))
                    s = s + c;
            }
            if(s.Length == 0)
                return "";
   
            // Сжимаем окончания:
            s = s.Replace("!", ""); // убираем !, из фамилии
            s = s + '!'; // для того, что бы определить, где конец фамилии
            s = s.Replace("ОВСКИЙ!", "@");
                s = s.Replace("ЕВСКИЙ!","#");
                s = s.Replace("ОВСКАЯ!","$");
                s = s.Replace("ЕВСКАЯ!","%");
                s = s.Replace("УК!", "0");
                s = s.Replace("ЮК!", "0");
                s = s.Replace("ИНА!", "1");
                s = s.Replace("ИК!", "2");
                s = s.Replace("ЕК!", "2");
                s = s.Replace("НКО!", "3");
                s = s.Replace("ИЕВ!", "4"); 
                s = s.Replace("ЕЕВ!", "4");
                s = s.Replace("ОВ!", "4");
                s = s.Replace("ЕВ!", "4");
                s = s.Replace("ЫХ!", "5");
                s = s.Replace("ИХ!", "5");
                s = s.Replace("АЯ!", "6");
                s = s.Replace("ИЙ!", "7");
                s = s.Replace("ЫЙ!", "7");
                s = s.Replace("ИН!", "8");
                s = s.Replace("ИЕВА!","9");
                s = s.Replace("ЕЕВА!","9");
                s = s.Replace("ОВА!", "9");
                s = s.Replace("ЕВА!", "9");
            s = s.Replace("!", ""); // убираем !, из фамилии

            //Оглушаем последний символ, если он - звонкий согласный:
            string last = s.Substring(s.Length - 1, 1);
            
            int pos = cns1.IndexOf(last);
            if(pos != -1){
                last = cns2.Substring(pos, 1);
                s = s.Substring(0, s.Length - 1) + last;
            }
            char old_c = ' ';
   
            string V = "";
            //Основной цикл:
            for(int i = 0; i < s.Length ; i++){
                c = s[i];
                int b = ch.IndexOf(c);
                if ( b > -1){ // Если гласная
                    if (old_c == 'Й' || old_c == 'И'){
                        if(c == 'О' || c == 'Е'){// Буквосочетания с гласной)
                            old_c = 'И';//: Mid$(V, Len(V), 1) = old_c
                            V = V.Substring(V.Length - 1) + old_c;
                        }
                        else{//Если не буквосочетания с гласной, а просто гласная
                            if(c != old_c) {
                                V = V + ct[b];
                            }
                        }
                    }
                    else{//Если не буквосочетания с гласной, а просто гласная
                        if(c != old_c)
                            V = V + ct[b];
                    }

                }
                else{ // Если согласная
                    if(c != old_c){ //'для «Аввакумов»
                        if (cns3.Contains(c)) {// 'Оглушение согласных
                            b = cns1.IndexOf(old_c);
                            if(b > -1) {
                                old_c = cns2[b]; V = V.Substring(V.Length - 1) + old_c;
                            }
                        }
                        if (c != old_c) V = V + c; // 'для «Шмидт»
                    }
                }
                old_c = c;
            }
            return V;
        }

        public static int Compare(string x, string y)
        {
            return GetNameSearchKey(x).CompareTo(GetNameSearchKey(y));
        }
    }
}
