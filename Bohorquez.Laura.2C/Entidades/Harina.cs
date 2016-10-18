using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Harina:Producto
    {
        #region ATRIBUTOS

        protected ETipoHarina _tipo;
        protected static bool DeConsumo;

        #endregion

        #region PROPIEDADES

        public override float CalcularCostoDeProduccion
        {
            get { return (this._precio * (float)0.60); }
        }

        #endregion

        #region CONSTRUCTORES

        static Harina()
        {
            DeConsumo = false;
        }

        public Harina(int codigo, float precio, EMarcaProducto marca,  ETipoHarina tipo)
            : base(codigo, precio, marca)
        {
            this._tipo = tipo;
        }

        #endregion

        #region METODOS

        private  string MostrarHarina()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MARCA: " + this._marca.ToString());
            sb.AppendLine("CODIGO DE BARRA: " + this._codigoDeBarra.ToString());
            sb.AppendLine("PRECIO: " + this._precio.ToString());
            sb.AppendLine("TIPO: " + this._tipo);

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarHarina().ToString();
        }

        #endregion

        public enum ETipoHarina
        {
            DosCeros, TResCeros, CuatroCeros, Integral
        }

    }
}
