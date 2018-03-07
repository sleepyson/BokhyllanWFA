using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static BokhyllanWFA.Program;

namespace BokhyllanWFA
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //Button som lägger till ny bok
        private void ButtonAddNewBook_Click(object sender, EventArgs e)
        {
            outputBox.Text = Bibliotekarie.SkapaBok(
                userInputBoxTitel.Text, 
                userInputBoxSkribent.Text, 
                Convert.ToInt32(userInputBoxUtgivningsår.Value), 
                userInputBoxTyp.Text,
                true);
        }

        //Button som visar hela boklistan
        private void ButtonShowBookList_Click(object sender, EventArgs e)
        {
            outputBox.Text = Bibliotekarie.HämtaBokLista();
        }

        //Button som rensar boklistan
        private void ButtonEraseBookList_Click(object sender, EventArgs e)
        {
            Bibliotekarie.RaderaBöcker();
            outputBox.Text = "\n\tBokhyllan är nu tom. . .";
        }

        //Button för "sök efter bok"
        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            //Beroende på vilket sökkriterium som användaren valt så ändras den sista parametern i metoden SökBok()
            //Jag är säker på att det går att korta ner det gär på något sätt för att inte behöva nämna alla parametrar
            //vid varje sökning men har inte haft tid att leta upp någon lösning.
            if (checkBoxTitel.Checked)
            {
                outputBox.Text = Bibliotekarie.SökBok(userInputBoxTitel.Text, userInputBoxSkribent.Text, Convert.ToInt32(userInputBoxUtgivningsår.Value), userInputBoxTyp.Text, "Titel");
            }
            else if (checkBoxSkribent.Checked)
            {
                outputBox.Text = Bibliotekarie.SökBok(userInputBoxTitel.Text, userInputBoxSkribent.Text, Convert.ToInt32(userInputBoxUtgivningsår.Value), userInputBoxTyp.Text, "Skribent");
            }
            else if (checkBoxTyp.Checked)
            {
                outputBox.Text = Bibliotekarie.SökBok(userInputBoxTitel.Text, userInputBoxSkribent.Text, Convert.ToInt32(userInputBoxUtgivningsår.Value), userInputBoxTyp.Text, "Typ");
            }
            else if (checkBoxUtgivningsår.Checked)
            {
                outputBox.Text = Bibliotekarie.SökBok(userInputBoxTitel.Text, userInputBoxSkribent.Text, Convert.ToInt32(userInputBoxUtgivningsår.Value), userInputBoxTyp.Text, "Utgivningsår");
            }
            else outputBox.Text = "\n\tInget sökkriterium valt. . .";
        }


        //Begränsar helt enkelt sökningen till ett sökkriterium åt gången
        //När användaren bockar in ett kriterium bockas alla andra av
        private void checkBoxTitel_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxTyp.Checked = false;
            checkBoxUtgivningsår.Checked = false;
            checkBoxSkribent.Checked = false;
        }

        private void checkBoxUtgivningsår_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxTitel.Checked = false;
            checkBoxTyp.Checked = false;
            checkBoxSkribent.Checked = false;
        }

        private void checkBoxTyp_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxUtgivningsår.Checked = false;
            checkBoxTitel.Checked = false;
            checkBoxSkribent.Checked = false;
        }

        private void checkBoxSkribent_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxTitel.Checked = false;
            checkBoxTyp.Checked = false;
            checkBoxUtgivningsår.Checked = false;
        }

        //Button märkt "Tipsmaskinen"
        private void buttonTipsmaskinen_Click(object sender, EventArgs e)
        {
            outputBox.Text = Bibliotekarie.TipsaBok();
        }

        //"Öppna.." i menyn "Bibliotek"
        //Låter användaren välja en fil att importera till boklistan
        private void öppnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Visar en OpenFileDialog och sparar resultatet
            DialogResult resultatÖppnaFil = dlgÖppnaFil.ShowDialog();

            if (resultatÖppnaFil == DialogResult.OK)
            {
                FileLoader.OpenFile(dlgÖppnaFil.FileName);
            }
            
        }

        //"Spara.." i menyn "Bibliotek"
        //Exporterar boklistan till en textfil med ett format som går att läsa in igen
        private void sparaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultatSparaFil = dlgSparaFil.ShowDialog();

            if (resultatSparaFil == DialogResult.OK)
            {
                FileLoader.ExportFile(dlgSparaFil.FileName);
            }
        }
    }
}
