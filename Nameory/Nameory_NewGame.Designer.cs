namespace Nameory
{
    partial class Nameory_NewGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.labelChooseGroup = new System.Windows.Forms.Label();
            this.comboBoxGroups = new System.Windows.Forms.ComboBox();
            this.checkBoxExpert = new System.Windows.Forms.CheckBox();
            this.labelChooseTypeOfGamePlay = new System.Windows.Forms.Label();
            this.radioButtonOneRound = new System.Windows.Forms.RadioButton();
            this.radioButtonLearnAllNames = new System.Windows.Forms.RadioButton();
            this.radioButtonContinuous = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Location = new System.Drawing.Point(12, 218);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(200, 26);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Sätt igång";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // labelChooseGroup
            // 
            this.labelChooseGroup.AutoSize = true;
            this.labelChooseGroup.Location = new System.Drawing.Point(13, 13);
            this.labelChooseGroup.Name = "labelChooseGroup";
            this.labelChooseGroup.Size = new System.Drawing.Size(67, 17);
            this.labelChooseGroup.TabIndex = 1;
            this.labelChooseGroup.Text = "Välj klass";
            // 
            // comboBoxGroups
            // 
            this.comboBoxGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroups.FormattingEnabled = true;
            this.comboBoxGroups.Location = new System.Drawing.Point(16, 34);
            this.comboBoxGroups.Name = "comboBoxGroups";
            this.comboBoxGroups.Size = new System.Drawing.Size(196, 24);
            this.comboBoxGroups.TabIndex = 2;
            // 
            // checkBoxExpert
            // 
            this.checkBoxExpert.AutoSize = true;
            this.checkBoxExpert.Location = new System.Drawing.Point(16, 65);
            this.checkBoxExpert.Name = "checkBoxExpert";
            this.checkBoxExpert.Size = new System.Drawing.Size(155, 21);
            this.checkBoxExpert.TabIndex = 3;
            this.checkBoxExpert.Text = "Expert (alla klasser)";
            this.checkBoxExpert.UseVisualStyleBackColor = true;
            this.checkBoxExpert.CheckedChanged += new System.EventHandler(this.checkBoxExpert_CheckedChanged);
            // 
            // labelChooseTypeOfGamePlay
            // 
            this.labelChooseTypeOfGamePlay.AutoSize = true;
            this.labelChooseTypeOfGamePlay.Location = new System.Drawing.Point(14, 115);
            this.labelChooseTypeOfGamePlay.Name = "labelChooseTypeOfGamePlay";
            this.labelChooseTypeOfGamePlay.Size = new System.Drawing.Size(84, 17);
            this.labelChooseTypeOfGamePlay.TabIndex = 5;
            this.labelChooseTypeOfGamePlay.Text = "Välj spelsätt";
            // 
            // radioButtonOneRound
            // 
            this.radioButtonOneRound.AutoSize = true;
            this.radioButtonOneRound.Checked = true;
            this.radioButtonOneRound.Location = new System.Drawing.Point(16, 135);
            this.radioButtonOneRound.Name = "radioButtonOneRound";
            this.radioButtonOneRound.Size = new System.Drawing.Size(196, 21);
            this.radioButtonOneRound.TabIndex = 6;
            this.radioButtonOneRound.TabStop = true;
            this.radioButtonOneRound.Text = "Hur många namn kan jag?";
            this.radioButtonOneRound.UseVisualStyleBackColor = true;
            // 
            // radioButtonLearnAllNames
            // 
            this.radioButtonLearnAllNames.AutoSize = true;
            this.radioButtonLearnAllNames.Location = new System.Drawing.Point(16, 163);
            this.radioButtonLearnAllNames.Name = "radioButtonLearnAllNames";
            this.radioButtonLearnAllNames.Size = new System.Drawing.Size(141, 21);
            this.radioButtonLearnAllNames.TabIndex = 7;
            this.radioButtonLearnAllNames.TabStop = true;
            this.radioButtonLearnAllNames.Text = "Lär mig alla namn";
            this.radioButtonLearnAllNames.UseVisualStyleBackColor = true;
            // 
            // radioButtonContinuous
            // 
            this.radioButtonContinuous.AutoSize = true;
            this.radioButtonContinuous.Location = new System.Drawing.Point(16, 191);
            this.radioButtonContinuous.Name = "radioButtonContinuous";
            this.radioButtonContinuous.Size = new System.Drawing.Size(82, 21);
            this.radioButtonContinuous.TabIndex = 8;
            this.radioButtonContinuous.TabStop = true;
            this.radioButtonContinuous.Text = "Nonstop";
            this.radioButtonContinuous.UseVisualStyleBackColor = true;
            // 
            // Nameory_NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 263);
            this.Controls.Add(this.radioButtonContinuous);
            this.Controls.Add(this.radioButtonLearnAllNames);
            this.Controls.Add(this.radioButtonOneRound);
            this.Controls.Add(this.labelChooseTypeOfGamePlay);
            this.Controls.Add(this.checkBoxExpert);
            this.Controls.Add(this.comboBoxGroups);
            this.Controls.Add(this.labelChooseGroup);
            this.Controls.Add(this.buttonStartGame);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(240, 310);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(240, 310);
            this.Name = "Nameory_NewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nytt spel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Label labelChooseGroup;
        private System.Windows.Forms.ComboBox comboBoxGroups;
        private System.Windows.Forms.CheckBox checkBoxExpert;
        private System.Windows.Forms.Label labelChooseTypeOfGamePlay;
        private System.Windows.Forms.RadioButton radioButtonOneRound;
        private System.Windows.Forms.RadioButton radioButtonLearnAllNames;
        private System.Windows.Forms.RadioButton radioButtonContinuous;
    }
}