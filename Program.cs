using BokhyllanWFA;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace BokhyllanWFA
{
    static class Program
    {
        public class FileLoader
        {
            //Metod som öppnar och läser en textfil till boklistan
            public static void OpenFile(string filePath){

                    //Skapar en lista som håller i strängvektorer
                    List<string[]> booksToImport = new List<string[]>();

                    //Försök att öppna och läsa filen
                    try
                    {
                        //Skapar en ny lista som håller i vanliga strängar
                        List<string> itemSaver = new List<string>();

                        //Skapar en ny FileStream som öppnar filen och en StreamReader som läser av vad som matas in i FileStreamen
                        FileStream inStröm = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        using (StreamReader läsare = new StreamReader(inStröm, Encoding.Default))
                        {
                            string filText = "";

                            //Sålänge vad StreamReader skriver till variabeln "filText" inte
                            //är lika med null så läggs strängen till i stränglistan itemSaver.
                            //Returnerar variabeln null innebär det att vi nått slutet av listan.
                            //Loopen bryts och StreamWritern går till garbage collection.
                            while ((filText = läsare.ReadLine()) != null)
                            {
                                itemSaver.Add(filText);
                            }
                        }

                        //För varje sträng i listan "itemSaver" skapas en ny strängvektor som sedan
                        //läggs till i strängvektorlistan "booksToImport". Splitmetoden bestämmer var strängarna ska kapas
                        //för att sedan lagras separat.
                        foreach (string a in itemSaver)
                        {
                            string[] vektor = a.Split(new string[] { "###" }, StringSplitOptions.None);
                            booksToImport.Add(vektor);
                        }

                        //För varje strängvektor i listan; skapa ett Bok-objekt.
                        //Varje index i strängvektorn innehåller information om en enskild egenskap.
                        foreach (string[] item in booksToImport)
                        {
                            string titel = item[0];
                            string skribent = item[1];
                            string typ = item[2];
                            bool tillänglig = true;
                            int utgivningsår = 0;//Mina Bok-objekt kräver ett utgivningsår och jag fick inte modifiera textfilen

                            if (item[3] != "true")
                            {
                                tillänglig = false;
                            }

                            Bibliotekarie.SkapaBok(titel, skribent, utgivningsår, typ, tillänglig);
                        }
                    }
                    //Det enda som kan krascha öppningen och läsningen av filen är att filen är i fel format på något sätt.
                    //Därför räcker det med att alla Exceptions får samma meddelande här
                    catch (Exception)
                    {
                        MessageBox.Show(
                            "Ogiltigt filformat...\n\nFilen måste ha filändelsen \".txt\" och vara formaterad på följande sätt:\n\n" +
                            "string###string###string###bool\n" +
                            "Titel###Författare###Typ###tillänglighet\n" +
                            "Pippi Långstrump###Astrid Lindgren###Roman###true", "Whoops!", MessageBoxButtons.OK);
                    }
            }

            //Metod som exporterar boklistan till en textfil
            public static void ExportFile(string filePath)
            {
                try
                {
                    FileStream utStröm = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    using (StreamWriter skrivare = new StreamWriter(utStröm, Encoding.Default))
                    {
                        skrivare.Write(Bibliotekarie.ExporteraBokLista());
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ogiltigt namn eller filformat...\n\nSpara filen med filändelsen \".txt\"", "", MessageBoxButtons.OK);
                    throw;
                }
            }
        }

        sealed public class Bibliotekarie
        {
            //Skapar en ny lista som håller i 'Bok-objekt'
            static private List<Bok> bokLista = new List<Bok>();

            static private int senastTipsadeBok;

            //Metod som lägger till böcker i boklistan
            public static string SkapaBok(string titel, string skribent, int utgivningsår, string typ, bool tillänglig)
            {
                bool bookAlreadyExists = false;
                foreach (Bok bok in bokLista)
                {
                    if (bok.Titel == titel)
                    {
                        bookAlreadyExists = true;
                    }
                }
                if (bookAlreadyExists)
                {
                    return "\n\tBoken finns redan i Biblioteket...";
                }
                else
                {
                    switch (typ)//Beroende på vilken Boktyp användaren valt så skapas motsvarande klassobjekt
                    {
                        case "Novellsamling":
                            bokLista.Add(new Novellsamling(titel, skribent, utgivningsår, tillänglig));
                            return "\n\tBoken har lagts till i Biblioteket!";
                            break;
                        case "Tidskrift":
                            bokLista.Add(new Tidskrift(titel, skribent, utgivningsår, tillänglig));
                            return "\n\tBoken har lagts till i Biblioteket!";
                            break;
                        case "Roman":
                            bokLista.Add(new Roman(titel, skribent, utgivningsår, tillänglig));
                            return "\n\tBoken har lagts till i Biblioteket!";
                            break;
                        default:
                            return "\n\tAll information om boken måste fyllas i\n\t" +
                                "innan den kan läggas till i biblioteket...";
                            break;
                    }
                }
            }

            //Metod som matar ut hela boklistan
            public static string HämtaBokLista()
            {
                string resultatlista = "";

                if (bokLista.Count != 0)//Om boklistan inte är tom
                {
                    foreach (Bok Bok in bokLista)//Går igenom varje Bok-objekt i boklistan och läggar till alla resultat i resultatlistan
                    {
                        resultatlista += "\n\n\tTitel:\t\t" + Bok.Titel +
                        "\n\tSkribent:\t\t" + Bok.Skribent +
                        "\n\tUtgivningsår:\t" + Bok.Utgivningsår +
                        "\n\tTyp:\t\t" + Bok.Typ +
                        "\n\t" + Bok.ToString();
                    }
                    resultatlista += "\n\n";
                }else
                {
                    resultatlista = "\n\tDet finns inga böcker i bokhyllan. . .";
                }
                return resultatlista;
            }

            //Metod som genomför sökning
            public static string SökBok(string titel, string skribent, int utgivningsår, string typ, string searchCriteria)
            {
                string resultatlista = "";

                switch (searchCriteria)
                {
                    case "Titel":
                        foreach (Bok Bok in bokLista)
                        {
                            if (Bok.Titel.Contains(titel))
                            {
                                resultatlista += "\n\n\tTitel:\t\t" + Bok.Titel +
                                                    "\n\tSkribent:\t\t" + Bok.Skribent +
                                                    "\n\tUtgivningsår:\t" + Bok.Utgivningsår +
                                                    "\n\tTyp:\t\t" + Bok.Typ +
                                                    "\n\t" + Bok.ToString();
                            }
                        }
                        resultatlista += "\n\n";
                        break;
                    case "Skribent":
                        foreach (Bok Bok in bokLista)
                        {

                            if (Bok.Skribent.Contains(skribent))
                            {
                                resultatlista += "\n\n\tTitel:\t\t" + Bok.Titel +
                                                    "\n\tSkribent:\t\t" + Bok.Skribent +
                                                    "\n\tUtgivningsår:\t" + Bok.Utgivningsår +
                                                    "\n\tTyp:\t\t" + Bok.Typ +
                                                    "\n\t" + Bok.ToString();
                            }
                        }
                        resultatlista += "\n\n";
                        break;
                    case "Utgivningsår":
                        foreach (Bok Bok in bokLista)
                        {
                            if (Bok.Utgivningsår == utgivningsår)
                            {
                                resultatlista += "\n\n\tTitel:\t\t" + Bok.Titel +
                                                    "\n\tSkribent:\t\t" + Bok.Skribent +
                                                    "\n\tUtgivningsår:\t" + Bok.Utgivningsår +
                                                    "\n\tTyp:\t\t" + Bok.Typ +
                                                    "\n\t" + Bok.ToString();
                            }
                        }
                        resultatlista += "\n\n";
                        break;
                    case "Typ":
                        foreach (Bok Bok in bokLista)
                        {
                            if (Bok.Typ == typ)
                            {
                                resultatlista += "\n\n\tTitel:\t\t" + Bok.Titel +
                                                    "\n\tSkribent:\t\t" + Bok.Skribent +
                                                    "\n\tUtgivningsår:\t" + Bok.Utgivningsår +
                                                    "\n\tTyp:\t\t" + Bok.Typ +
                                                    "\n\t" + Bok.ToString();
                            }
                        }
                        break;
                    default:
                        break;
                }

                if (resultatlista == "")
                {
                    resultatlista = "\n\tDen önskade boken finns inte i bokyllan. . .";
                }
                return resultatlista;
            }

            //Rensar boklistan
            public static void RaderaBöcker()
            {
                bokLista.Clear();
            }
            
            //Metod som returnerar antalet lagrade böcker(objekt) i bokLista
            public static int AntalLagradeBöcker()
            {
                return bokLista.Count;
            }

            //Metod som sparar boklistan som en sträng i det önskade formatet.
            //Hade gärna använt mig av en foreach-loop här istället men kunde inte lista ut
            //hur jag skulle få den sista loopen att inte skriva en extra tom rad efter det sista objektet.
            //Den extra tomma raden kraschade programmet när man läste in den sparade filen igen så
            //den enda lösningen var att skriva det sista objektet utanför en for-loop istället.
            public static string ExporteraBokLista()
            {
                string attExportera = "";

                for (int i = 0; i <= bokLista.Count - 2; i++)
                {
                    attExportera += bokLista[i].Titel + "###" +
                       bokLista[i].Skribent + "###" +
                       bokLista[i].Typ + "###" +
                       bokLista[i].Tillänglig.ToString().ToLower() + "\r\n";
                }

                if (attExportera != "")
                {
                    attExportera += bokLista[bokLista.Count - 1].Titel + "###" +
                       bokLista[bokLista.Count - 1].Skribent + "###" +
                       bokLista[bokLista.Count - 1].Typ + "###" +
                       bokLista[bokLista.Count - 1].Tillänglig.ToString().ToLower();
                }
                

                return attExportera;
            }

            //Metod för Tipsmaskinen
            //Om boklistan inte är tom slumpas ett tal från 0 till antalet böcker i listan minus 1(för att matcha indexering).
            //Om tipset är detsamma som det förra slumpas ett nytt tal tills man får ett som inte matchar det föregående.
            //Metoden returnerar sedan den önskade boken som en sträng.
            //Tyvärr är koden rätt så messy här
            public static string TipsaBok()
            {
                string boktips = "";
                string tillänglig = "Boken är tillänglig";
                Random randomNumber = new Random();
                int randomBookNumber = 0;

                if (Bibliotekarie.AntalLagradeBöcker() == 0)
                {
                    boktips = "\n\tDet finns inga böcker i Biblioteket...";
                }
                else if (Bibliotekarie.AntalLagradeBöcker() == 1)
                {
                    if (!bokLista[0].Tillänglig)
                    {
                        tillänglig = "Boken är utlånad";
                    }

                    boktips = "\n\tHär är ett lästips från Tipsmaskinen:\n" + "\n\n\tTitel:\t\t" + bokLista[0].Titel +
                       "\n\tSkribent:\t\t" + bokLista[0].Skribent +
                       "\n\tUtgivningsår:\t" + bokLista[0].Utgivningsår +
                       "\n\tTyp:\t\t" + bokLista[0].Typ +
                       "\n\t" + bokLista[0].ToString();
                }
                else if (Bibliotekarie.AntalLagradeBöcker() == 2)
                {
                    while (randomBookNumber == senastTipsadeBok)
                    {
                        randomBookNumber = randomNumber.Next(0, Bibliotekarie.AntalLagradeBöcker());
                    }

                    if (!bokLista[randomBookNumber].Tillänglig)
                    {
                        tillänglig = "Boken är utlånad";
                    }

                    boktips = "\n\tHär är ett lästips från Tipsmaskinen:\n" + "\n\n\tTitel:\t\t" + bokLista[randomBookNumber].Titel +
                       "\n\tSkribent:\t\t" + bokLista[randomBookNumber].Skribent +
                       "\n\tUtgivningsår:\t" + bokLista[randomBookNumber].Utgivningsår +
                       "\n\tTyp:\t\t" + bokLista[randomBookNumber].Typ +
                       "\n\t" + bokLista[randomBookNumber].ToString();

                    senastTipsadeBok = randomBookNumber;
                }
                else
                {
                    while (randomBookNumber == senastTipsadeBok)
                    {
                        randomBookNumber = randomNumber.Next(0, Bibliotekarie.AntalLagradeBöcker() - 1);
                    }
                    
                    if (!bokLista[randomBookNumber].Tillänglig)
                    {
                        tillänglig = "Boken är utlånad";
                    }

                    boktips = "\n\tHär är ett lästips från Tipsmaskinen:\n" + "\n\n\tTitel:\t\t" + bokLista[randomBookNumber].Titel +
                       "\n\tSkribent:\t\t" + bokLista[randomBookNumber].Skribent +
                       "\n\tUtgivningsår:\t" + bokLista[randomBookNumber].Utgivningsår +
                       "\n\tTyp:\t\t" + bokLista[randomBookNumber].Typ +
                       "\n\t" + bokLista[randomBookNumber].ToString();

                    senastTipsadeBok = randomBookNumber;
                }
                return boktips;
            }
        }


        //Superklassen Bok. Innehåller 4 egenskaper varav 3 manipuleras med en konstruktor som tar emot 3 parametrar
        //Den sista egenskapen, 'Typ', manipuleras av underklasserna till klassen Bok
        internal abstract class Bok
        {
            internal string Titel;
            internal string Skribent;
            internal int Utgivningsår;
            internal string Typ;
            internal bool Tillänglig;

            internal Bok(string indataTitel, string indataSkribent, int indataUtgivningsår, bool indataTillänglig)
            {
                Titel = indataTitel;
                Skribent = indataSkribent;
                Utgivningsår = indataUtgivningsår;
                Tillänglig = indataTillänglig;
            }
        }

        //Underklasser av Bok. Ärver klassen Bok's egenskaper.
        //Den fjärde egenskapen 'Typ' får ett bestämt värde beroende på vilken underklass som används för att skapa ett objekt
        internal class Novellsamling : Bok
        {
            internal Novellsamling(string indataTitel, string indataSkribent, int indataUtgivningsår, bool indataTillänglig) :
                base(indataTitel, indataSkribent, indataUtgivningsår, indataTillänglig)
            {
                Typ = "Novellsamling";
            }

            public override string ToString()
            {
                string tillänglig = "Boken är tillänglig";
                if (!Tillänglig)
                {
                    tillänglig = "Boken är utlånad";
                }
                return "Avdelning:\tNovellsamlingsavdelningen, duh!\n\tStatus:\t\t" + tillänglig;
            }
        }

        internal class Tidskrift : Bok
        {
            internal Tidskrift(string indataTitel, string indataSkribent, int indataUtgivningsår, bool indataTillänglig) :
                base(indataTitel, indataSkribent, indataUtgivningsår, indataTillänglig)
            {
                Typ = "Tidskrift";
            }

            public override string ToString()
            {
                string tillänglig = "Boken är tillänglig";
                if (!Tillänglig)
                {
                    tillänglig = "Boken är utlånad";
                }
                return "Avdelning:\tTidningshyllan\n\tStatus:\t\t" + tillänglig;
            }
        }

        internal class Roman : Bok
        {
            internal Roman(string indataTitel, string indataSkribent, int indataUtgivningsår, bool indataTillänglig) :
                base(indataTitel, indataSkribent, indataUtgivningsår, indataTillänglig)
            {
                Typ = "Roman";
            }

            public override string ToString()
            {
                string tillänglig = "Boken är tillänglig";
                if (!Tillänglig)
                {
                    tillänglig = "Boken är utlånad";
                }
                return "Avdelning:\tSkönlitteratur\n\tStatus:\t\t" + tillänglig;
            }



            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}