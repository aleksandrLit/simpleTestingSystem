using simpleTestingSystem.Models;
using simpleTestingSystem.Services;
using System;
using System.Windows.Forms;

namespace simpleTestingSystem
{
    public partial class UserForm : Form
    {
        private IUserService userService;

        public User newUser { get; set; }

        public UserForm(IUserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }

        private void saveNewUserButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (userService.isExistUserWithUsername(usernameTextBox.Text))
            {
                MessageBox.Show(Properties.Resources.USERNAME_IS_ALREADY_EXIST, Properties.Resources.ERROR);
                return;
            } else
            {
                userService.createUser(fillUserByTextBoxes());
                userService.serializeUsers();
                this.Close();
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            checkFieldForEnableSubmitButton();
        }

        private void checkFieldForEnableSubmitButton()
        {
            saveNewUserButton.Enabled = !string.IsNullOrWhiteSpace(usernameTextBox.Text) && !string.IsNullOrWhiteSpace(passwordTextBox.Text)
                && !string.IsNullOrWhiteSpace(firstNameTextBox.Text) && !string.IsNullOrWhiteSpace(lastNameTextBox.Text) && !string.IsNullOrWhiteSpace(middleNameTextBox.Text);

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            checkFieldForEnableSubmitButton();
        }

        private void middleNameTextBox_TextChanged(object sender, EventArgs e)
        {
            checkFieldForEnableSubmitButton();
        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            checkFieldForEnableSubmitButton();
        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            checkFieldForEnableSubmitButton();
        }

        private User fillUserByTextBoxes()
        {
            User user = new User();
            user.firstName = firstNameTextBox.Text;
            user.lastName = lastNameTextBox.Text;
            user.middleName = middleNameTextBox.Text;
            user.userName = usernameTextBox.Text;
            user.password = passwordTextBox.Text;
            user.isSuperuser = false;
            return user;
        }
    }
}
