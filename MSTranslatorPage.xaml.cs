﻿using Xamarin.Forms;
using System;
using System.Collections.Generic;

namespace MSTranslator
{
    public partial class MSTranslatorPage : ContentPage
    {
        public MSTranslatorPage()
        {
            InitializeComponent();

            //language dictionary
            Dictionary<string, string> lan = new Dictionary<string, string>
            {
                {"Afrikaans", "af"},
                {"Albanian", "sq"},
                {"Arabic", "ar"},
                {"Armenian", "hy"},
                {"Azerbaijani", "az"},
                {"Basque", "eu"},
                {"Belarusian", "be"},
                {"Bengali", "bn"},
                {"Bosnian", "bs"},
                {"Bulgarian", "bg"},
                {"Catalan", "ca"},
                {"Cebuano", "ceb"},
                {"Chichewa", "ny"},
                {"Chinese Simplified", "zh-cn"},
                {"Chinese Traditional", "zh-tw"},
                {"Corsican", "co"},
                {"Croatian", "hr"},
                {"Czech", "cs"},
                {"Danish", "da"},
                {"Dutch", "nl"},
                {"English", "en"},
                {"Esperanto", "eo"},
                {"Estonian", "et"},
                {"Filipino", "tl"},
                {"Finnish", "fi"},
                {"French", "fr"},
                {"Frisian", "fy"},
                {"Galician", "gl"},
                {"Georgian", "ka"},
                {"German", "de"},
                {"Greek", "el"},
                {"Gujarati", "gu"},
                {"Haitian Creole", "ht"},
                {"Hausa", "ha"},
                {"Hawaiian", "haw"},
                {"Hebrew", "iw"},
                {"Hindi", "hi"},
                {"Hmong", "hmn"},
                {"Hungarian", "hu"},
                {"Icelandic", "is"},
                {"Igbo", "ig"},
                {"Indonesian", "id"},
                {"Irish", "ga"},
                {"Italian", "it"},
                {"Japanese", "ja"},
                {"Javanese", "jw"},
                {"Kannada", "kn"},
                {"Kazakh", "kk"},
                {"Khmer", "km"},
                {"Korean", "ko"},
                {"Kurdish (Kurmanji)", "ku"},
                {"Kyrgyz", "ky"},
                {"Lao", "lo"},
                {"Latin", "la"},
                {"Latvian", "lv"},
                {"Lithuanian", "lt"},
                {"Luxembourgish", "lb"},
                {"Macedonian", "mk"},
                {"Malagasy", "mg"},
                {"Malay", "ms"},
                {"Malayalam", "ml"},
                {"Maltese", "mt"},
                {"Maori", "mi"},
                {"Marathi", "mr"},
                {"Mongolian", "mn"},
                {"Myanmar (Burmese)", "my"},
                {"Nepali", "ne"},
                {"Norwegian", "no"},
                {"Pashto", "ps"},
                {"Persian", "fa"},
                {"Polish", "pl"},
                {"Portuguese", "pt"},
                {"Punjabi", "ma"},
                {"Romanian", "ro"},
                {"Russian", "ru"},
                {"Samoan", "sm"},
                {"Scots Gaelic", "gd"},
                {"Serbian", "sr"},
                {"Sesotho", "st"},
                {"Shona", "sn"},
                {"Sindhi", "sd"},
                {"Sinhala", "si"},
                {"Slovak", "sk"},
                {"Slovenian", "sl"},
                {"Somali", "so"},
                {"Spanish", "es"},
                {"Sudanese", "su"},
                {"Swahili", "sw"},
                {"Swedish", "sv"},
                {"Tajik", "tg"},
                {"Tamil", "ta"},
                {"Telugu", "te"},
                {"Thai", "th"},
                {"Turkish", "tr"},
                {"Ukrainian", "uk"},
                {"Urdu", "ur"},
                {"Uzbek", "uz"},
                {"Vietnamese", "vi"},
                {"Welsh", "cy"},
                {"Xhosa", "xh"},
                {"Yiddish", "yi"},
                {"Yoruba", "yo"},
                {"Zulu", "zu"}

            };

            //add items to picker
            foreach(string language in lan.Keys){
                sourcePicker.Items.Add(language);
                targetPicker.Items.Add(language);
            }

            sourcePicker.SelectedItem = "English";
            targetPicker.SelectedItem = "Chinese Simplified";

            /* static void Translate(string text, string targetLanguageCode, string sourceLanguageCode)
            {
                TranslationClient client = TranslationClient.Create();
                var response = client.TranslateText(text, targetLanguageCode,
                    sourceLanguageCode);
                Console.WriteLine(response.TranslatedText);
            }*/
        }
    }
}
