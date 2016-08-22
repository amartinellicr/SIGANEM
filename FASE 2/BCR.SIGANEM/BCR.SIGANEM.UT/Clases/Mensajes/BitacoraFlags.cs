using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.UT
{
    public class BitacoraFlags
    {

        #region METODOS PUBLICOS

        public int TipoBitacoraConsulta(EnumTipoBitacora tipoBitacora)
        {
            int valor = 0;

            switch (tipoBitacora)
            {
                case EnumTipoBitacora.INSERTAR:
                    valor = 100; 
                    break;

                case EnumTipoBitacora.ACTUALIZAR:
                    valor = 200; 
                    break;

                case EnumTipoBitacora.ELIMINAR:
                    valor = 300; 
                    break;

                case EnumTipoBitacora.CONSULTAR:
                    valor = 400; 
                    break;

                case EnumTipoBitacora.SESION_INICIA:
                    valor = 500; 
                    break;

                case EnumTipoBitacora.SESION_CIERRA:
                    valor = 600; 
                    break;

                case EnumTipoBitacora.SESION_CADUCA:
                    valor = 700; 
                    break;

                case EnumTipoBitacora.SESION_CONSULTA:
                    valor = 800; 
                    break;

                case EnumTipoBitacora.REPORTE:
                    valor = 900; 
                    break;

                case EnumTipoBitacora.EJECUCION:
                    valor = 1000; 
                    break;
                case EnumTipoBitacora.REGISTRAR:
                    valor = 1100;
                    break;
            }

            return valor;
        }

        #endregion

    }
}
