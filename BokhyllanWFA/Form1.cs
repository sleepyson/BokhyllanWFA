using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static BokhyllanWFA.Program;

namespace BokhyllanWFA
{

    public partial class Form1 : Form
    {
        //Skapar listan som skall hålla i våra Bok-objekt
        List<Program.Bok> bokHyllan = new List<Program.Bok>();

        public Form1()
        {
            InitializeComponent();
        }

        //Button som lägger till ny bok
        private void ButtonAddNewBook_Click(object sender, EventArgs e)
        {
            switch (userInputBoxTyp.Text)//Beroende på vilken Boktyp användaren valt så skapas motsvarande klass
            {
                case "Grafisk Novell":
                    bokHyllan.Add(new GrafiskNovell(userInputBoxTitel.Text, userInputBoxSkribent.Text, Convert.ToInt32(userInputBoxUtgivningsår.Value)));
                    break;
                case "Tidskrift":
                    bokHyllan.Add(new Tidskrift(userInputBoxTitel.Text,userInputBoxSkribent.Text, Convert.ToInt32(userInputBoxUtgivningsår.Value)));
                    break;
                case "Roman":
                    bokHyllan.Add(new Roman(userInputBoxTitel.Text, userInputBoxSkribent.Text, Convert.ToInt32(userInputBoxUtgivningsår.Value)));
                    break;
                default:
                    break;
            }

            outputBox.Text = "\n\tDu har lagt till följande bok i bokhyllan:" + SkrivUtBokInfo(bokHyllan[(int)bokHyllan.LongCount() - 1].Titel,
                                                    bokHyllan[(int)bokHyllan.LongCount() - 1].Skribent,
                                                    bokHyllan[(int)bokHyllan.LongCount() - 1].Utgivningsår,
                                                    bokHyllan[(int)bokHyllan.LongCount() - 1].Typ);
        }

        //Button som visar boklistan
        private void ButtonShowBookList_Click(object sender, EventArgs e)
        {
            switch (bokHyllan.LongCount())
            {
                case 0:
                    outputBox.Text = "\n\tDet finns inga böcker i bokhyllan...";
                    break;
                case 1:
                    outputBox.Text = "\n\tDet finns " + bokHyllan.LongCount() + " bok i bokhyllan:\n";
                    break;
                default:
                    outputBox.Text = "\n\tDet finns " + bokHyllan.LongCount() + " böcker i bokhyllan:\n";
                    break;
            }

            //Skriver ut varje Bok i som finns lagrad i listan bokHyllan
            foreach (var Bok in bokHyllan)
            {
                outputBox.Text += SkrivUtBokInfo(
                    Bok.Titel,
                    Bok.Skribent,
                    Bok.Utgivningsår,
                    Bok.Typ);

            }
        }

        //Button som rensar boklistan
        private void ButtonEraseBookList_Click(object sender, EventArgs e)
        {
            if (bokHyllan.LongCount() == 0) {//Om bokhyllan är tom så får användaren bara ett meddelande
                outputBox.Text = "\n\tDet finns inga böcker i bokhyllan...";
            }
            else
            {
                //Dialogruta där användaren ombedes att bekräfta rensningen av listan 
                if (MessageBox.Show("Är du säker på att du vill radera alla böcker i bokhyllan?", "Radera alla böcker!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bokHyllan.Clear();
                    outputBox.Text = ("\n\tAlla böcker har blivit raderade!");
                }
            }
        }

        //Metod som skriver ut egenskaperna för ett önskat Bok-objekt
        public static string SkrivUtBokInfo(string indataTitel, string indataSkribent, int indataUtgivningsår, string indataTyp)
        {
            return "\n\nTitel:\t\t" + indataTitel +
                    "\nSkribent:\t\t" + indataSkribent +
                    "\nUtgivningsår:\t" + indataUtgivningsår +
                    "\nTyp:\t\t" + indataTyp;
        }
    }
}
