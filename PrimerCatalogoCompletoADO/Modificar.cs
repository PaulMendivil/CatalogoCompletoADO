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
    public partial class Modificar : Form
    {
        public Modificar(Conexion.strPacientes sel)
        {
            InitializeComponent();
            txtID.Text = sel.ID.ToString();
            txtNombre.Text = sel.Nombre;
        }

        private void Modificar_Load(object sender, EventArgs e)
        {

        }
        void ValidarBotones()
        {
            if (txtID.Text.Trim().Length == 0 || txtNombre.Text.Trim().Length == 0)
            {
                btnAceptar.Enabled = false;
            }
            else
            {
                btnAceptar.Enabled = true;
            }
        }

        bool ValidarContenido()
        {
            try
            {
                int a = Convert.ToInt32(txtID.Text);
            }
            catch (Exception)
            {
                return false;
            }
            if (txtNombre.Text.Contains(";") || txtNombre.Text.Contains("*") || txtNombre.Text.Contains("'"))
            {
                return false;
            }
            return true;
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarContenido())
            {
                MessageBox.Show("Contenido Invalido");
                return;
            }
            Conexion x = new Conexion();
            Conexion.strPacientes mod = new Conexion.strPacientes();
            mod.ID = Convert.ToInt32(txtID.Text);
            mod.Nombre = txtNombre.Text;
            if (x.Modificar(mod))
            {
                MessageBox.Show("Se ha modificado correctamente");
            }
            else
            {
                MessageBox.Show("Error al modificar");
            }
            this.Dispose();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            ValidarBotones();
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            ValidarBotones();
        }
    }
}
