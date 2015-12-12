using System;
using System.Collections.Generic;

namespace Notepad
{
    /// <summary>
    /// Provides two-direction transliteration
    /// </summary>
    static class Transliterate
    {
        /// <summary>
        /// EN -> RU transliteration dictionary
        /// </summary>
        static Dictionary<string, string> EN_RU_Dictionary = new Dictionary<string, string>();

        /// <summary>
        /// RU -> EN transliteration dictionary
        /// </summary>
        static Dictionary<string, string> RU_EN_Dictionary = new Dictionary<string, string>();


        /// <summary>
        /// Dictionaries initialization
        /// </summary>
        static Transliterate()
        {
            #region RU_EN_Dictionary
            RU_EN_Dictionary.Add("ий", "y");
            RU_EN_Dictionary.Add("ИЙ", "Y");
            RU_EN_Dictionary.Add("а", "a");
            RU_EN_Dictionary.Add("б", "b");
            RU_EN_Dictionary.Add("в", "v");
            RU_EN_Dictionary.Add("г", "g");
            RU_EN_Dictionary.Add("д", "d");
            RU_EN_Dictionary.Add("е", "e");
            RU_EN_Dictionary.Add("ё", "yo");
            RU_EN_Dictionary.Add("ж", "zh");
            RU_EN_Dictionary.Add("з", "z");
            RU_EN_Dictionary.Add("и", "i");
            RU_EN_Dictionary.Add("й", "j");
            RU_EN_Dictionary.Add("к", "k");
            RU_EN_Dictionary.Add("л", "l");
            RU_EN_Dictionary.Add("м", "m");
            RU_EN_Dictionary.Add("н", "n");
            RU_EN_Dictionary.Add("о", "o");
            RU_EN_Dictionary.Add("п", "p");
            RU_EN_Dictionary.Add("р", "r");
            RU_EN_Dictionary.Add("с", "s");
            RU_EN_Dictionary.Add("т", "t");
            RU_EN_Dictionary.Add("у", "u");
            RU_EN_Dictionary.Add("ф", "f");
            RU_EN_Dictionary.Add("х", "h");
            RU_EN_Dictionary.Add("ц", "c");
            RU_EN_Dictionary.Add("ч", "ch");
            RU_EN_Dictionary.Add("ш", "sh");
            RU_EN_Dictionary.Add("щ", "sch");
            RU_EN_Dictionary.Add("ъ", "j");
            RU_EN_Dictionary.Add("ы", "i");
            RU_EN_Dictionary.Add("ь", "j");
            RU_EN_Dictionary.Add("э", "e");
            RU_EN_Dictionary.Add("ю", "yu");
            RU_EN_Dictionary.Add("я", "ya");
            RU_EN_Dictionary.Add("А", "A");
            RU_EN_Dictionary.Add("Б", "B");
            RU_EN_Dictionary.Add("В", "V");
            RU_EN_Dictionary.Add("Г", "G");
            RU_EN_Dictionary.Add("Д", "D");
            RU_EN_Dictionary.Add("Е", "E");
            RU_EN_Dictionary.Add("Ё", "Yo");
            RU_EN_Dictionary.Add("Ж", "Zh");
            RU_EN_Dictionary.Add("З", "Z");
            RU_EN_Dictionary.Add("И", "I");
            RU_EN_Dictionary.Add("Й", "J");
            RU_EN_Dictionary.Add("К", "K");
            RU_EN_Dictionary.Add("Л", "L");
            RU_EN_Dictionary.Add("М", "M");
            RU_EN_Dictionary.Add("Н", "N");
            RU_EN_Dictionary.Add("О", "O");
            RU_EN_Dictionary.Add("П", "P");
            RU_EN_Dictionary.Add("Р", "R");
            RU_EN_Dictionary.Add("С", "S");
            RU_EN_Dictionary.Add("Т", "T");
            RU_EN_Dictionary.Add("У", "U");
            RU_EN_Dictionary.Add("Ф", "F");
            RU_EN_Dictionary.Add("Х", "H");
            RU_EN_Dictionary.Add("Ц", "C");
            RU_EN_Dictionary.Add("Ч", "Ch");
            RU_EN_Dictionary.Add("Ш", "Sh");
            RU_EN_Dictionary.Add("Щ", "Sch");
            RU_EN_Dictionary.Add("Ъ", "J");
            RU_EN_Dictionary.Add("Ы", "I");
            RU_EN_Dictionary.Add("Ь", "J");
            RU_EN_Dictionary.Add("Э", "E");
            RU_EN_Dictionary.Add("Ю", "Yu");
            RU_EN_Dictionary.Add("Я", "Ya");
            #endregion

            #region EN_RU_Dictionary
            EN_RU_Dictionary.Add("sch", "щ");
            EN_RU_Dictionary.Add("Sch", "Щ");
            EN_RU_Dictionary.Add("yo", "ё");
            EN_RU_Dictionary.Add("zh", "ж");
            EN_RU_Dictionary.Add("ch", "ч");
            EN_RU_Dictionary.Add("sh", "ш");
            EN_RU_Dictionary.Add("yu", "ю");
            EN_RU_Dictionary.Add("ya", "я");
            EN_RU_Dictionary.Add("Yo", "Ё");
            EN_RU_Dictionary.Add("Zh", "Ж");
            EN_RU_Dictionary.Add("Ch", "Ч");
            EN_RU_Dictionary.Add("Sh", "Ш");
            EN_RU_Dictionary.Add("Yu", "Ю");
            EN_RU_Dictionary.Add("Ya", "Я");
            EN_RU_Dictionary.Add("y", "ий");
            EN_RU_Dictionary.Add("Y", "ИЙ");
            EN_RU_Dictionary.Add("a", "а");
            EN_RU_Dictionary.Add("b", "б");
            EN_RU_Dictionary.Add("v", "в");
            EN_RU_Dictionary.Add("g", "г");
            EN_RU_Dictionary.Add("d", "д");
            EN_RU_Dictionary.Add("e", "е");
            EN_RU_Dictionary.Add("z", "з");
            EN_RU_Dictionary.Add("i", "и");
            EN_RU_Dictionary.Add("j", "й");
            EN_RU_Dictionary.Add("k", "к");
            EN_RU_Dictionary.Add("l", "л");
            EN_RU_Dictionary.Add("m", "м");
            EN_RU_Dictionary.Add("n", "н");
            EN_RU_Dictionary.Add("o", "о");
            EN_RU_Dictionary.Add("p", "п");
            EN_RU_Dictionary.Add("r", "р");
            EN_RU_Dictionary.Add("s", "с");
            EN_RU_Dictionary.Add("t", "т");
            EN_RU_Dictionary.Add("u", "у");
            EN_RU_Dictionary.Add("f", "ф");
            EN_RU_Dictionary.Add("h", "х");
            EN_RU_Dictionary.Add("c", "ц");
            EN_RU_Dictionary.Add("w", "в");
            EN_RU_Dictionary.Add("A", "А");
            EN_RU_Dictionary.Add("B", "Б");
            EN_RU_Dictionary.Add("V", "В");
            EN_RU_Dictionary.Add("G", "Г");
            EN_RU_Dictionary.Add("D", "Д");
            EN_RU_Dictionary.Add("E", "Е");
            EN_RU_Dictionary.Add("Z", "З");
            EN_RU_Dictionary.Add("I", "И");
            EN_RU_Dictionary.Add("J", "Й");
            EN_RU_Dictionary.Add("K", "К");
            EN_RU_Dictionary.Add("L", "Л");
            EN_RU_Dictionary.Add("M", "М");
            EN_RU_Dictionary.Add("N", "Н");
            EN_RU_Dictionary.Add("O", "О");
            EN_RU_Dictionary.Add("P", "П");
            EN_RU_Dictionary.Add("R", "Р");
            EN_RU_Dictionary.Add("S", "С");
            EN_RU_Dictionary.Add("T", "Т");
            EN_RU_Dictionary.Add("U", "У");
            EN_RU_Dictionary.Add("F", "Ф");
            EN_RU_Dictionary.Add("H", "Х");
            EN_RU_Dictionary.Add("C", "Ц");
            EN_RU_Dictionary.Add("W", "В");
            #endregion  
        }

        /// <summary>
        /// Transliterate EN into RU
        /// </summary>
        /// <param name="source">Source EN string</param>
        /// <returns>Transliterated string</returns>
        public static string EN_RU(string source)
        {
            foreach (KeyValuePair<string, string> pair in EN_RU_Dictionary)
                source = source.Replace(pair.Key, pair.Value);
            return source;
        }

        /// <summary>
        /// Transliterate RU into EN
        /// </summary>
        /// <param name="source">Source RU string</param>
        /// <returns>Transliterated string</returns>
        public static string RU_EN(string source)
        {
            foreach (KeyValuePair<string, string> pair in RU_EN_Dictionary)
                source = source.Replace(pair.Key, pair.Value);
            return source;
        }

        public static void A() { }
    }
}
