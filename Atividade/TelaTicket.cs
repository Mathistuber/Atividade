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
    public partial class TelaTicket : Form
    {
        public TelaTicket()
        {
            InitializeComponent();
        }
        private void validaDados()
        {
            if (string.IsNullOrWhiteSpace(tbxNome.Text))
            {
                MessageBox.Show("Nome é obrigatório.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxNome.Focus();
                tbxNome.SelectAll();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbxPlaca.Text))
            {
                MessageBox.Show("Placa é obrigatória.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxPlaca.Focus();
                tbxPlaca.SelectAll();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbxCor.Text))
            {
                MessageBox.Show("Cor é obrigatória.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxCor.Focus();
                tbxCor.SelectAll();
                return;
            }

            lblResultado.Text = "Dados Válidos";
            lblResultado.ForeColor = Color.Green;
        }

        public void LimparTela()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is ComboBox)
                {
                    ctl.Text = string.Empty;
                }
                else if (ctl is TextBox)
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
