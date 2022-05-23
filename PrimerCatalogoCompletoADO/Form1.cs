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
    public partial class Form1 : Form
    {
        Conexion cx = new Conexion();
        Conexion.strPacientes[] arrPac = null;
        public Form1()
        {
            InitializeComponent();
            ValidarBotones();
            Listar();
           
        }

        private void LstAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarBotones();
        }

        void Listar()
        {
            lstPacientes.Items.Clear();
            cx.Listar(ref arrPac, txtFiltro.Text);
            for (int i = 0; i < arrPac.Length; i++)
            {
                ListViewItem it = new ListViewItem(arrPac[i].Nombre);
                it.Tag = arrPac[i];
                lstPacientes.Items.Add(it);
            }

        }

        void ValidarBotones()
        {
            if (lstPacientes.SelectedItems.Count==0)
            {
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnMostrar.Enabled = false;
            }
            else
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                btnMostrar.Enabled = true;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Agregar x = new Agregar();
            x.ShowDialog();
            Listar();
            ValidarBotones();
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            Mostrar x = new Mostrar((Conexion.strPacientes)lstPacientes.SelectedItems[0].Tag);
            x.ShowDialog();
            Listar();
            ValidarBotones();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Modificar x = new Modificar((Conexion.strPacientes)lstPacientes.SelectedItems[0].Tag);
            x.ShowDialog();
            Listar();
            ValidarBotones();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar x = new Eliminar((Conexion.strPacientes)lstPacientes.SelectedItems[0].Tag);
            x.ShowDialog();
            Listar();
            ValidarBotones();
        }

        private void LstPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void LstPacientes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ValidarBotones();
        }
    }
}
