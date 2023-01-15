namespace Tic_Tack_Toe
{
    partial class LogInForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectPlayerLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.LogInButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectPlayerLabel
            // 
            this.SelectPlayerLabel.AutoSize = true;
            this.SelectPlayerLabel.Location = new System.Drawing.Point(120, 44);
            this.SelectPlayerLabel.Name = "SelectPlayerLabel";
            this.SelectPlayerLabel.Size = new System.Drawing.Size(124, 20);
            this.SelectPlayerLabel.TabIndex = 0;
            this.SelectPlayerLabel.Text = "Select First Player";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(120, 81);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(125, 27);
            this.UserNameTextBox.TabIndex = 1;
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(132, 114);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(94, 29);
            this.LogInButton.TabIndex = 2;
            this.LogInButton.Text = "Log In";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(393, 450);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.SelectPlayerLabel);
            this.Name = "LogInForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LogInForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label SelectPlayerLabel;
        private TextBox UserNameTextBox;
        private Button LogInButton;
    }
}