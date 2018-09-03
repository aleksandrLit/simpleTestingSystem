namespace simpleTestingSystem
{
    partial class QuestionForm
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
            this.saveQuestionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.questionTextBox = new System.Windows.Forms.TextBox();
            this.answersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.addAnswerButton = new System.Windows.Forms.Button();
            this.editAnswerButton = new System.Windows.Forms.Button();
            this.removeAnswerButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveQuestionButton
            // 
            this.saveQuestionButton.Location = new System.Drawing.Point(10, 249);
            this.saveQuestionButton.Name = "saveQuestionButton";
            this.saveQuestionButton.Size = new System.Drawing.Size(99, 23);
            this.saveQuestionButton.TabIndex = 0;
            this.saveQuestionButton.Text = "Сохранить";
            this.saveQuestionButton.UseVisualStyleBackColor = true;
            this.saveQuestionButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.saveQuestionButton_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вопрос:";
            // 
            // questionTextBox
            // 
            this.questionTextBox.Location = new System.Drawing.Point(65, 18);
            this.questionTextBox.Multiline = true;
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.Size = new System.Drawing.Size(481, 59);
            this.questionTextBox.TabIndex = 2;
            // 
            // answersCheckedListBox
            // 
            this.answersCheckedListBox.FormattingEnabled = true;
            this.answersCheckedListBox.HorizontalScrollbar = true;
            this.answersCheckedListBox.Location = new System.Drawing.Point(10, 97);
            this.answersCheckedListBox.Name = "answersCheckedListBox";
            this.answersCheckedListBox.Size = new System.Drawing.Size(536, 139);
            this.answersCheckedListBox.TabIndex = 3;
            this.answersCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.answersCheckedListBox_ItemCheck);
            this.answersCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.answersCheckedListBox_SelectedIndexChanged);
            // 
            // addAnswerButton
            // 
            this.addAnswerButton.Location = new System.Drawing.Point(564, 97);
            this.addAnswerButton.Name = "addAnswerButton";
            this.addAnswerButton.Size = new System.Drawing.Size(75, 23);
            this.addAnswerButton.TabIndex = 4;
            this.addAnswerButton.Text = "Добавить";
            this.addAnswerButton.UseVisualStyleBackColor = true;
            this.addAnswerButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addAnswerButton_MouseClick);
            // 
            // editAnswerButton
            // 
            this.editAnswerButton.Enabled = false;
            this.editAnswerButton.Location = new System.Drawing.Point(564, 135);
            this.editAnswerButton.Name = "editAnswerButton";
            this.editAnswerButton.Size = new System.Drawing.Size(75, 23);
            this.editAnswerButton.TabIndex = 5;
            this.editAnswerButton.Text = "Изменить";
            this.editAnswerButton.UseVisualStyleBackColor = true;
            this.editAnswerButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.editAnswerButton_MouseClick);
            // 
            // removeAnswerButton
            // 
            this.removeAnswerButton.Enabled = false;
            this.removeAnswerButton.Location = new System.Drawing.Point(564, 174);
            this.removeAnswerButton.Name = "removeAnswerButton";
            this.removeAnswerButton.Size = new System.Drawing.Size(75, 23);
            this.removeAnswerButton.TabIndex = 6;
            this.removeAnswerButton.Text = "Удалить";
            this.removeAnswerButton.UseVisualStyleBackColor = true;
            this.removeAnswerButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.removeAnswerButton_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ответы:";
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 284);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.removeAnswerButton);
            this.Controls.Add(this.editAnswerButton);
            this.Controls.Add(this.addAnswerButton);
            this.Controls.Add(this.answersCheckedListBox);
            this.Controls.Add(this.questionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveQuestionButton);
            this.Name = "QuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddQuestionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveQuestionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox questionTextBox;
        private System.Windows.Forms.CheckedListBox answersCheckedListBox;
        private System.Windows.Forms.Button addAnswerButton;
        private System.Windows.Forms.Button editAnswerButton;
        private System.Windows.Forms.Button removeAnswerButton;
        private System.Windows.Forms.Label label2;
    }
}