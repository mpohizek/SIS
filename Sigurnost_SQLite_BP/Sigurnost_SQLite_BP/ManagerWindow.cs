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
    public partial class ManagerWindow : Form
    {
        private string pas;
        private string korime;
        public ManagerWindow()
        {
            InitializeComponent();
        }

        public ManagerWindow(string pass, string korimee)
        {
            InitializeComponent();
            pas = pass;
            korime = korimee;
        }

        private void btnDodajZaposlenika_Click(object sender, EventArgs e)
        {
            if (tbZIme.Text == "" || tbZPrezime.Text == "" || tbZKorime.Text == "" ||
                tbZAdresa.Text == "" || tbZBankovniRacun.Text == "" || tbZEmail.Text == "")
            {
                MessageBox.Show("Provjerite unos i pokušajte ponovno");
                return;
            }
            int depId = DatabaseManager.FetchManagerDepId(korime);
            if (depId <= 0)
            {
                MessageBox.Show("Greška pri pronalasku id odjela");
                return;
            }

            Employee employee = new Employee(tbZIme.Text, tbZPrezime.Text, tbZKorime.Text, tbZAdresa.Text,
                depId, tbZBankovniRacun.Text, tbZEmail.Text);

            employee = employee.Encrypt(pas);

            if (DatabaseManager.AddEmployee(employee))
            {
                MessageBox.Show("Uspješno je dodan zaposlenik");
            }
            else
            {
                MessageBox.Show("Greška u dodavanju zaposlenika");
            }
        }

        private void btnPrintEmployees_Click(object sender, EventArgs e)
        {
            tbPrintEmployees.Text = "";
            List<Employee> employees = new List<Employee>();
            employees = DatabaseManager.GetMyEmployees(korime, pas);
            foreach(Employee employee in employees)
            {
                tbPrintEmployees.Text += employee.ToString();
                tbPrintEmployees.AppendText(Environment.NewLine);
            }
        }
    }
}
