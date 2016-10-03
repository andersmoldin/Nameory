using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nameory
{
    public partial class Nameory : Form
    {
        public Nameory(bool expert, int group, int typeOfGame)
        {
            InitializeComponent();
            
            // Kör igång initiering av spel och själva spelet.
            RunGame(expert, group, (GamePlay)typeOfGame);
        }

        private void nyttSpelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Stänger spelfönstret och skickar tillbaka "OK" till NewGame-formen som öppnade det.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void nameButton1_Click(object sender, EventArgs e)
        {
            // Kollar svaret när knapp 1 klickas
            CheckAnswer((Button)sender, e);
        }

        private void nameButton2_Click(object sender, EventArgs e)
        {
            // Kollar svaret när knapp 2 klickas
            CheckAnswer((Button)sender, e);
        }

        private void nameButton3_Click(object sender, EventArgs e)
        {
            // Kollar svaret när knapp 3 klickas
            CheckAnswer((Button)sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // När timern gått angiven tid (1000 ms) stannas den, avaktiveras och spelet tar nästa steg.
            timer1.Stop();
            timer1.Enabled = false;
            PlayGame();
        }
    }
}
