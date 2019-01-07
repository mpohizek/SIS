namespace Sigurnost_SQLite_BP
{
    partial class AdminWindow
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
            this.tbOIme = new System.Windows.Forms.TextBox();
            this.tbOUpravitelj = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDodajOdjel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbZEmail = new System.Windows.Forms.TextBox();
            this.btnDodajZaposlenika = new System.Windows.Forms.Button();
            this.tbZOdjel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbZBankovniRacun = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbZIznosPlace = new System.Windows.Forms.TextBox();
            this.tbZIme = new System.Windows.Forms.TextBox();
            this.tbZAdresa = new System.Windows.Forms.TextBox();
            this.tbZPrezime = new System.Windows.Forms.TextBox();
            this.tbZKorime = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbOIme
            // 
            this.tbOIme.Location = new System.Drawing.Point(116, 55);
            this.tbOIme.Name = "tbOIme";
            this.tbOIme.Size = new System.Drawing.Size(100, 20);
            this.tbOIme.TabIndex = 0;
            // 
            // tbOUpravitelj
            // 
            this.tbOUpravitelj.Location = new System.Drawing.Point(116, 94);
            this.tbOUpravitelj.Name = "tbOUpravitelj";
            this.tbOUpravitelj.Size = new System.Drawing.Size(100, 20);
            this.tbOUpravitelj.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDodajOdjel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbOIme);
            this.groupBox1.Controls.Add(this.tbOUpravitelj);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 299);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Odjel";
            // 
            // btnDodajOdjel
            // 
            this.btnDodajOdjel.Location = new System.Drawing.Point(67, 257);
            this.btnDodajOdjel.Name = "btnDodajOdjel";
            this.btnDodajOdjel.Size = new System.Drawing.Size(157, 23);
            this.btnDodajOdjel.TabIndex = 16;
            this.btnDodajOdjel.Text = "Dodaj odjel";
            this.btnDodajOdjel.UseVisualStyleBackColor = true;
            this.btnDodajOdjel.Click += new System.EventHandler(this.btnDodajOdjel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Upravitelj";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ime";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbZEmail);
            this.groupBox2.Controls.Add(this.btnDodajZaposlenika);
            this.groupBox2.Controls.Add(this.tbZOdjel);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbZBankovniRacun);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbZIznosPlace);
            this.groupBox2.Controls.Add(this.tbZIme);
            this.groupBox2.Controls.Add(this.tbZAdresa);
            this.groupBox2.Controls.Add(this.tbZPrezime);
            this.groupBox2.Controls.Add(this.tbZKorime);
            this.groupBox2.Location = new System.Drawing.Point(323, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 299);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zaposlenik";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "Email adresa";
            // 
            // tbZEmail
            // 
            this.tbZEmail.Location = new System.Drawing.Point(124, 112);
            this.tbZEmail.Name = "tbZEmail";
            this.tbZEmail.Size = new System.Drawing.Size(135, 20);
            this.tbZEmail.TabIndex = 18;
            // 
            // btnDodajZaposlenika
            // 
            this.btnDodajZaposlenika.Location = new System.Drawing.Point(72, 257);
            this.btnDodajZaposlenika.Name = "btnDodajZaposlenika";
            this.btnDodajZaposlenika.Size = new System.Drawing.Size(142, 23);
            this.btnDodajZaposlenika.TabIndex = 17;
            this.btnDodajZaposlenika.Text = "Dodaj zaposlenika";
            this.btnDodajZaposlenika.UseVisualStyleBackColor = true;
            this.btnDodajZaposlenika.Click += new System.EventHandler(this.btnDodajZaposlenika_Click);
            // 
            // tbZOdjel
            // 
            this.tbZOdjel.Location = new System.Drawing.Point(124, 216);
            this.tbZOdjel.Name = "tbZOdjel";
            this.tbZOdjel.Size = new System.Drawing.Size(135, 20);
            this.tbZOdjel.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Odjel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Bankovni račun";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Iznos plaće";
            // 
            // tbZBankovniRacun
            // 
            this.tbZBankovniRacun.Location = new System.Drawing.Point(124, 190);
            this.tbZBankovniRacun.Name = "tbZBankovniRacun";
            this.tbZBankovniRacun.Size = new System.Drawing.Size(135, 20);
            this.tbZBankovniRacun.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Adresa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Korisničko ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Prezime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ime";
            // 
            // tbZIznosPlace
            // 
            this.tbZIznosPlace.Location = new System.Drawing.Point(124, 164);
            this.tbZIznosPlace.Name = "tbZIznosPlace";
            this.tbZIznosPlace.Size = new System.Drawing.Size(135, 20);
            this.tbZIznosPlace.TabIndex = 4;
            // 
            // tbZIme
            // 
            this.tbZIme.Location = new System.Drawing.Point(124, 34);
            this.tbZIme.Name = "tbZIme";
            this.tbZIme.Size = new System.Drawing.Size(135, 20);
            this.tbZIme.TabIndex = 0;
            // 
            // tbZAdresa
            // 
            this.tbZAdresa.Location = new System.Drawing.Point(124, 138);
            this.tbZAdresa.Name = "tbZAdresa";
            this.tbZAdresa.Size = new System.Drawing.Size(135, 20);
            this.tbZAdresa.TabIndex = 3;
            // 
            // tbZPrezime
            // 
            this.tbZPrezime.Location = new System.Drawing.Point(124, 60);
            this.tbZPrezime.Name = "tbZPrezime";
            this.tbZPrezime.Size = new System.Drawing.Size(135, 20);
            this.tbZPrezime.TabIndex = 1;
            // 
            // tbZKorime
            // 
            this.tbZKorime.Location = new System.Drawing.Point(124, 86);
            this.tbZKorime.Name = "tbZKorime";
            this.tbZKorime.Size = new System.Drawing.Size(135, 20);
            this.tbZKorime.TabIndex = 2;
            // 
            // AdminWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 345);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminWindow";
            this.Text = "AdminWindow";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbOIme;
        private System.Windows.Forms.TextBox tbOUpravitelj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbZOdjel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbZBankovniRacun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbZIznosPlace;
        private System.Windows.Forms.TextBox tbZIme;
        private System.Windows.Forms.TextBox tbZAdresa;
        private System.Windows.Forms.TextBox tbZPrezime;
        private System.Windows.Forms.TextBox tbZKorime;
        private System.Windows.Forms.Button btnDodajOdjel;
        private System.Windows.Forms.Button btnDodajZaposlenika;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbZEmail;
    }
}