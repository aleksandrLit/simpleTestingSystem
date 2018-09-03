using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleTestingSystem
{
    public partial class AnswerForm : Form
    {
        public string currentAnswer { get; set; }

        public AnswerForm()
        {
            InitializeComponent();
        }

        public AnswerForm(string answer)
        {
            InitializeComponent();
            currentAnswer = answer;
            fillForm();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                currentAnswer = textBox1.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
        }

        private void fillForm()
        {
            textBox1.Text = currentAnswer;
        }
    }
}
