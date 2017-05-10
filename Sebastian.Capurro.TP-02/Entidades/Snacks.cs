using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades_2017
{
    public class Snacks:Producto//se hereda Producto
    {
        public Snacks(EMarca marca, string codigoDeBarras, ConsoleColor color):base(codigoDeBarras,marca,color)//se reemplaza el :base(marca,patente,color)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine((string)this);//se remplaza el base
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);//se reemplaza el appendLine
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
