using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;

namespace CalculadoraCapurro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Realiza la operacion solicitada por el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultadoAux;

            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);
            
            resultadoAux = Calculadora.operar(numero1, numero2, cmbOperador.Text);

            Numero resultado = new Numero(resultadoAux);

            lblResultado.Text = resultado.getNumero().ToString();
        }
        /// <summary>
        /// Se encarga de Limpiar los text box y el Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "(Resultado)";
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbOperador.SelectedIndex = 0;
            cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
