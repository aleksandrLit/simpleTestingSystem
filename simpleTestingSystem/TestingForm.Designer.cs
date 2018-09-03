namespace simpleTestingSystem
{
    partial class TestingForm
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
            this.previousQuestionButton = new System.Windows.Forms.Button();
            this.nextQuestionButton = new System.Windows.Forms.Button();
            this.answersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.questionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.setAnswersProgressBar = new System.Windows.Forms.ProgressBar();
            this.giveAnswerButton = new System.Windows.Forms.Button();
            this.endTestingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // previousQuestionButton
            // 
            this.previousQuestionButton.Location = new System.Drawing.Point(237, 350);
            this.previousQuestionButton.Name = "previousQuestionButton";
            this.previousQuestionButton.Size = new System.Drawing.Size(206, 23);
            this.previousQuestionButton.TabIndex = 0;
            this.previousQuestionButton.Text = "Предыдущий вопрос";
            this.previousQuestionButton.UseVisualStyleBackColor = true;
            this.previousQuestionButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.previosQuestionButton_MouseClick);
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.Location = new System.Drawing.Point(449, 350);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(188, 23);
            this.nextQuestionButton.TabIndex = 1;
            this.nextQuestionButton.Text = "Следующий вопрос";
            this.nextQuestionButton.UseVisualStyleBackColor = true;
            this.nextQuestionButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nextQuestionsButton_MouseClick);
            // 
            // answersCheckedListBox
            // 
            this.answersCheckedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answersCheckedListBox.FormattingEnabled = true;
            this.answersCheckedListBox.HorizontalScrollbar = true;
            this.answersCheckedListBox.Location = new System.Drawing.Point(12, 116);
            this.answersCheckedListBox.Name = "answersCheckedListBox";
            this.answersCheckedListBox.Size = new System.Drawing.Size(625, 191);
            this.answersCheckedListBox.TabIndex = 2;
            this.answersCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.answersCheckedListBox_ItemCheck);
            // 
            // questionTextBox
            // 
            this.questionTextBox.Enabled = false;
            this.questionTextBox.Location = new System.Drawing.Point(12, 27);
            this.questionTextBox.Multiline = true;
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.Size = new System.Drawing.Size(625, 68);
            this.questionTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выберите правильный вариант ответа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Вопрос:";
            // 
            // setAnswersProgressBar
            // 
            this.setAnswersProgressBar.Location = new System.Drawing.Point(12, 321);
            this.setAnswersProgressBar.Name = "setAnswersProgressBar";
            this.setAnswersProgressBar.Size = new System.Drawing.Size(431, 23);
            this.setAnswersProgressBar.TabIndex = 6;
            // 
            // giveAnswerButton
            // 
            this.giveAnswerButton.Location = new System.Drawing.Point(449, 321);
            this.giveAnswerButton.Name = "giveAnswerButton";
            this.giveAnswerButton.Size = new System.Drawing.Size(188, 23);
            this.giveAnswerButton.TabIndex = 7;
            this.giveAnswerButton.Text = "Ответить";
            this.giveAnswerButton.UseVisualStyleBackColor = true;
            this.giveAnswerButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.giveAnswerButton_MouseClick);
            // 
            // endTestingButton
            // 
            this.endTestingButton.Enabled = false;
            this.endTestingButton.Location = new System.Drawing.Point(16, 350);
            this.endTestingButton.Name = "endTestingButton";
            this.endTestingButton.Size = new System.Drawing.Size(215, 23);
            this.endTestingButton.TabIndex = 8;
            this.endTestingButton.Text = "Завершить тестирование";
            this.endTestingButton.UseVisualStyleBackColor = true;
            this.endTestingButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.endTestingButton_MouseClick);
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 385);
            this.Controls.Add(this.endTestingButton);
            this.Controls.Add(this.giveAnswerButton);
            this.Controls.Add(this.setAnswersProgressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.questionTextBox);
            this.Controls.Add(this.answersCheckedListBox);
            this.Controls.Add(this.nextQuestionButton);
            this.Controls.Add(this.previousQuestionButton);
            this.Name = "TestingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма тестирования";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button previousQuestionButton;
        private System.Windows.Forms.Button nextQuestionButton;
        private System.Windows.Forms.CheckedListBox answersCheckedListBox;
        private System.Windows.Forms.TextBox questionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar setAnswersProgressBar;
        private System.Windows.Forms.Button giveAnswerButton;
        private System.Windows.Forms.Button endTestingButton;
    }
}