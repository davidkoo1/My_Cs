
namespace ExerForSchool
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inLabel1 = new System.Windows.Forms.Label();
            this.keyLabel2 = new System.Windows.Forms.Label();
            this.outLabel3 = new System.Windows.Forms.Label();
            this.textOutLabel4 = new System.Windows.Forms.Label();
            this.doWork = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listComboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inLabel1
            // 
            this.inLabel1.AutoSize = true;
            this.inLabel1.BackColor = System.Drawing.Color.Silver;
            this.inLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.inLabel1.Location = new System.Drawing.Point(90, 128);
            this.inLabel1.Name = "inLabel1";
            this.inLabel1.Size = new System.Drawing.Size(111, 19);
            this.inLabel1.TabIndex = 22;
            this.inLabel1.Text = "*Input Your Text\r\n";
            // 
            // keyLabel2
            // 
            this.keyLabel2.AutoSize = true;
            this.keyLabel2.BackColor = System.Drawing.Color.Silver;
            this.keyLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.keyLabel2.Location = new System.Drawing.Point(90, 49);
            this.keyLabel2.Name = "keyLabel2";
            this.keyLabel2.Size = new System.Drawing.Size(39, 19);
            this.keyLabel2.TabIndex = 50;
            this.keyLabel2.Text = "*Key";
            // 
            // outLabel3
            // 
            this.outLabel3.AutoSize = true;
            this.outLabel3.BackColor = System.Drawing.Color.Silver;
            this.outLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.outLabel3.Location = new System.Drawing.Point(90, 265);
            this.outLabel3.Name = "outLabel3";
            this.outLabel3.Size = new System.Drawing.Size(78, 19);
            this.outLabel3.TabIndex = 24;
            this.outLabel3.Text = "*File Name";
            // 
            // textOutLabel4
            // 
            this.textOutLabel4.AutoSize = true;
            this.textOutLabel4.BackColor = System.Drawing.Color.GhostWhite;
            this.textOutLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOutLabel4.Font = new System.Drawing.Font("News706 BT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOutLabel4.ForeColor = System.Drawing.Color.Black;
            this.textOutLabel4.Location = new System.Drawing.Point(311, 221);
            this.textOutLabel4.Name = "textOutLabel4";
            this.textOutLabel4.Size = new System.Drawing.Size(169, 24);
            this.textOutLabel4.TabIndex = 25;
            this.textOutLabel4.Text = "Полученный текст";
            this.textOutLabel4.Visible = false;
            // 
            // doWork
            // 
            this.doWork.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.doWork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.doWork.Location = new System.Drawing.Point(90, 335);
            this.doWork.Name = "doWork";
            this.doWork.Size = new System.Drawing.Size(91, 35);
            this.doWork.TabIndex = 26;
            this.doWork.Text = "Шифровать";
            this.doWork.UseVisualStyleBackColor = false;
            this.doWork.Visible = false;
            this.doWork.Click += new System.EventHandler(this.doWork_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(241, 128);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 90);
            this.textBox1.TabIndex = 35;
            // 
            // listComboBox1
            // 
            this.listComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.listComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listComboBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.listComboBox1.FormattingEnabled = true;
            this.listComboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listComboBox1.Location = new System.Drawing.Point(241, 49);
            this.listComboBox1.Name = "listComboBox1";
            this.listComboBox1.Size = new System.Drawing.Size(292, 33);
            this.listComboBox1.TabIndex = 27;
            this.listComboBox1.Text = "Выберите ключ";
            this.listComboBox1.SelectedIndexChanged += new System.EventHandler(this.listComboBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(615, 24);
            this.menuStrip1.TabIndex = 52;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(241, 265);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(292, 22);
            this.textBox2.TabIndex = 53;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(324, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 54;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(615, 409);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listComboBox1);
            this.Controls.Add(this.doWork);
            this.Controls.Add(this.textOutLabel4);
            this.Controls.Add(this.outLabel3);
            this.Controls.Add(this.keyLabel2);
            this.Controls.Add(this.inLabel1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "David Alexandr";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inLabel1;
        private System.Windows.Forms.Label keyLabel2;
        private System.Windows.Forms.Label outLabel3;
        private System.Windows.Forms.Label textOutLabel4;
        private System.Windows.Forms.Button doWork;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox listComboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
    }
}

