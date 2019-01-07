using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sigurnost_SQLite_BP
{
    public partial class Login : Form
    {
        private string adminPass = "123";
        private int trynum = 3;
        public Login()
        {
            InitializeComponent();
        }

        private void uiActionLogin_Click(object sender, EventArgs e)
        {
            if(trynum <= 0)
            {
                MessageBox.Show("Previše neuspjelih pokušaja.");
                return;
            }
            string korime = uiInputKorisnickoIme.Text;
            string lozinka = uiInputLozinka.Text;
            //TODO: remove testing
            if (korime == "admin" && lozinka == adminPass)
            {
                AdminWindow adminWindow = new AdminWindow(lozinka);
                this.Hide();
                adminWindow.ShowDialog();
                this.Show();
            }
            else
            {
                string df = Encryption.Encrypt(korime, adminPass);
                string dff = Encryption.Encrypt(korime, adminPass);
                //TODO: change to hashed check
                if (DatabaseManager.CheckUser(korime, Encryption.PasswordHashing(korime, lozinka)))
                {
                    //user is valid
                    trynum = 3;

                    MessageBox.Show("Uspješno ste ulogirani");
                    //TODO: pronađi korisnika i njegov odjel kojemu ima pristup
                    Employee employee = DatabaseManager.FetchEmployee(korime);
                    //TODO: otvori pregled zaposlenika tog odjela

                    ManagerWindow managerWindow = new ManagerWindow(lozinka, korime);
                    this.Hide();
                    managerWindow.ShowDialog();
                    this.Show();
                }
                
                else
                {
                    //user isn't valid
                    trynum--;
                    MessageBox.Show("Voditelj odjela s tim korisničkim imenom i/ili lozinkom nije pronađen.\n Preostalo vam je " + trynum + " pokušaja");
                }
            }
        }
    }
}
