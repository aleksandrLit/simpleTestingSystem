namespace simpleTestingSystem
{
    partial class AdministrationForm
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
            this.AddQuestionButton = new System.Windows.Forms.Button();
            this.editQuestionButton = new System.Windows.Forms.Button();
            this.removeQuestionButton = new System.Windows.Forms.Button();
            this.questionListBox = new System.Windows.Forms.ListBox();
            this.saveQuestionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddQuestionButton
            // 
            this.AddQuestionButton.Location = new System.Drawing.Point(547, 11);
            this.AddQuestionButton.Name = "AddQuestionButton";
            this.AddQuestionButton.Size = new System.Drawing.Size(89, 23);
            this.AddQuestionButton.TabIndex = 2;
            this.AddQuestionButton.Text = "Добавить";
            this.AddQuestionButton.UseVisualStyleBackColor = true;
            this.AddQuestionButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addQuestionButton_MouseClick);
            // 
            // editQuestionButton
            // 
            this.editQuestionButton.Enabled = false;
            this.editQuestionButton.Location = new System.Drawing.Point(547, 40);
            this.editQuestionButton.Name = "editQuestionButton";
            this.editQuestionButton.Size = new System.Drawing.Size(89, 23);
            this.editQuestionButton.TabIndex = 3;
            this.editQuestionButton.Text = "Изменить";
            this.editQuestionButton.UseVisualStyleBackColor = true;
            this.editQuestionButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.editQuestionButton_MouseClick);
            // 
            // removeQuestionButton
            // 
            this.removeQuestionButton.Enabled = false;
            this.removeQuestionButton.Location = new System.Drawing.Point(547, 69);
            this.removeQuestionButton.Name = "removeQuestionButton";
            this.removeQuestionButton.Size = new System.Drawing.Size(89, 23);
            this.removeQuestionButton.TabIndex = 4;
            this.removeQuestionButton.Text = "Удалить";
            this.removeQuestionButton.UseVisualStyleBackColor = true;
            this.removeQuestionButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.removeQuestionButton_MouseClick);
            // 
            // questionListBox
            // 
            this.questionListBox.FormattingEnabled = true;
            this.questionListBox.HorizontalScrollbar = true;
            this.questionListBox.Items.AddRange(new object[] {
            "Вопрос 1",
            "Вопрос 2",
            "Вопрос 3"});
            this.questionListBox.Location = new System.Drawing.Point(12, 12);
            this.questionListBox.Name = "questionListBox";
            this.questionListBox.Size = new System.Drawing.Size(522, 238);
            this.questionListBox.TabIndex = 5;
            this.questionListBox.SelectedIndexChanged += new System.EventHandler(this.questionListBox_SelectedIndexChanged);
            this.questionListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.questionListBox_MouseDoubleClick);
            // 
            // saveQuestionsButton
            // 
            this.saveQuestionsButton.Location = new System.Drawing.Point(547, 236);
            this.saveQuestionsButton.Name = "saveQuestionsButton";
            this.saveQuestionsButton.Size = new System.Drawing.Size(89, 38);
            this.saveQuestionsButton.TabIndex = 6;
            this.saveQuestionsButton.Text = "Сохранить вопросы";
            this.saveQuestionsButton.UseVisualStyleBackColor = true;
            this.saveQuestionsButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.saveQuestionsButton_MouseClick);
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 286);
            this.Controls.Add(this.saveQuestionsButton);
            this.Controls.Add(this.questionListBox);
            this.Controls.Add(this.removeQuestionButton);
            this.Controls.Add(this.editQuestionButton);
            this.Controls.Add(this.AddQuestionButton);
            this.Name = "AdministrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление вопросами";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddQuestionButton;
        private System.Windows.Forms.Button editQuestionButton;
        private System.Windows.Forms.Button removeQuestionButton;
        private System.Windows.Forms.ListBox questionListBox;
        private System.Windows.Forms.Button saveQuestionsButton;
    }
}