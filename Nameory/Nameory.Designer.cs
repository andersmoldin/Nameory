namespace Nameory
{
    partial class Nameory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nameory));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arkivToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nyttSpelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ljudAvpåToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inställningarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nameButton1 = new System.Windows.Forms.Button();
            this.nameButton2 = new System.Windows.Forms.Button();
            this.nameButton3 = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arkivToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(525, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arkivToolStripMenuItem
            // 
            this.arkivToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nyttSpelToolStripMenuItem,
            this.ljudAvpåToolStripMenuItem,
            this.inställningarToolStripMenuItem});
            this.arkivToolStripMenuItem.Name = "arkivToolStripMenuItem";
            this.arkivToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.arkivToolStripMenuItem.Text = "Arkiv";
            // 
            // nyttSpelToolStripMenuItem
            // 
            this.nyttSpelToolStripMenuItem.Name = "nyttSpelToolStripMenuItem";
            this.nyttSpelToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.nyttSpelToolStripMenuItem.Text = "Nytt spel";
            this.nyttSpelToolStripMenuItem.Click += new System.EventHandler(this.nyttSpelToolStripMenuItem_Click);
            // 
            // ljudAvpåToolStripMenuItem
            // 
            this.ljudAvpåToolStripMenuItem.Enabled = false;
            this.ljudAvpåToolStripMenuItem.Name = "ljudAvpåToolStripMenuItem";
            this.ljudAvpåToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.ljudAvpåToolStripMenuItem.Text = "Ljud av/på";
            // 
            // inställningarToolStripMenuItem
            // 
            this.inställningarToolStripMenuItem.Enabled = false;
            this.inställningarToolStripMenuItem.Name = "inställningarToolStripMenuItem";
            this.inställningarToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.inställningarToolStripMenuItem.Text = "Inställningar";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.Location = new System.Drawing.Point(0, 30);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(531, 2);
            this.progressBar1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(501, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // nameButton1
            // 
            this.nameButton1.Location = new System.Drawing.Point(12, 634);
            this.nameButton1.Name = "nameButton1";
            this.nameButton1.Size = new System.Drawing.Size(501, 46);
            this.nameButton1.TabIndex = 3;
            this.nameButton1.Text = "Namn 1";
            this.nameButton1.UseVisualStyleBackColor = true;
            this.nameButton1.Click += new System.EventHandler(this.nameButton1_Click);
            // 
            // nameButton2
            // 
            this.nameButton2.Location = new System.Drawing.Point(12, 686);
            this.nameButton2.Name = "nameButton2";
            this.nameButton2.Size = new System.Drawing.Size(501, 46);
            this.nameButton2.TabIndex = 4;
            this.nameButton2.Text = "Namn 2";
            this.nameButton2.UseVisualStyleBackColor = true;
            this.nameButton2.Click += new System.EventHandler(this.nameButton2_Click);
            // 
            // nameButton3
            // 
            this.nameButton3.Location = new System.Drawing.Point(12, 738);
            this.nameButton3.Name = "nameButton3";
            this.nameButton3.Size = new System.Drawing.Size(501, 46);
            this.nameButton3.TabIndex = 5;
            this.nameButton3.Text = "Namn 3";
            this.nameButton3.UseVisualStyleBackColor = true;
            this.nameButton3.Click += new System.EventHandler(this.nameButton3_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(12, 542);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(501, 89);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Nameory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 796);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameButton3);
            this.Controls.Add(this.nameButton2);
            this.Controls.Add(this.nameButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(543, 843);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(543, 843);
            this.Name = "Nameory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nameory";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arkivToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nyttSpelToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem ljudAvpåToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inställningarToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button nameButton1;
        private System.Windows.Forms.Button nameButton2;
        private System.Windows.Forms.Button nameButton3;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Timer timer1;
    }
}

