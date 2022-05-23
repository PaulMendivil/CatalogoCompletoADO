using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerCatalogoCompletoADO
{
    public partial class Mostrar : Form
    {
        public Mostrar(Conexion.strPacientes SH)
        {
            InitializeComponent();
            txtID.Text = SH.ID.ToString();
            txtNombre.Text = SH.Nombre;
        }

        private void BtnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("ID: " + txtID.Text + "\nNombre: " + txtNombre.Text);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
