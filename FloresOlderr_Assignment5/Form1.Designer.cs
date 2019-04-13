namespace FloresOlderr_Assignment5
{
    partial class Form1
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
            this.DifficultyRadioGroup = new System.Windows.Forms.GroupBox();
            this.HardRadioButton = new System.Windows.Forms.RadioButton();
            this.MediumRadioButton = new System.Windows.Forms.RadioButton();
            this.EasyRadioButton = new System.Windows.Forms.RadioButton();
            this.DifficultyLevelButton = new System.Windows.Forms.Button();
            this.DifficultyRadioGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // DifficultyRadioGroup
            // 
            this.DifficultyRadioGroup.Controls.Add(this.HardRadioButton);
            this.DifficultyRadioGroup.Controls.Add(this.MediumRadioButton);
            this.DifficultyRadioGroup.Controls.Add(this.EasyRadioButton);
            this.DifficultyRadioGroup.Location = new System.Drawing.Point(325, 60);
            this.DifficultyRadioGroup.Name = "DifficultyRadioGroup";
            this.DifficultyRadioGroup.Size = new System.Drawing.Size(200, 100);
            this.DifficultyRadioGroup.TabIndex = 0;
            this.DifficultyRadioGroup.TabStop = false;
            this.DifficultyRadioGroup.Text = "Difficulty Level";
            // 
            // HardRadioButton
            // 
            this.HardRadioButton.AutoSize = true;
            this.HardRadioButton.Location = new System.Drawing.Point(16, 65);
            this.HardRadioButton.Name = "HardRadioButton";
            this.HardRadioButton.Size = new System.Drawing.Size(48, 17);
            this.HardRadioButton.TabIndex = 2;
            this.HardRadioButton.TabStop = true;
            this.HardRadioButton.Text = "Hard";
            this.HardRadioButton.UseVisualStyleBackColor = true;
            // 
            // MediumRadioButton
            // 
            this.MediumRadioButton.AutoSize = true;
            this.MediumRadioButton.Location = new System.Drawing.Point(16, 42);
            this.MediumRadioButton.Name = "MediumRadioButton";
            this.MediumRadioButton.Size = new System.Drawing.Size(62, 17);
            this.MediumRadioButton.TabIndex = 1;
            this.MediumRadioButton.TabStop = true;
            this.MediumRadioButton.Text = "Medium";
            this.MediumRadioButton.UseVisualStyleBackColor = true;
            // 
            // EasyRadioButton
            // 
            this.EasyRadioButton.AutoSize = true;
            this.EasyRadioButton.Location = new System.Drawing.Point(16, 19);
            this.EasyRadioButton.Name = "EasyRadioButton";
            this.EasyRadioButton.Size = new System.Drawing.Size(48, 17);
            this.EasyRadioButton.TabIndex = 0;
            this.EasyRadioButton.TabStop = true;
            this.EasyRadioButton.Text = "Easy";
            this.EasyRadioButton.UseVisualStyleBackColor = true;
            // 
            // DifficultyLevelButton
            // 
            this.DifficultyLevelButton.Location = new System.Drawing.Point(380, 200);
            this.DifficultyLevelButton.Name = "DifficultyLevelButton";
            this.DifficultyLevelButton.Size = new System.Drawing.Size(75, 23);
            this.DifficultyLevelButton.TabIndex = 2;
            this.DifficultyLevelButton.Text = "Choose";
            this.DifficultyLevelButton.UseVisualStyleBackColor = true;
            this.DifficultyLevelButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Choose_Difficulty_Playing_Field);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.DifficultyLevelButton);
            this.Controls.Add(this.DifficultyRadioGroup);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DifficultyRadioGroup.ResumeLayout(false);
            this.DifficultyRadioGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DifficultyRadioGroup;
        private System.Windows.Forms.RadioButton HardRadioButton;
        private System.Windows.Forms.RadioButton MediumRadioButton;
        private System.Windows.Forms.RadioButton EasyRadioButton;
        private System.Windows.Forms.Button DifficultyLevelButton;
    }
}

