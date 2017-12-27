using Xamarin.Forms;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace MSTranslator
{
    public partial class MSTranslatorPage : ContentPage
    {
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

        public MSTranslatorPage()
        {
            InitializeComponent();

            //add items to picker
            foreach(string language in lan.Keys){
                sourcePicker.Items.Add(language);
                targetPicker.Items.Add(language);
            }

            sourcePicker.SelectedItem = "English";
            targetPicker.SelectedItem = "Chinese Simplified";


        }

        public async void Translate(object sender, EventArgs e)
        {
            //get the source and target languages
            string text = textEntry.Text;

            //if there is no input text
            if(text == ""){
                await DisplayAlert("Alert", "Input Text Needed", "OK");
                return;
            }

            string sourceLanguage = (string)sourcePicker.SelectedItem;
            string targetLanguage = (string)targetPicker.SelectedItem;

            // generate the request url
            string requestURL = string.Format(
                "https://translation.googleapis.com/language/translate/v2?key=AIzaSyC0ojhhpWRxKHWj7k5bI2sZh5SXejTVW9s&source={0}&target={1}&q={2}", 
                lan[sourceLanguage], lan[targetLanguage], text);

            var client = new HttpClient();
            var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("text", "This is a block of text"),
            });

            // send request and get response
            HttpResponseMessage response = await client.PostAsync(requestURL, requestContent);
            HttpContent responseContent = response.Content;

            // parse response
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                // Write the output.
                JObject jResponse = JObject.Parse(await reader.ReadToEndAsync());
                JObject ojObject = (JObject)jResponse["data"];
                JArray array = (JArray)ojObject["translations"];
                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(array[0].ToString());
                Result.Text = values["translatedText"];

                //add to history
                var his = new Label();
                his.Text = text + ": " + Result.Text;
                layout.Children.Add(his);
            }
        }

    }
}
