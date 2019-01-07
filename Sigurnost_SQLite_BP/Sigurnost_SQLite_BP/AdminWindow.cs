using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sigurnost_SQLite_BP
{
    public partial class AdminWindow : Form
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnDodajZaposlenika_Click(object sender, EventArgs e)
        {
            if (tbZIme.Text == "" || tbZPrezime.Text == "" || tbZKorime.Text == "" ||
                tbZAdresa.Text == "" || tbZBankovniRacun.Text == "" || tbZEmail.Text == "" || 
                !int.TryParse(tbZOdjel.Text, out int odjel) || odjel <= 0)
            {
                MessageBox.Show("Provjerite unos i pokušajte ponovno");
                return;
            }

            //TODO: add encryption
            Employee employee = new Employee(tbZIme.Text, tbZPrezime.Text, tbZKorime.Text, tbZAdresa.Text,
                odjel, tbZBankovniRacun.Text, tbZEmail.Text);

            if (DatabaseManager.AddEmployee(employee))
            {
                MessageBox.Show("Uspješno je dodan zaposlenik");
            }
            else
            {
                MessageBox.Show("Greška u dodavanju zaposlenika");
            }
        }

        private void btnDodajOdjel_Click(object sender, EventArgs e)
        {
            if(tbOIme.Text == "" || !int.TryParse(tbOUpravitelj.Text, out int managerId) || managerId <=0 )
            {
                MessageBox.Show("Provjerite unos i pokušajte ponovno");
                return;
            }

            //TODO: add encryption
            Department department = new Department(tbOIme.Text, managerId);
            if(DatabaseManager.AddDepartment(department))
            {
                MessageBox.Show("Uspješno je dodan odjel");
                String newPassword = Encryption.GeneratePassword(2, 2, 2);

                Employee employee= DatabaseManager.FetchEmployee(managerId);
                sendPass(employee.Email, newPassword);
                
                DatabaseManager.SetEmployeePass(managerId, Encryption.PasswordHashing(employee.Username, newPassword));
            }
            else
            {
                MessageBox.Show("Greška u dodavanju odjela");
            }
            
        }

        private void sendPass(string email, string pass)
        {
            string subject = "Upravitelj odjela";
            string message = "lozinka: " + pass;
            //TODO: send email
            MessageBox.Show(pass);

            //sendEmail(email, subject, message);
        }
        
        private void sendEmail(string email, string subject, string message)
        {
            //TODO: fix
            MailMessage mail = new MailMessage("v@gmail.com", email);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mail.Subject = subject;
            mail.Body = message;
            client.Send(mail);
        }
    }
}
