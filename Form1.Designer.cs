namespace система_частиц
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
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbSize = new System.Windows.Forms.TrackBar();
            this.lblDirection = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnRainbow = new System.Windows.Forms.Button();
            this.btnToggleMode = new System.Windows.Forms.Button();
            this.btnToggleMode2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.picDisplay.BackgroundImage = global::система_частиц.Properties.Resources.fabd2eaa147930deae7b09f17c787b75_c5_720x720;
            this.picDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picDisplay.Location = new System.Drawing.Point(20, 23);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(769, 679);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbSize
            // 
            this.tbSize.AutoSize = false;
            this.tbSize.Location = new System.Drawing.Point(93, 708);
            this.tbSize.Maximum = 359;
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(153, 56);
            this.tbSize.TabIndex = 1;
            this.tbSize.Scroll += new System.EventHandler(this.tbSize_Scroll);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(223, 382);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(0, 16);
            this.lblDirection.TabIndex = 2;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(252, 708);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(93, 47);
            this.btnChange.TabIndex = 3;
            this.btnChange.Text = "button1";
            this.btnChange.UseVisualStyleBackColor = true;
            // 
            // btnRainbow
            // 
            this.btnRainbow.Location = new System.Drawing.Point(365, 708);
            this.btnRainbow.Name = "btnRainbow";
            this.btnRainbow.Size = new System.Drawing.Size(94, 47);
            this.btnRainbow.TabIndex = 4;
            this.btnRainbow.Text = "button1";
            this.btnRainbow.UseVisualStyleBackColor = true;
            // 
            // btnToggleMode
            // 
            this.btnToggleMode.Location = new System.Drawing.Point(476, 708);
            this.btnToggleMode.Name = "btnToggleMode";
            this.btnToggleMode.Size = new System.Drawing.Size(102, 47);
            this.btnToggleMode.TabIndex = 5;
            this.btnToggleMode.Text = "button1";
            this.btnToggleMode.UseVisualStyleBackColor = true;
            this.btnToggleMode.Click += new System.EventHandler(this.btnToggleMode_Click);
            // 
            // btnToggleMode2
            // 
            this.btnToggleMode2.Location = new System.Drawing.Point(600, 708);
            this.btnToggleMode2.Name = "btnToggleMode2";
            this.btnToggleMode2.Size = new System.Drawing.Size(89, 47);
            this.btnToggleMode2.TabIndex = 6;
            this.btnToggleMode2.Text = "button1";
            this.btnToggleMode2.UseVisualStyleBackColor = true;
            this.btnToggleMode2.Click += new System.EventHandler(this.btnToggleMode2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 767);
            this.Controls.Add(this.btnToggleMode2);
            this.Controls.Add(this.btnToggleMode);
            this.Controls.Add(this.btnRainbow);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbSize;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnRainbow;
        private System.Windows.Forms.Button btnToggleMode;
        private System.Windows.Forms.Button btnToggleMode2;
    }
}

