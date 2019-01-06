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
    public partial class Form1 : Form
    {
        private int trynum = 3;
        public Form1()
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
            
            //TODO: admin logika za potrebe testiranja
            if(korime == "admin" && lozinka == "adminpass")
            {
                //TODO: open admin view
            }
            else
            {
                //TODO: change to hashed check like it's in the comment
                if(DatabaseManager.CheckUser(korime,lozinka))//Encryption.Hashing(korime), Encryption.PasswordHashing(korime, lozinka)))
                {
                    //user is valid
                    trynum = 3;

                    MessageBox.Show("Uspješno ste ulogirani");
                    //TODO: pronađi korisnika i njegov odjel kojemu ima pristup
                    //TODO: otvori pregled zaposlenika tog odjela
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
