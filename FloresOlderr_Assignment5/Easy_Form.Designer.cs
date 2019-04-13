namespace FloresOlderr_Assignment5
{
    partial class Easy_Form
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
            this.Easy_Playing_Field = new System.Windows.Forms.PictureBox();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.Back_Button = new System.Windows.Forms.Button();
            this.EasyTextBox = new System.Windows.Forms.TextBox();
            this.EasyTextBoxLabel = new System.Windows.Forms.Label();
            this.EasyTimerTextBox = new System.Windows.Forms.TextBox();
            this.ProgressButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Easy_Playing_Field)).BeginInit();
            this.SuspendLayout();
            // 
            // Easy_Playing_Field
            // 
            this.Easy_Playing_Field.BackColor = System.Drawing.Color.Black;
            this.Easy_Playing_Field.Location = new System.Drawing.Point(10, 10);
            this.Easy_Playing_Field.Name = "Easy_Playing_Field";
            this.Easy_Playing_Field.Size = new System.Drawing.Size(275, 275);
            this.Easy_Playing_Field.TabIndex = 2;
            this.Easy_Playing_Field.TabStop = false;
            this.Easy_Playing_Field.Paint += new System.Windows.Forms.PaintEventHandler(this.Easy_Playing_Field_Draw);
            this.Easy_Playing_Field.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Update_Easy_Form_Click);
            // 
            // Reset_Button
            // 
            this.Reset_Button.Location = new System.Drawing.Point(640, 200);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(75, 23);
            this.Reset_Button.TabIndex = 10;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // Back_Button
            // 
            this.Back_Button.Location = new System.Drawing.Point(640, 320);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(75, 23);
            this.Back_Button.TabIndex = 9;
            this.Back_Button.Text = "Back";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // EasyTextBox
            // 
            this.EasyTextBox.Location = new System.Drawing.Point(600, 80);
            this.EasyTextBox.Name = "EasyTextBox";
            this.EasyTextBox.Size = new System.Drawing.Size(120, 20);
            this.EasyTextBox.TabIndex = 11;
            // 
            // EasyTextBoxLabel
            // 
            this.EasyTextBoxLabel.AutoSize = true;
            this.EasyTextBoxLabel.Location = new System.Drawing.Point(600, 60);
            this.EasyTextBoxLabel.Name = "EasyTextBoxLabel";
            this.EasyTextBoxLabel.Size = new System.Drawing.Size(72, 13);
            this.EasyTextBoxLabel.TabIndex = 12;
            this.EasyTextBoxLabel.Text = "Enter Number";
            // 
            // EasyTimerTextBox
            // 
            this.EasyTimerTextBox.Location = new System.Drawing.Point(600, 10);
            this.EasyTimerTextBox.Name = "EasyTimerTextBox";
            this.EasyTimerTextBox.Size = new System.Drawing.Size(100, 20);
            this.EasyTimerTextBox.TabIndex = 13;
            // 
            // ProgressButton
            // 
            this.ProgressButton.Location = new System.Drawing.Point(500, 200);
            this.ProgressButton.Name = "ProgressButton";
            this.ProgressButton.Size = new System.Drawing.Size(75, 23);
            this.ProgressButton.TabIndex = 14;
            this.ProgressButton.Text = "Progress";
            this.ProgressButton.UseVisualStyleBackColor = true;
            this.ProgressButton.Click += new System.EventHandler(this.ProgressButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(640, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "This will aslo save";
            // 
            // Easy_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgressButton);
            this.Controls.Add(this.EasyTimerTextBox);
            this.Controls.Add(this.EasyTextBoxLabel);
            this.Controls.Add(this.EasyTextBox);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.Easy_Playing_Field);
            this.Name = "Easy_Form";
            this.Text = "Easy_Form";
            ((System.ComponentModel.ISupportInitialize)(this.Easy_Playing_Field)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Easy_Playing_Field;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.TextBox EasyTextBox;
        private System.Windows.Forms.Label EasyTextBoxLabel;
        private System.Windows.Forms.TextBox EasyTimerTextBox;
        private System.Windows.Forms.Button ProgressButton;
        private System.Windows.Forms.Label label1;
    }
}