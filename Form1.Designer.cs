namespace Cronometro
{
    partial class mainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrm));
            this.watchLb = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMaTempo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMeTempo = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btReinicio = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.udHora = new System.Windows.Forms.NumericUpDown();
            this.udMin = new System.Windows.Forms.NumericUpDown();
            this.udSeg = new System.Windows.Forms.NumericUpDown();
            this.ckDesliga = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSeg)).BeginInit();
            this.SuspendLayout();
            // 
            // watchLb
            // 
            this.watchLb.AutoSize = true;
            this.watchLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watchLb.ForeColor = System.Drawing.Color.MediumBlue;
            this.watchLb.Location = new System.Drawing.Point(56, 24);
            this.watchLb.Name = "watchLb";
            this.watchLb.Size = new System.Drawing.Size(167, 31);
            this.watchLb.TabIndex = 0;
            this.watchLb.Text = "Cronometro";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(75, 313);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 36);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Fechar";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Image = ((System.Drawing.Image)(resources.GetObject("BtnStart.Image")));
            this.BtnStart.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BtnStart.Location = new System.Drawing.Point(62, 224);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(150, 41);
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "Iniciar";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.mnMaTempo,
            this.mnMeTempo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(278, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.aboutToolStripMenuItem.Text = "Sobre";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
            this.aboutToolStripMenuItem1.Text = "Sobre";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // mnMaTempo
            // 
            this.mnMaTempo.Enabled = false;
            this.mnMaTempo.Name = "mnMaTempo";
            this.mnMaTempo.Size = new System.Drawing.Size(92, 20);
            this.mnMaTempo.Text = "Somar Tempo";
            this.mnMaTempo.Click += new System.EventHandler(this.mnMaTempo_Click);
            // 
            // mnMeTempo
            // 
            this.mnMeTempo.Enabled = false;
            this.mnMeTempo.Name = "mnMeTempo";
            this.mnMeTempo.Size = new System.Drawing.Size(99, 20);
            this.mnMeTempo.Text = "Subtrair Tempo";
            this.mnMeTempo.Click += new System.EventHandler(this.mnMeTempo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(61, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 90);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(28, 55);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(106, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Regressivo";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(25, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(109, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Progressivo";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btReinicio
            // 
            this.btReinicio.Enabled = false;
            this.btReinicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReinicio.Location = new System.Drawing.Point(75, 271);
            this.btReinicio.Name = "btReinicio";
            this.btReinicio.Size = new System.Drawing.Size(120, 36);
            this.btReinicio.TabIndex = 7;
            this.btReinicio.Text = "Zerar";
            this.btReinicio.UseVisualStyleBackColor = true;
            this.btReinicio.Click += new System.EventHandler(this.btReinicio_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(30, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(218, 23);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // udHora
            // 
            this.udHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udHora.Location = new System.Drawing.Point(62, 183);
            this.udHora.Name = "udHora";
            this.udHora.Size = new System.Drawing.Size(45, 35);
            this.udHora.TabIndex = 9;
            this.udHora.Visible = false;
            this.udHora.ValueChanged += new System.EventHandler(this.udHora_ValueChanged);
            // 
            // udMin
            // 
            this.udMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udMin.Location = new System.Drawing.Point(114, 183);
            this.udMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.udMin.Name = "udMin";
            this.udMin.Size = new System.Drawing.Size(45, 35);
            this.udMin.TabIndex = 10;
            this.udMin.Visible = false;
            this.udMin.ValueChanged += new System.EventHandler(this.udMin_ValueChanged);
            // 
            // udSeg
            // 
            this.udSeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udSeg.Location = new System.Drawing.Point(166, 183);
            this.udSeg.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.udSeg.Name = "udSeg";
            this.udSeg.Size = new System.Drawing.Size(45, 35);
            this.udSeg.TabIndex = 11;
            this.udSeg.Visible = false;
            this.udSeg.ValueChanged += new System.EventHandler(this.udSeg_ValueChanged);
            // 
            // ckDesliga
            // 
            this.ckDesliga.AutoSize = true;
            this.ckDesliga.Location = new System.Drawing.Point(232, 201);
            this.ckDesliga.Name = "ckDesliga";
            this.ckDesliga.Size = new System.Drawing.Size(34, 17);
            this.ckDesliga.TabIndex = 12;
            this.ckDesliga.Text = "D";
            this.ckDesliga.UseVisualStyleBackColor = true;
            this.ckDesliga.Visible = false;
            this.ckDesliga.CheckedChanged += new System.EventHandler(this.ckDesliga_CheckedChanged);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 357);
            this.Controls.Add(this.ckDesliga);
            this.Controls.Add(this.btReinicio);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.udSeg);
            this.Controls.Add(this.udMin);
            this.Controls.Add(this.udHora);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.watchLb);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "mainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cronometro";
            this.Load += new System.EventHandler(this.mainFrm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSeg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label watchLb;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btReinicio;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem mnMaTempo;
        private System.Windows.Forms.ToolStripMenuItem mnMeTempo;
        private System.Windows.Forms.NumericUpDown udHora;
        private System.Windows.Forms.NumericUpDown udMin;
        private System.Windows.Forms.NumericUpDown udSeg;
        private System.Windows.Forms.CheckBox ckDesliga;
    }
}

