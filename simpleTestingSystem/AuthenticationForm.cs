using simpleTestingSystem.Models;
using simpleTestingSystem.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace simpleTestingSystem
{
    public partial class AuthenticationForm : Form
    {

        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AuthenticationForm));

        IUserService userService;

        private List<User> users { set; get; }

        public AuthenticationForm()
        {
            InitializeComponent();
            userService = new UserService();
            logger.Info("Form1 start");         
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            checkInputFields();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            checkInputFields();
        }

        private void checkInputFields()
        {
            submitButton.Enabled = !(string.IsNullOrWhiteSpace(usernameTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text));
        }

        private void submitButton_MouseClick(object sender, MouseEventArgs e)
        {
            User user = userService.getUserByUsernameAndPassword(usernameTextBox.Text, passwordTextBox.Text);
            if (user != null)
            {
                passwordTextBox.Text = "";
                MessageBox.Show(string.Format("Вход выполнен!\nДобрый день,{1} {0}!", user.firstName, user.lastName));
                this.Hide();
                setCurrentUserInContext(user);
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
                MessageBox.Show(string.Format(Properties.Resources.WRONG_USER_NAME_OR_PASSWORD));
            }
        }

        private void setCurrentUserInContext(User user)
        {
            if (Properties.Settings.Default.Context[Properties.Resources.CURRENT_USER] != null)
            {
                Properties.Settings.Default.Context[Properties.Resources.CURRENT_USER] = user;
            } else
            {
                Properties.Settings.Default.Context.Add(Properties.Resources.CURRENT_USER, user);
            }
        }

        private void addNewUserButton_MouseClick(object sender, MouseEventArgs e)
        {
            using(UserForm form = new UserForm(userService))
            {
                this.Hide();
                form.ShowDialog();
            }
            this.Show();
        }
    }
}
