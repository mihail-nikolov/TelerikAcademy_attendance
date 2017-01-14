using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Exam_DSA_part1
{
    class Program
    {

        static Dictionary<string, string[]> pizzas = new Dictionary<string, string[]>
        {
            { "Mediteraneo", new string[] {"domaten sos - 104g", "krave sirene - 195g", "maslini - 56g", "motsarela - 122g", "presni domati - 30g", "testo: 256g", "zeleni chushki - 69g"} },
            { "Alfredo", new string[] {"beybi spanak - 127g", "motsarela - 194g", "pileshko file - 12g", "smetana - 191g", "testo: 256g" } },
            { "Vita", new string[] {"beybi spanak - 147g", "domaten sos - 59g", "krave sirene - 28g", "motsarela - 97g", "presni domati - 55g", "testo: 256g"} },
            { "Margarita", new string[] {"domaten sos - 6g", "motsarela - 152g", "testo: 256g"  } },
            { "Chikenita", new string[] {"domaten sos - 30g", "domati - 144g", "emental - 79g", "motsarela - 17g", "peperoni - 166g", "pileshko file - 199g", "testo: 256g"} },
            { "Dominos Spetsialna", new string[] {"bekon - 37g", "domaten sos - 161g", "gabi - 90g", "luk - 183g", "motsarela - 137g", "shunka - 181g", "testo: 256g", "zeleni chushki - 158g"} },
            { "ChikChiRik", new string[] {"domaten sos - 133g", "krehko pile - 64g", "motsarela - 20g", "testo: 256g", "topeno sirene - 166g", "tsarevitsa - 0g" } },
            { "Karbonara", new string[] {"bekon - 141g", "gabi - 160g", "motsarela - 158g", "smetana - 40g", "testo: 256g"} },
            { "Amerikan Hot", new string[] {"domaten sos - 82g", "halapenyo - 197g", "luk - 196g", "motsarela - 88g", "peperoni - 149g", "testo: 256g" } },
            { "Gardan Klasik", new string[] {"domaten sos - 165g", "gabi - 8g", "luk - 91g", "maslini - 194g", "motsarela - 165g", "presni domati - 86g", "testo: 256g", "zeleni chushki - 123g"} },
            { "Peperoni Klasik", new string[] {"domaten sos - 105g", "motsarela - 98g", "peperoni - 186g", "testo: 256g"  } },
            { "Barbekyu Pile", new string[] {"barbekyu sos - 195g", "bekon - 20g", "krehko pile - 26g", "motsarela - 169g", "testo: 256g" } },
            { "Barbekyu Klasik", new string[] {"barbekyu sos - 147g", "bekon - 150g", "motsarela - 175g", "pikantno teleshko - 104g", "testo: 256g"} },
            { "Nyu york", new string[] {"bekon - 151g", "chedar - 126g", "domaten sos - 177g", "motsarela - 152g", "presni gabi - 18g", "testo: 256g"} },
            { "Shunka Klasik", new string[] {"domaten sos - 110g", "motsarela - 74g", "presni gabi - 150g", "shunka - 26g", "testo: 256g", "zeleni chushki - 166g"} },
            { "Zverska", new string[] {"bekon - 78g", "domaten sos - 147g", "motsarela - 125g", "pikantno teleshko - 55g", "shunka - 9g", "testo: 256g"} },
            { "Italianska", new string[] {"bosilek - 30g", "domaten sos - 32g", "motsarela - 61g", "parmezan - 132g", "pesto - 79g", "presni domati - 60g", "testo: 256g"} },
            { "Havay", new string[] {"ananas - 47g", "domaten sos - 81g", "motsarela - 180g", "shunka - 90g", "testo: 256g"} },
            { "Balgarska", new string[] {"domaten sos - 175g", "krave sirene - 0g", "luk - 163g", "maslini - 146g", "motsarela - 45g", "presni domati - 53g", "rigan - 159g", "selska nadenitsa - 195g", "testo: 256g", "zeleni chushki - 110g"} },
            { "Formadzhi", new string[] {"chedar - 194g", "domaten sos - 72g", "krave sirene - 82g", "motsarela - 98g", "parmezan - 117g", "testo: 256g"} },
            { "Ton", new string[] {"domaten sos - 54g", "luk - 36g", "motsarela - 119g", "presni domati - 78g", "riba ton - 190g", "testo: 256g"} },
            { "Chorizana", new string[] {"chorizo - 161g", "domaten sos - 56g", "krave sirene - 197g", "motsarela - 102g", "pileshko file - 63g", "presni domati - 17g", "testo: 256g"} },
            { "Meat Mania", new string[] {"bekon - 129g", "chorizo - 182g", "domaten sos - 1g", "motsarela - 111g", "pileshko file - 86g", "shunka - 83g", "teleshko - 70g", "testo: 256g"} },
            { "Unika", new string[] {"domaten sos - 185g", "gabi - 49g", "motsarela - 177g", "parmezan - 114g", "peperoni - 44g", "presni domati - 86g", "rukola - 42g", "testo: 256g"} },
            { "Bene", new string[] {"domaten sos - 139g", "kashkaval - 93g", "maslini - 4g", "shunka - 129g", "testo: 256g", "tsarevitsa - 149g"} },
            { "Bondzhorno", new string[] {"domaten sos - 99g", "gabi - 86g", "kashkaval - 23g", "kiseli krastavichki - 91g", "svinsko file - 199g", "testo: 256g"} },
            { "Vegetarianska", new string[] {"chushki - 42g", "domaten sos - 9g", "gabi - 67g", "kashkaval - 184g", "luk - 42g", "testo: 256g", "tsarevitsa - 124g"} },
            { "Venetsiya", new string[] {"domaten sos - 148g", "gabi - 43g", "kashkaval - 47g", "luk - 122g", "pusheni gardi - 32g", "testo: 256g", "yaytse - 50g"} },
            { "Garda", new string[] {"chushki - 113g", "domaten sos - 84g", "kashkaval - 35g", "maslini - 151g", "pileshko role - 107g", "pusheno sirene - 197g", "testo: 256g"} },
            { "Kaltsone", new string[] {"domaten sos - 21g", "gabi - 127g", "kashkaval - 142g", "shunka - 195g", "testo: 256g"} },
            { "Kaprichoza", new string[] {"domaten sos - 40g", "gabi - 35g", "kashkaval - 22g", "magadanoz - 160g", "maslini - 88g", "presni domati - 14g", "pusheni gardi - 22g", "shunka - 10g", "testo: 256g", "yaytse - 57g"} },
            { "Kompaniola", new string[] {"bekon - 111g", "domaten sos - 16g", "gabi - 198g", "kashkaval - 87g", "rigan - 95g", "testo: 256g"} },
            { "Meksikana", new string[] {"domaten sos - 119g", "gabi - 88g", "kashkaval - 147g", "luk - 83g", "lukanka - 155g", "lyuta chushka - 60g", "testo: 256g", "tsarevitsa - 153g"} },
            { "Morski darove", new string[] {"domaten sos - 89g", "kalmari - 175g", "kashkaval - 66g", "limon - 142g", "midi - 6g", "rigan - 121g", "testo: 256g", "zehtin - 113g"} },
            { "Kastelo", new string[] {"bekon - 88g", "domaten sok - 195g", "kashkaval - 114g", "kiseli krastavichki - 179g", "maslini - 63g", "pileshko role - 30g", "pusheno sirene - 19g", "shunka - 89g", "testo: 256g"} },
            { "Prima Vera", new string[] {"bosilek - 4g", "domaten sos - 126g", "domati - 22g", "gabi - 44g", "kashkaval - 155g", "shunka - 26g", "testo: 256g", "zehtin - 64g"} },
            { "Proshuto", new string[] {"domaten sos - 58g", "kashkaval - 136g", "maslini - 136g", "proshuto - 100g", "shunka - 30g", "testo: 256g"} },
            { "Rimini", new string[] {"bekon - 23g", "chushki - 91g", "domaten sos - 55g", "gabi - 147g", "kashkaval - 81g", "lukanka - 188g", "shunka - 4g", "testo: 256g", "tsarevitsa - 57g", "yaytse - 60g"} },
            { "San Marko", new string[] {"domaten sos - 129g", "gabi - 106g", "kashkaval - 28g", "lukanka - 38g", "pusheno sirene - 91g", "testo: 256g", "zehtin - 62g"} },
            { "Tono", new string[] { "chesan - 142g","domaten sos - 155g", "kashkaval - 60g","limon - 106g","luk - 100g","ratsi - 124g","riba ton - 131g", "testo: 256g" } }
        };

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input.LastIndexOf('.') == -1)
            {
                input += Console.ReadLine();
            }
            Console.WriteLine(input);

        }

        static void EvaluateInput(string line)
        {

        }

    }
}

//List<string> products = new List<string>();

//var lines = File.ReadLines("file.txt");
//foreach (var item in lines)
//{
//    if (char.IsUpper(item[0]))
//    {
//        products.Add("testo: 256g");
//        var ordered = products.OrderBy(x => x);

//        string toAdd = "";
//        foreach (var pr in ordered)
//        {
//            toAdd += string.Format("\"{0}\", ", pr);
//        }


//        File.AppendAllText("toWrite.txt", toAdd);
//        File.AppendAllText("toWrite.txt", string.Format(" }} }}, \n {{ \"{0}\", new string[] {{", item));
//        products.Clear();
//        continue;
//    }

//    products.Add(string.Format("{0}", item));
//}