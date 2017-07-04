using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> datosUrl = new List<string>();
                Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
                archivos.leer(out datosUrl);
                foreach (string urlString in datosUrl)
                {
                    if(urlString !=null)
                        lstHistorial.Items.Add(urlString);
                }
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
         }

        private void lstHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
