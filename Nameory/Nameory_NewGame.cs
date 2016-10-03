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
    public partial class Nameory_NewGame : Form
    {
        public Nameory_NewGame()
        {
            InitializeComponent();
            LoadSettings();
        }

        // Tänkt att ladda in inställningar
        public void LoadSettings()
        {
            // Just nu två hårdkodade klasser
            comboBoxGroups.Items.Add("C#.NET HT16");
            comboBoxGroups.Items.Add("JAVA HT16");

            /* För framtida hårdkodning av klasser
            comboBoxGroups.Items.Add("SOMMAR16");
            comboBoxGroups.Items.Add("VT16");
            comboBoxGroups.Items.Add("HT15");*/

            comboBoxGroups.SelectedIndex = 0;
        }

        // Starta spelet
        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            // Sätt gameType till den radiobutton som är vald
            int gameType = GetGameType(Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name);

            // Göm den här formen och nya upp en Nameory-form
            this.Hide();
            Nameory nameory = new Nameory(checkBoxExpert.Checked, comboBoxGroups.SelectedIndex, gameType);

            // Öppna upp Nameory-formen och om den stängs, stängs hela programmet
            // Annars kommer användaren välja "Nytt spel" och då kommer man tillbaka till den här formen.
            DialogResult myResult = nameory.ShowDialog();
            if (myResult == DialogResult.Cancel)
                this.Close();
            else
                this.Show();
        }

        private void checkBoxExpert_CheckedChanged(object sender, EventArgs e)
        {
            // Om expertrutan är i kryssad: inaktivera dropdownlistan och vice versa.
            comboBoxGroups.Enabled = !checkBoxExpert.Checked;
        }

        private int GetGameType(string buttonName)
        {
            switch (buttonName)
            {
                case "radioButtonOneRound":
                    return 0;
                case "radioButtonLearnAllNames":
                    return 1;
                case "radioButtonContinuous":
                    return 2;
                default:
                    return -1;
            }
        }
    }
}
