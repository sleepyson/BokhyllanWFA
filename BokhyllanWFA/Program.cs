using System;
using System.Windows.Forms;

namespace BokhyllanWFA
{
    static class Program
    {
        //Huvudklassen Bok. Innehåller 4 egenskaper varav 3 manipuleras med en konstruktor som tar emot 3 parametrar.
        //Den sista egenskapen, 'Typ', manipuleras av underklasserna till klassen Bok
        public abstract class Bok
        {
            public string Titel;
            public string Skribent;
            public int Utgivningsår;
            public string Typ;

            public Bok(string indataTitel, string indataSkribent, int indataUtgivningsår)
            {
                Titel = indataTitel;
                Skribent = indataSkribent;
                Utgivningsår = indataUtgivningsår;
            }
        }

        //Underklasser av Bok. Ärver klassen Bok's egenskaper.
        //Den fjärde egenskapen 'Typ' får ett bestämt värde beroende på vilken underklass som används för att skapa ett objekt
        public class GrafiskNovell : Bok
        {
            public GrafiskNovell(string indataTitel, string indataSkribent, int indataUtgivningsår) :
                base(indataTitel, indataSkribent, indataUtgivningsår)
            {
                Typ = "Grafisk Novell";
            }
        }

        public class Tidskrift : Bok
        {
            public Tidskrift(string indataTitel, string indataSkribent, int indataUtgivningsår) :
                base(indataTitel, indataSkribent, indataUtgivningsår)
            {
                Typ = "Tidskrift";
            }
        }

        public class Roman : Bok
        {
            public Roman(string indataTitel, string indataSkribent, int indataUtgivningsår) :
                base(indataTitel, indataSkribent, indataUtgivningsår)
            {
                Typ = "Roman";
            }
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
