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
    public partial class Eliminar : Form
    {
        public Eliminar(Conexion.strPacientes del)
        {
            InitializeComponent();
            txtID.Text= del.ID.ToString();
            txtNombre.Text = del.Nombre;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Conexion x = new Conexion();
            Conexion.strPacientes del = new Conexion.strPacientes();
            del.Nombre = txtNombre.Text;
            del.ID = Convert.ToInt32(txtID.Text);
            if (x.Eliminar(del))
            {
                MessageBox.Show("Se ha eliminado correctamente");
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
            this.Dispose();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
