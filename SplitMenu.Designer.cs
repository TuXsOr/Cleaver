namespace Cleaver
{
    partial class SplitMenu
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
            TargetFileDialogue = new OpenFileDialog();
            openTargetFileButton = new Button();
            targetFileFilepath = new TextBox();
            splitButton = new Button();
            numChunksText = new Label();
            chunkSizeCounter = new NumericUpDown();
            label1 = new Label();
            numChunksCounter = new NumericUpDown();
            passwordBox = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)chunkSizeCounter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChunksCounter).BeginInit();
            SuspendLayout();
            // 
            // TargetFileDialogue
            // 
            TargetFileDialogue.FileName = "targetFile";
            TargetFileDialogue.FileOk += TargetFileDialogue_FileOk;
            // 
            // openTargetFileButton
            // 
            openTargetFileButton.Location = new Point(12, 12);
            openTargetFileButton.Name = "openTargetFileButton";
            openTargetFileButton.Size = new Size(75, 37);
            openTargetFileButton.TabIndex = 0;
            openTargetFileButton.Text = "Select File";
            openTargetFileButton.UseVisualStyleBackColor = true;
            openTargetFileButton.Click += openTargetFileButton_Click;
            // 
            // targetFileFilepath
            // 
            targetFileFilepath.Location = new Point(93, 20);
            targetFileFilepath.Name = "targetFileFilepath";
            targetFileFilepath.ReadOnly = true;
            targetFileFilepath.Size = new Size(389, 23);
            targetFileFilepath.TabIndex = 1;
            // 
            // splitButton
            // 
            splitButton.Location = new Point(12, 234);
            splitButton.Name = "splitButton";
            splitButton.Size = new Size(86, 34);
            splitButton.TabIndex = 2;
            splitButton.Text = "Split";
            splitButton.UseVisualStyleBackColor = true;
            splitButton.Click += splitButton_Click_1;
            // 
            // numChunksText
            // 
            numChunksText.AutoSize = true;
            numChunksText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numChunksText.Location = new Point(12, 114);
            numChunksText.Name = "numChunksText";
            numChunksText.Size = new Size(148, 21);
            numChunksText.TabIndex = 3;
            numChunksText.Text = "Number Of Chunks:";
            // 
            // chunkSizeCounter
            // 
            chunkSizeCounter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chunkSizeCounter.Location = new Point(104, 69);
            chunkSizeCounter.Name = "chunkSizeCounter";
            chunkSizeCounter.Size = new Size(120, 29);
            chunkSizeCounter.TabIndex = 4;
            chunkSizeCounter.ValueChanged += chunkSizeCounter_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(11, 71);
            label1.Name = "label1";
            label1.Size = new Size(87, 21);
            label1.TabIndex = 5;
            label1.Text = "Chunk Size";
            // 
            // numChunksCounter
            // 
            numChunksCounter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numChunksCounter.Location = new Point(166, 112);
            numChunksCounter.Name = "numChunksCounter";
            numChunksCounter.Size = new Size(120, 29);
            numChunksCounter.TabIndex = 6;
            numChunksCounter.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numChunksCounter.ValueChanged += numChunksCounter_ValueChanged;
            // 
            // passwordBox
            // 
            passwordBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordBox.Location = new Point(103, 162);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "File Password";
            passwordBox.Size = new Size(167, 29);
            passwordBox.TabIndex = 7;
            passwordBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(18, 165);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 8;
            label2.Text = "Password:";
            // 
            // SplitMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 293);
            Controls.Add(label2);
            Controls.Add(passwordBox);
            Controls.Add(numChunksCounter);
            Controls.Add(label1);
            Controls.Add(chunkSizeCounter);
            Controls.Add(numChunksText);
            Controls.Add(splitButton);
            Controls.Add(targetFileFilepath);
            Controls.Add(openTargetFileButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SplitMenu";
            Text = "Split Menu";
            FormClosing += SplitMenu_FormClosing;
            ((System.ComponentModel.ISupportInitialize)chunkSizeCounter).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChunksCounter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog TargetFileDialogue;
        private Button openTargetFileButton;
        private TextBox targetFileFilepath;
        private Button splitButton;
        private Label numChunksText;
        private NumericUpDown chunkSizeCounter;
        private Label label1;
        private NumericUpDown numChunksCounter;
        private TextBox passwordBox;
        private Label label2;
    }
}