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
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
            ValidarBotones();
        }

        Conexion x = new Conexion();

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
            if (txtNombre.Text.Contains(";")|| txtNombre.Text.Contains("*")|| txtNombre.Text.Contains("'"))
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
            Conexion.strPacientes agg = new Conexion.strPacientes();
            agg.ID = Convert.ToInt32(txtID.Text);
            agg.Nombre = txtNombre.Text;
            if (x.Agregar(agg))
            {
                MessageBox.Show("Agregado Correctamente");
            }
            else
            {
                MessageBox.Show("Error al Agregar");
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
