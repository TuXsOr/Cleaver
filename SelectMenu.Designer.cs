namespace Cleaver
{
    partial class SelectMenu
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
            splitButton = new Button();
            reconstructButton = new Button();
            SuspendLayout();
            // 
            // splitButton
            // 
            splitButton.Location = new Point(12, 14);
            splitButton.Name = "splitButton";
            splitButton.Size = new Size(195, 36);
            splitButton.TabIndex = 0;
            splitButton.Text = "Split";
            splitButton.UseVisualStyleBackColor = true;
            splitButton.Click += splitButton_Click;
            // 
            // reconstructButton
            // 
            reconstructButton.Location = new Point(12, 57);
            reconstructButton.Name = "reconstructButton";
            reconstructButton.Size = new Size(195, 36);
            reconstructButton.TabIndex = 1;
            reconstructButton.Text = "Reconstruct";
            reconstructButton.UseVisualStyleBackColor = true;
            // 
            // SelectMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(219, 108);
            Controls.Add(reconstructButton);
            Controls.Add(splitButton);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SelectMenu";
            Text = "Cleaver";
            ResumeLayout(false);
        }

        #endregion

        private Button splitButton;
        private Button reconstructButton;
    }
}