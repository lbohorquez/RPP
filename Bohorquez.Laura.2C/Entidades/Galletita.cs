using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita:Producto
    {

         #region ATRIBUTOS

        protected float _peso;
        protected static bool DeConsumo;

        #endregion

        #region PROPIEDADES

        public override float CalcularCostoDeProduccion
        {
            get { return (this._precio * (float)0.33); }
        }

        #endregion

        #region CONSTRUCTOR

        public Galletita(int codigo, float precio, EMarcaProducto marca, float peso)
            : base(codigo, precio, marca)
        {
            this._peso = peso;
            Galletita.DeConsumo = true;
        }

        #endregion

        #region METODOS
        public override string Consumir()
        {
            return "Comestible";
        }
        private static string MostrarGalletita(Galletita g)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MARCA: " + g._marca);
            sb.AppendLine("CODIGO DE BARRA: " + g._codigoDeBarra);
            sb.AppendLine("PRECIO: " + g._precio);
            sb.AppendLine("PESO: " + g._peso);

            return sb.ToString();

           // return g.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MARCA: " + base._marca);
            sb.AppendLine("CODIGO DE BARRA: " + base._codigoDeBarra);
            sb.AppendLine("PRECIO: " + base._precio);
            sb.AppendLine("PESO: " +this._peso );

            return sb.ToString();
        }


        #endregion
    }
}
