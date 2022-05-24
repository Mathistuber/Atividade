using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade
{
    public partial class TelaCadastrarCliente : Form
    {
        public TelaCadastrarCliente()
        {
            InitializeComponent();
        }

        private void validaDados()
        {
            if (string.IsNullOrWhiteSpace(tbxCPF.Text))
            {
                MessageBox.Show("CPF é obrigatório.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxCPF.Focus();
                tbxCPF.SelectAll();
                return;
            }
            string cpfInformado = tbxCPF.Text.Replace(".", "").Replace("-", "");

            if (string.IsNullOrWhiteSpace(tbxNome.Text))
            {
                MessageBox.Show("Nome é obrigatório.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxNome.Focus();
                tbxNome.SelectAll();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbxEmail.Text))
            {
                MessageBox.Show("Email é obrigatório.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxEmail.Focus();
                tbxEmail.SelectAll();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbxCelular.Text))
            {
                MessageBox.Show("Celular é obrigatório.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxCelular.Focus();
                tbxCelular.SelectAll();
                return;
            }

            if (cpfInformado.Length != 11)
            {
                lblResultado.Text = "Informe um CPF com 11 digitos.";
                lblResultado.ForeColor = Color.Red;
                return;
            }

            string cpf = cpfInformado.Substring(0, 9);

            int soma = 0;
            int valorRef = 10;

            for (int i = 0; i <= 8; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * valorRef--;
            }
            int dv1 = (int)soma % 11;

            if (dv1 < 2)
            {
                dv1 = 0;
            }
            else
            {
                dv1 = 11 - dv1;
            }

            if (!cpfInformado.Substring(9, 1).Equals(dv1.ToString()))
            {
                lblResultado.Text = "Informe um CPF válido.";
                lblResultado.ForeColor = Color.Red;
                return;
            }
            cpf = cpf + dv1.ToString();
            valorRef = 11;
            soma = 0;

            for (int i = 9; i >= 0; i--)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * valorRef--;
            }
            int dv2 = (int)soma % 11;

            if (dv2 < 2)
            {
                dv2 = 0;
            }
            else
            {
                dv2 = 11 - dv2;
            }
            cpf = cpf + dv2.ToString();

            if (!cpfInformado.Substring(10, 1).Equals(dv2.ToString()))
            {
                lblResultado.Text = "Informe um CPF válido.";
                lblResultado.ForeColor = Color.Red;
                return;
            }

            lblResultado.Text = "Dados Válidos";
            lblResultado.ForeColor = Color.Green;
        }

        public void LimparTela()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox)
                {
                    ctl.Text = string.Empty;
                }
                else if (ctl is Label && Convert.ToInt32(ctl.Tag).Equals(1))
                {
                    ctl.Text = string.Empty;
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            validaDados();
            LimparTela();
        }
    }
}