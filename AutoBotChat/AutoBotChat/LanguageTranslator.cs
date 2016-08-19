using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EloBuddy.SDK.Menu.Values;


/**
*
*
* LanguageTranslator.cs made by Jachicao
*
*/

namespace AutoBotChat
{
    public enum Language
    {
        English,
        Spanish      
    }

    public static class LanguageTranslator
    {
        private static readonly Dictionary<Language, Dictionary<string, string>> Translations =
            new Dictionary<Language, Dictionary<string, string>>();

        private static readonly Dictionary<string, Language> CulturesToLanguage = new Dictionary<string, Language>
        {
            { "en-US", Language.English },           
            { "es-ES", Language.Spanish }
        };

        static LanguageTranslator()
        {
            Translations[Language.English] = new Dictionary<string, string>
            {
                { "Language", "Language" },
                { "English", "English"},
                { "Enabled", "Enabled" },
                { "Disabled", "Disabled" },
                { "Available", "Available" }
           
            };
            Translations[Language.Spanish] = new Dictionary<string, string>
            {
                { "Language", "Idioma" },
                { "Spanish", "Español" },
                { "Enabled", "Activado" },
                { "Disabled", "Desactivado" },
                { "Available", "Disponible" }
            };           
        }

        public static Language CurrentLanguage
        {
            get { return (Language)MenuManager.Menu["Language"].Cast<Slider>().CurrentValue; }
        }

        public static Language CurrentCulture
        {
            get
            {
                if (CulturesToLanguage.ContainsKey(CultureInfo.InstalledUICulture.ToString()))
                {
                    return CulturesToLanguage[CultureInfo.InstalledUICulture.ToString()];
                }
                return Language.English;
            }
        }

        public static void Initialize()
        {
            MenuManager.Translate(Language.English, (Language)MenuManager.Menu["Language"].Cast<Slider>().CurrentValue);
        }

        public static string GetTranslationFromId(this string name)
        {
            if (Translations.ContainsKey(CurrentLanguage) && Translations[CurrentLanguage].ContainsKey(name))
            {
                return Translations[CurrentLanguage][name];
            }
            if (Translations.ContainsKey(Language.English))
            {
                if (Translations[Language.English].ContainsKey(name))
                {
                    return Translations[Language.English][name];
                }
            }
            return name;
        }

        public static string GetTranslationFromDisplayName(Language from, Language to, string displayName)
        {
            if (from != to)
            {
                if (Translations.ContainsKey(from))
                {
                    foreach (var pair in from pair in Translations[@from]
                                         where pair.Value == displayName
                                         where Translations.ContainsKey(to)
                                         where Translations[to].ContainsKey(pair.Key)
                                         select pair)
                    {
                        return Translations[to][pair.Key];
                    }
                }
                if (Translations.ContainsKey(Language.English))
                {
                    return (from pair in Translations[Language.English]
                            where pair.Value == displayName
                            where Translations.ContainsKey(to)
                            where Translations[to].ContainsKey(pair.Key)
                            select Translations[to][pair.Key]).FirstOrDefault();
                }
            }
            return null;
        }
    }
}