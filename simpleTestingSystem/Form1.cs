using simpleTestingSystem.Models;
using simpleTestingSystem.Services;
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
    public partial class Form1 : Form
    {

        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Form1));


        IUserService userService;

        private List<User> users { set; get; }

        public Form1()
        {
            InitializeComponent();
            userService = new UserService();
            logger.Info("Form1 start");         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            checkInputFields();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            checkInputFields();
        }

        private void checkInputFields()
        {
            button1.Enabled = !(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text));
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            User user = userService.getUserByUsernameAndPassword(textBox1.Text, textBox2.Text);
            if (user != null)
            {
                MessageBox.Show(string.Format("Вход выполнен!\nДобрый день,{1} {0}!", user.firstName, user.lastName));
                this.Hide();
                using (var nextForm = user.isSuperuser ? (Form)new AdministrationForm() : new TestingForm())
                {
                    if (!nextForm.IsDisposed)
                    {
                        nextForm.ShowDialog();
                    }
                }
                this.Show();
            } else
            {
                MessageBox.Show(string.Format("Имя пользователя или пароль не верны"));
            }
        }
    }
}
