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
            ((System.ComponentModel.ISupportInitialize)(this.Easy_Playing_Field)).BeginInit();
            this.SuspendLayout();
            // 
            // Easy_Playing_Field
            // 
            this.Easy_Playing_Field.BackColor = System.Drawing.Color.Black;
            this.Easy_Playing_Field.Location = new System.Drawing.Point(12, 12);
            this.Easy_Playing_Field.Name = "Easy_Playing_Field";
            this.Easy_Playing_Field.Size = new System.Drawing.Size(275, 275);
            this.Easy_Playing_Field.TabIndex = 2;
            this.Easy_Playing_Field.TabStop = false;
            this.Easy_Playing_Field.Paint += new System.Windows.Forms.PaintEventHandler(this.Easy_Playing_Field_Draw);
            // 
            // Reset_Button
            // 
            this.Reset_Button.Location = new System.Drawing.Point(640, 200);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(75, 23);
            this.Reset_Button.TabIndex = 10;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = true;
            // 
            // Back_Button
            // 
            this.Back_Button.Location = new System.Drawing.Point(640, 260);
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
            // Easy_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}