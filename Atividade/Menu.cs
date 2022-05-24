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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnCadastroCliente_Click(object sender, EventArgs e)
        {
            Atividade.TelaCadastrarCliente cadacliente = new Atividade.TelaCadastrarCliente();
            cadacliente.Show();

        }

        private void btnCadastroCarro_Click(object sender, EventArgs e)
        {
            Atividade.TelaCadastroCarro cadacarro = new Atividade.TelaCadastroCarro();
            cadacarro.Show();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            Atividade.TelaTicket ticket = new Atividade.TelaTicket();
            ticket.Show();
        }
    }
}
