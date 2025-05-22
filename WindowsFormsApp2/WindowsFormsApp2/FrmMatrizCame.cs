using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Clases;
using WindowsFormsApp2.Modelos;

namespace WindowsFormsApp2
{
    public partial class FrmMatrizCame : Form
    {
        public FrmMatrizCame()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtt1.Text) || string.IsNullOrWhiteSpace(txtt2.Text) ||
                string.IsNullOrWhiteSpace(txtt3.Text) || string.IsNullOrWhiteSpace(txtt4.Text) ||
                string.IsNullOrWhiteSpace(txtt5.Text) || string.IsNullOrWhiteSpace(txtt6.Text) ||
                string.IsNullOrWhiteSpace(txtt7.Text) || string.IsNullOrWhiteSpace(txtt8.Text) ||
                string.IsNullOrWhiteSpace(txtt9.Text) || string.IsNullOrWhiteSpace(txtt10.Text) ||
                string.IsNullOrWhiteSpace(txtt11.Text) || string.IsNullOrWhiteSpace(txtt12.Text) ||
                string.IsNullOrWhiteSpace(txtt13.Text) || string.IsNullOrWhiteSpace(txtt14.Text) ||
                string.IsNullOrWhiteSpace(txtt15.Text) || string.IsNullOrWhiteSpace(txtt16.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de registrar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (DataClasses3DataContext dc = new DataClasses3DataContext())
                {
                    TextBox[] campos = { txtt1, txtt2, txtt3, txtt4, txtt5, txtt6, txtt7, txtt8,
                                 txtt9, txtt10, txtt11, txtt12, txtt13, txtt14, txtt15, txtt16 };

                    for (int i = 0; i < campos.Length; i++)
                    {
                        string codigo = (i + 1).ToString("D2");
                        string descripcion = campos[i].Text.Trim();
                        int? nuevoId = null;

                        dc.SP_RegistrarMatrizCAME(codigo, descripcion, Sesion.EmpresaId, ref nuevoId);
                    }
                }


                MessageBox.Show("Matriz CAME registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la matriz CAME: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
