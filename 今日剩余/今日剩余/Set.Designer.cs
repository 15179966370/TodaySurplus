namespace 今日剩余
{
    partial class Set
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
            this.btnApplicationChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timeBarThicknessNL = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Color1 = new System.Windows.Forms.PictureBox();
            this.Color2 = new System.Windows.Forms.PictureBox();
            this.Color3 = new System.Windows.Forms.PictureBox();
            this.Color4 = new System.Windows.Forms.PictureBox();
            this.setHour = new System.Windows.Forms.TextBox();
            this.setMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.timeBarThicknessNL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApplicationChange
            // 
            this.btnApplicationChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApplicationChange.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApplicationChange.Location = new System.Drawing.Point(289, 242);
            this.btnApplicationChange.Name = "btnApplicationChange";
            this.btnApplicationChange.Size = new System.Drawing.Size(83, 33);
            this.btnApplicationChange.TabIndex = 0;
            this.btnApplicationChange.Text = "确认修改";
            this.btnApplicationChange.UseVisualStyleBackColor = true;
            this.btnApplicationChange.Click += new System.EventHandler(this.btnApplicationChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(159, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "今日剩余设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(27, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "时间条厚度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(27, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "各段颜色";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(27, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "关机时间";
            // 
            // timeBarThicknessNL
            // 
            this.timeBarThicknessNL.Location = new System.Drawing.Point(120, 48);
            this.timeBarThicknessNL.Name = "timeBarThicknessNL";
            this.timeBarThicknessNL.Size = new System.Drawing.Size(61, 25);
            this.timeBarThicknessNL.TabIndex = 5;
            this.timeBarThicknessNL.TabStop = false;
            this.timeBarThicknessNL.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Color1
            // 
            this.Color1.BackColor = System.Drawing.Color.Lime;
            this.Color1.Location = new System.Drawing.Point(112, 92);
            this.Color1.Name = "Color1";
            this.Color1.Size = new System.Drawing.Size(40, 20);
            this.Color1.TabIndex = 6;
            this.Color1.TabStop = false;
            this.Color1.Click += new System.EventHandler(this.Color1_Click);
            // 
            // Color2
            // 
            this.Color2.BackColor = System.Drawing.Color.YellowGreen;
            this.Color2.Location = new System.Drawing.Point(152, 92);
            this.Color2.Name = "Color2";
            this.Color2.Size = new System.Drawing.Size(40, 20);
            this.Color2.TabIndex = 7;
            this.Color2.TabStop = false;
            this.Color2.Click += new System.EventHandler(this.Color2_Click);
            // 
            // Color3
            // 
            this.Color3.BackColor = System.Drawing.Color.Orange;
            this.Color3.Location = new System.Drawing.Point(192, 92);
            this.Color3.Name = "Color3";
            this.Color3.Size = new System.Drawing.Size(40, 20);
            this.Color3.TabIndex = 8;
            this.Color3.TabStop = false;
            this.Color3.Click += new System.EventHandler(this.Color3_Click);
            // 
            // Color4
            // 
            this.Color4.BackColor = System.Drawing.Color.Tomato;
            this.Color4.Location = new System.Drawing.Point(232, 92);
            this.Color4.Name = "Color4";
            this.Color4.Size = new System.Drawing.Size(40, 20);
            this.Color4.TabIndex = 9;
            this.Color4.TabStop = false;
            this.Color4.Click += new System.EventHandler(this.Color4_Click);
            // 
            // setHour
            // 
            this.setHour.Location = new System.Drawing.Point(112, 127);
            this.setHour.Name = "setHour";
            this.setHour.Size = new System.Drawing.Size(33, 25);
            this.setHour.TabIndex = 10;
            this.setHour.Text = "23";
            this.setHour.TextChanged += new System.EventHandler(this.setHour_TextChanged);
            // 
            // setMin
            // 
            this.setMin.Location = new System.Drawing.Point(164, 127);
            this.setMin.Name = "setMin";
            this.setMin.Size = new System.Drawing.Size(33, 25);
            this.setMin.TabIndex = 11;
            this.setMin.Text = "50";
            this.setMin.TextChanged += new System.EventHandler(this.setMin_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("宋体", 15F);
            this.label5.Location = new System.Drawing.Point(142, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = ":";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 35);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(385, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 33);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHelp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.setMin);
            this.panel1.Controls.Add(this.timeBarThicknessNL);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Color1);
            this.panel1.Controls.Add(this.setHour);
            this.panel1.Controls.Add(this.Color2);
            this.panel1.Controls.Add(this.Color4);
            this.panel1.Controls.Add(this.Color3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 246);
            this.panel1.TabIndex = 16;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.White;
            this.btnHelp.BackgroundImage = global::今日剩余.Properties.Resources.question29;
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelp.Location = new System.Drawing.Point(27, 207);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(30, 30);
            this.btnHelp.TabIndex = 17;
            this.btnHelp.TabStop = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // Set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 296);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApplicationChange);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Set";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set";
            this.Load += new System.EventHandler(this.Set_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timeBarThicknessNL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApplicationChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown timeBarThicknessNL;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox Color1;
        private System.Windows.Forms.PictureBox Color2;
        private System.Windows.Forms.PictureBox Color3;
        private System.Windows.Forms.PictureBox Color4;
        private System.Windows.Forms.TextBox setHour;
        private System.Windows.Forms.TextBox setMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnHelp;

    }
}