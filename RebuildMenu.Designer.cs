namespace Cleaver
{
    partial class RebuildMenu
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
            filesList = new ListBox();
            partLoader = new OpenFileDialog();
            addPart = new Button();
            passwordBox = new TextBox();
            reconstructButton = new Button();
            messageText = new Label();
            SuspendLayout();
            // 
            // filesList
            // 
            filesList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            filesList.FormattingEnabled = true;
            filesList.ItemHeight = 21;
            filesList.Location = new Point(12, 12);
            filesList.Name = "filesList";
            filesList.Size = new Size(297, 193);
            filesList.TabIndex = 0;
            // 
            // partLoader
            // 
            partLoader.FileName = "part";
            partLoader.ReadOnlyChecked = true;
            partLoader.FileOk += partLoader_FileOk;
            // 
            // addPart
            // 
            addPart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addPart.Location = new Point(12, 211);
            addPart.Name = "addPart";
            addPart.Size = new Size(109, 32);
            addPart.TabIndex = 1;
            addPart.Text = "Add Part";
            addPart.UseVisualStyleBackColor = true;
            addPart.Click += addPart_Click;
            // 
            // passwordBox
            // 
            passwordBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordBox.Location = new Point(12, 258);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "Password";
            passwordBox.Size = new Size(297, 29);
            passwordBox.TabIndex = 2;
            passwordBox.UseSystemPasswordChar = true;
            // 
            // reconstructButton
            // 
            reconstructButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            reconstructButton.Location = new Point(84, 321);
            reconstructButton.Name = "reconstructButton";
            reconstructButton.Size = new Size(150, 31);
            reconstructButton.TabIndex = 3;
            reconstructButton.Text = "Reconstruct";
            reconstructButton.UseVisualStyleBackColor = true;
            reconstructButton.Click += reconstructButton_Click;
            // 
            // messageText
            // 
            messageText.AutoSize = true;
            messageText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            messageText.Location = new Point(12, 290);
            messageText.Name = "messageText";
            messageText.Size = new Size(101, 21);
            messageText.TabIndex = 4;
            messageText.Text = "message Text";
            messageText.Visible = false;
            // 
            // RebuildMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 364);
            Controls.Add(messageText);
            Controls.Add(reconstructButton);
            Controls.Add(passwordBox);
            Controls.Add(addPart);
            Controls.Add(filesList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "RebuildMenu";
            Text = "Reconstruct";
            FormClosing += RebuildMenu_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox filesList;
        private OpenFileDialog partLoader;
        private Button addPart;
        private TextBox passwordBox;
        private Button reconstructButton;
        private Label messageText;
    }
}