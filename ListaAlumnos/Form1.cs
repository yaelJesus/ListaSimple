using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaAlumnos
{
    public partial class Form1 : Form
    {
        Lista miLista;
        public Form1()
        {
            InitializeComponent();
            miLista = new Lista();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                string nombre = txtNombre.Text;
                string telefono = txtTelefono.Text;
                Nodo n = new Nodo(numero, nombre, telefono);

                miLista.Agregar(n);
                txtNumero.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();
                miLista.Mostrar(lstDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                miLista.Eliminar(numero);
                txtNumero.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lstDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                Nodo b = new Nodo();
                if (miLista.Buscar(numero, ref b))
                {
                    txtNombre.Text = b.Nombre;
                    txtTelefono.Text = b.Telefono;
                }
                else
                {
                    MessageBox.Show("No Existe");
                    txtNumero.Clear();
                    txtNumero.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                miLista.Modificar(numero, txtNombre.Text, txtTelefono.Text);
                txtNumero.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lstDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                miLista.Guardar("testListaSimple");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                miLista.Cargar("testListaSimple");
                miLista.Mostrar(lstDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
