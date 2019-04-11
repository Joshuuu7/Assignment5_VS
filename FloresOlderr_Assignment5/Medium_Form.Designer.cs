namespace FloresOlderr_Assignment5
{
    partial class Medium_Form
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
            this.Medium_Playing_Field = new System.Windows.Forms.PictureBox();
            this.MediumTextBox = new System.Windows.Forms.TextBox();
            this.MediumTextBoxLabel = new System.Windows.Forms.Label();
            this.Back_Button = new System.Windows.Forms.Button();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.MediumTimerTextBox = new System.Windows.Forms.TextBox();
            this.ProgressButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Medium_Playing_Field)).BeginInit();
            this.SuspendLayout();
            // 
            // Medium_Playing_Field
            // 
            this.Medium_Playing_Field.BackColor = System.Drawing.Color.Black;
            this.Medium_Playing_Field.Location = new System.Drawing.Point(12, 12);
            this.Medium_Playing_Field.Name = "Medium_Playing_Field";
            this.Medium_Playing_Field.Size = new System.Drawing.Size(275, 275);
            this.Medium_Playing_Field.TabIndex = 2;
            this.Medium_Playing_Field.TabStop = false;
            this.Medium_Playing_Field.Paint += new System.Windows.Forms.PaintEventHandler(this.Medium_Playing_Field_Draw);
            this.Medium_Playing_Field.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Update_Medium_Form_Click);
            // 
            // MediumTextBox
            // 
            this.MediumTextBox.Location = new System.Drawing.Point(600, 80);
            this.MediumTextBox.Name = "MediumTextBox";
            this.MediumTextBox.Size = new System.Drawing.Size(120, 20);
            this.MediumTextBox.TabIndex = 3;
            // 
            // MediumTextBoxLabel
            // 
            this.MediumTextBoxLabel.AutoSize = true;
            this.MediumTextBoxLabel.Location = new System.Drawing.Point(600, 60);
            this.MediumTextBoxLabel.Name = "MediumTextBoxLabel";
            this.MediumTextBoxLabel.Size = new System.Drawing.Size(72, 13);
            this.MediumTextBoxLabel.TabIndex = 4;
            this.MediumTextBoxLabel.Text = "Enter Number";
            // 
            // Back_Button
            // 
            this.Back_Button.Location = new System.Drawing.Point(640, 331);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(75, 23);
            this.Back_Button.TabIndex = 5;
            this.Back_Button.Text = "Back";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // Reset_Button
            // 
            this.Reset_Button.Location = new System.Drawing.Point(640, 200);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(75, 23);
            this.Reset_Button.TabIndex = 6;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // MediumTimerTextBox
            // 
            this.MediumTimerTextBox.Location = new System.Drawing.Point(603, 12);
            this.MediumTimerTextBox.Name = "MediumTimerTextBox";
            this.MediumTimerTextBox.Size = new System.Drawing.Size(100, 20);
            this.MediumTimerTextBox.TabIndex = 7;
            // 
            // ProgressButton
            // 
            this.ProgressButton.Location = new System.Drawing.Point(518, 200);
            this.ProgressButton.Name = "ProgressButton";
            this.ProgressButton.Size = new System.Drawing.Size(75, 23);
            this.ProgressButton.TabIndex = 8;
            this.ProgressButton.Text = "Progress";
            this.ProgressButton.UseVisualStyleBackColor = true;
            this.ProgressButton.Click += new System.EventHandler(this.ProgressButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(637, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "This will aslo save";
            // 
            // Medium_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgressButton);
            this.Controls.Add(this.MediumTimerTextBox);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.MediumTextBoxLabel);
            this.Controls.Add(this.MediumTextBox);
            this.Controls.Add(this.Medium_Playing_Field);
            this.Name = "Medium_Form";
            this.Text = "Medium_Form";
            ((System.ComponentModel.ISupportInitialize)(this.Medium_Playing_Field)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Medium_Playing_Field;
        private System.Windows.Forms.TextBox MediumTextBox;
        private System.Windows.Forms.Label MediumTextBoxLabel;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.TextBox MediumTimerTextBox;
        private System.Windows.Forms.Button ProgressButton;
        private System.Windows.Forms.Label label1;
    }
}