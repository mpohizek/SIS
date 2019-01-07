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
        private string adminPas;
        public AdminWindow()
        {
            InitializeComponent();
        }
        public AdminWindow(string adminPass)
        {
            InitializeComponent();
            adminPas = adminPass;
        }

        private void btnDodajOdjel_Click(object sender, EventArgs e)
        {
            if(tbOIme.Text == "" || !int.TryParse(tbOId.Text, out int depId) || depId <=0 )
            {
                MessageBox.Show("Provjerite unos i pokušajte ponovno");
                return;
            }

            //TODO: add encryption
            Department department = new Department(depId, tbOIme.Text);
            if(DatabaseManager.AddDepartment(department))
            {
                MessageBox.Show("Uspješno je dodan odjel");
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

        private void btnDodajZaposlenika_Click(object sender, EventArgs e)
        {
            if (tbZIme.Text == "" || tbZPrezime.Text == "" || tbZKorime.Text == "" ||
                tbZAdresa.Text == "" || tbZBankovniRacun.Text == "" || tbZEmail.Text == "" ||
                !int.TryParse(tbZOdjel.Text, out int odjel) || !int.TryParse(tbVodiOdjel.Text, out int depId) || odjel <= 0 || depId <= 0)
            {
                MessageBox.Show("Provjerite unos i pokušajte ponovno");
                return;
            }
            String newPassword = Encryption.GeneratePassword(2, 2, 2);
            
            Employee employee = new Employee(tbZIme.Text, tbZPrezime.Text, tbZKorime.Text, tbZAdresa.Text,
                odjel, tbZBankovniRacun.Text, tbZEmail.Text);
            employee = employee.Encrypt(adminPas);

            if (!DatabaseManager.AddEmployee(employee))
            {
                MessageBox.Show("Greška u dodavanju zaposlenika");
                return;
            }

            if(!DatabaseManager.SetEmployeePass(employee.Username, Encryption.PasswordHashing(employee.Username, newPassword))) {
                MessageBox.Show("Greška u postavljanju lozinke zaposlenika");
                return;
            }
            sendPass(employee.Email, newPassword);

            if(!DatabaseManager.SetDepManager(DatabaseManager.FetchEmployee(employee.Username).Id, depId))
            {
                MessageBox.Show("Greška u postavljanju kreiranog zaposlenika za upravitelja odabranog odjela");
                return;
            }

        }
    }
}
