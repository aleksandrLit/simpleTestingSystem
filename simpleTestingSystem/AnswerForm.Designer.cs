﻿namespace simpleTestingSystem
{
    partial class AnswerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.saveAnswerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите ответ:";
            // 
            // answerTextBox
            // 
            this.answerTextBox.Location = new System.Drawing.Point(11, 33);
            this.answerTextBox.Multiline = true;
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(475, 114);
            this.answerTextBox.TabIndex = 1;
            this.answerTextBox.TextChanged += new System.EventHandler(this.answerTextBox_TextChanged);
            // 
            // saveAnswerButton
            // 
            this.saveAnswerButton.Location = new System.Drawing.Point(411, 153);
            this.saveAnswerButton.Name = "saveAnswerButton";
            this.saveAnswerButton.Size = new System.Drawing.Size(75, 23);
            this.saveAnswerButton.TabIndex = 2;
            this.saveAnswerButton.Text = "Сохранить";
            this.saveAnswerButton.UseVisualStyleBackColor = true;
            this.saveAnswerButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.saveAnswerButton_MouseClick);
            // 
            // AnswerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 188);
            this.Controls.Add(this.saveAnswerButton);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AnswerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnswerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.Button saveAnswerButton;
    }
}