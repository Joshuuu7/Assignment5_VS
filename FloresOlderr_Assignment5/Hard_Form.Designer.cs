﻿namespace FloresOlderr_Assignment5
{
    partial class Hard_Form
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
            this.Hard_Playing_Field = new System.Windows.Forms.PictureBox();
            this.HardTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Reset_Button = new System.Windows.Forms.Button();
            this.Back_Button = new System.Windows.Forms.Button();
            this.HardTextBoxLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Hard_Playing_Field)).BeginInit();
            this.SuspendLayout();
            // 
            // Hard_Playing_Field
            // 
            this.Hard_Playing_Field.BackColor = System.Drawing.Color.Black;
            this.Hard_Playing_Field.Location = new System.Drawing.Point(12, 12);
            this.Hard_Playing_Field.Name = "Hard_Playing_Field";
            this.Hard_Playing_Field.Size = new System.Drawing.Size(275, 275);
            this.Hard_Playing_Field.TabIndex = 2;
            this.Hard_Playing_Field.TabStop = false;
            this.Hard_Playing_Field.Paint += new System.Windows.Forms.PaintEventHandler(this.Hard_Playing_Field_Draw);
            // 
            // HardTextBox
            // 
            this.HardTextBox.Location = new System.Drawing.Point(600, 80);
            this.HardTextBox.Name = "HardTextBox";
            this.HardTextBox.Size = new System.Drawing.Size(120, 20);
            this.HardTextBox.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Reset_Button
            // 
            this.Reset_Button.Location = new System.Drawing.Point(640, 200);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(75, 23);
            this.Reset_Button.TabIndex = 8;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = true;
            // 
            // Back_Button
            // 
            this.Back_Button.Location = new System.Drawing.Point(640, 260);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(75, 23);
            this.Back_Button.TabIndex = 7;
            this.Back_Button.Text = "Back";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // HardTextBoxLabel
            // 
            this.HardTextBoxLabel.AutoSize = true;
            this.HardTextBoxLabel.Location = new System.Drawing.Point(600, 60);
            this.HardTextBoxLabel.Name = "HardTextBoxLabel";
            this.HardTextBoxLabel.Size = new System.Drawing.Size(72, 13);
            this.HardTextBoxLabel.TabIndex = 9;
            this.HardTextBoxLabel.Text = "Enter Number";
            // 
            // Hard_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HardTextBoxLabel);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.HardTextBox);
            this.Controls.Add(this.Hard_Playing_Field);
            this.Name = "Hard_Form";
            this.Text = "Hard_Form";
            ((System.ComponentModel.ISupportInitialize)(this.Hard_Playing_Field)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Hard_Playing_Field;
        private System.Windows.Forms.TextBox HardTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.Label HardTextBoxLabel;
    }
}