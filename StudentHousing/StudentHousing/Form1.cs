using DataAcces;
using Logic.Managers;

namespace StudentHousing
{
    public partial class Form1 : Form
    {
        private readonly CustomerManager customerManager;
        public Form1()
        {
            InitializeComponent();
            customerManager = new CustomerManager(new CustomerRepository());
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            var id = customerManager.GetIDByCredentials(tbUserName.Text, tbPassword.Text).PersonID;

            if (id > -1)
            {
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You have introduced the wrong credentials");
            }
        }
    }
}